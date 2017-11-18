using UnityEngine;
using System.Collections;

public class Skill_02 : MonoBehaviour 
{
    UISlider hp_bar;
    // Use this for initialization
    GameObject player, p_position;
    float hp, hp_c;
    GameObject effect;
    PlayerManager playerManager;
    void Start() 
    {
        player = GameObject.Find("PlayerManager");
        if (player == null)
        {
            return;
        }
        hp_bar = GameObject.Find("Player_Hp_Bar").GetComponent<UISlider>();
        if (hp_bar == null)
        {
            return;
        }
        hp_c = ((player.GetComponent<PlayerManager>().HP_current) / (player.GetComponent<PlayerManager>().HP_max));
        if (hp_c == null)
        {
            return;
        }
        hp = hp_c;
        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_2"));
        if (effect == null)
        {
            return;
        }
        if (GameObject.FindWithTag("player") == null)
        {
            return;
        }
        effect.transform.position = GameObject.FindWithTag("player").transform.position;
      
        p_position = GameObject.FindWithTag("player");

        if (p_position == null)
        {
            return;
        }
        playerManager = player.GetComponent<PlayerManager>();
        StartCoroutine(Act());
    }

    void Update()
    {
        
        
        if (player == null || p_position == null)
        {
            hp_bar.value = 0.0f;
            Destroy(effect);
            Destroy(gameObject);
            return;
        }
		if ( playerManager == null)
		{
			return;
		}
        hp_bar.value = hp;
		playerManager.HP_current = hp * (playerManager.HP_max);
        if (effect == null)
        {
            return;
        }
        
        effect.transform.position = p_position.transform.position;

    }

    public IEnumerator Act()
    {
        float hpregen = 0.0f;
        if ((playerManager.HP_current + GameManager.CharacterInfo[1].char_ATK * 2.0f) > playerManager.HP_max)
        {
            hpregen = 1.0f;
        }
        else
        {
            hpregen = ((playerManager.HP_current + GameManager.CharacterInfo[1].char_HP * 1.0f) / playerManager.HP_max);
        }


        iTween.ValueTo(gameObject, iTween.Hash("from", hp_c, "to", hpregen,"time", 0.6f, "onupdate", "hp_anim", "ignoretimescale", true));
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(3.0f));
        Destroy(effect);
        Destroy(this.gameObject);
        SKillManager.usedend(2);
        yield return null;
    }

    public void hp_anim(float a)
    {
        hp = a;
    }

   
}