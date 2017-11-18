using UnityEngine;
using System.Collections;

public class Skill_05 : MonoBehaviour
{


    // Use this for initialization
    PlayerManager player;
    GameObject   p_position;
    GameObject effect;
    //GameObject buff_label;

    Vector3 op = Vector3.zero;
    float degree = 0.0f;

    UILabel me;
    

    void Start()
    {

        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        p_position = GameObject.FindWithTag("player");

        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_5"));
        effect.transform.position = p_position.transform.position;
        StartCoroutine(Act());
        op.x = -60.0f;
    }

    void Update()
    {
         op.x = 60.0f*Mathf.Sin(degree / 180.0f *Mathf.PI);
         op.y = 60.0f*Mathf.Cos(degree / 180.0f * Mathf.PI);

         degree += 4;
         if (degree >= 360)
             degree = 0;

        effect.transform.position = p_position.transform.position + op;
    }

    public IEnumerator Act()
    {
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            int way = player.players_info[i].shooting_way;
            int amount = player.players_info[i].shooting_amount;
            int repeat = player.players_info[i].shooting_repeat;
            float period = player.players_info[i].shooting_period;
            float delay = player.players_info[i].shooting_delay;
            float angle = player.players_info[i].shooting_angle;
            if (player.players_info[i].attribute == Attribute.NATURE)
            {
                player.players[i].GetComponent<myShooter>().SetShooitngInfo(way,
                    amount, repeat * 2, period / 2.0f, delay / 2.0f, angle);
            }
        }


        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(5.0f));
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            int way = player.players_info[i].shooting_way;
            int amount = player.players_info[i].shooting_amount;
            int repeat = player.players_info[i].shooting_repeat;
            float period = player.players_info[i].shooting_period;
            float delay = player.players_info[i].shooting_delay;
            float angle = player.players_info[i].shooting_angle;
            player.players[i].GetComponent<myShooter>().SetShooitngInfo(way, amount, repeat, period, delay, angle);
        }

       // Destroy(buff_label);
        Destroy(effect);
        Destroy(this.gameObject);
        SKillManager.usedend(5);
        yield return null;
    }


}
