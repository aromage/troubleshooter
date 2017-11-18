using UnityEngine;
using System.Collections;

public class Skill_06 : MonoBehaviour {

    PlayerManager player;
    GameObject p_position;
    GameObject effect;
    Vector3 op = Vector3.zero;
    float degree = 0.0f;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        p_position = GameObject.FindWithTag("player");

        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_6"));
        effect.transform.position = p_position.transform.position;
        StartCoroutine(Act());
        op.x = -60.0f;
	}
	
	// Update is called once per frame
	void Update () {
        op.x = 60.0f * Mathf.Sin(degree / 180.0f * Mathf.PI);
        op.y = 60.0f * Mathf.Cos(degree / 180.0f * Mathf.PI);

        degree += 4;
        if (degree >= 360)
            degree = 0;

        effect.transform.position = p_position.transform.position + op;
	}

    public IEnumerator Act()
    {
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            
            HitType ht = player.players_info[i].bullet_hit_type;
            float speed = player.players_info[i].bullet_SPD;
            float size = player.players_info[i].bullet_size;
            State bs = player.players_info[i].bullet_state;
            float damage = player.players_info[i].char_ATK;
            int num = player.players_info[i].index;

            if (player.players_info[i].attribute == Attribute.FIRE)
            {
               player.players[i].GetComponent<myShooter>().SetBulletInfo(num,Attribute.FIRE, ht, speed,damage*2 ,bs, size);
            }
        }


        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(5.0f));
        for (int i = 0; i < HudEventManager.playernum; i++)
        {

            HitType ht = player.players_info[i].bullet_hit_type;
            float speed = player.players_info[i].bullet_SPD;
            float size = player.players_info[i].bullet_size;
            State bs = player.players_info[i].bullet_state;
            float damage = player.players_info[i].char_ATK;
            int num = player.players_info[i].index;

            if (player.players_info[i].attribute == Attribute.FIRE)
            {
                player.players[i].GetComponent<myShooter>().SetBulletInfo(num, Attribute.FIRE, ht, speed, damage, bs, size);
            }
        }

        Destroy(effect);
        Destroy(this.gameObject);
        SKillManager.usedend(6);
        yield return null;
    }

}
