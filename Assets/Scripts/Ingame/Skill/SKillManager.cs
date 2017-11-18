using UnityEngine;
using System.Collections;

public class SKillManager : MonoBehaviour {

    GameObject text;

    PlayerManager player;
    CCutinManager cutM;
    StageManager SM;
    bool[] skill_on = new bool[3];
    int[] skill_num = new int[3];
    int skill_on_num = 0;

    public static int[] skill_used = new int[3];
    // Use this for initialization

    void Start()
    {
        text = Resources.Load<GameObject>("Prefabs/hud/Damage_Text");

        SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        cutM = GameObject.Find("CutIn_panel").GetComponent<CCutinManager>();
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            skill_num[i] = 0;
            skill_on[i] = false;
            skill_used[i] = 0;
        }
    }
        
    void Update()
    {

    }

    public void create_damage_text(float damage,float att, Vector3 a)
    {
        GameObject newtext = (GameObject)Instantiate(text);
        newtext.AddComponent<DamageText>().Init(damage,att, a);
    }

    public bool usedcheck(int num)
    {
        for(int i=0; i<HudEventManager.playernum; i++)
        {
            if(skill_used[i] == num)
            return true;
        }
        return false;
    }

    public static void usedend(int num)
    {
        for(int i=0; i<HudEventManager.playernum; i++)
        {
            if(skill_used[i] == num)
                skill_used[i] = 0;
        }
    }


    public bool skill_check(int num)
    {
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
                if (skill_num[i] == num)
                {
                    cutM.cutback(i);
                    skill_on[i] = false;
                    skill_num[i] = 0;
                    skill_on_num--;
                    return true;
                }
            
        }
        return false;
    }

    public bool skill_stack(string name, int att, int num)
    {
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            if (num <= GameManager.char_count)
            {
                if (skill_num[i] == 0)
                {
                    cutM.CutInUsage(name, att, i);
                    cutM.cutin(i);
                    skill_on[i] = true;
                    skill_num[i] = num;
                    skill_on_num++;
                    return true;
                }
            }
        }
        return false;
    }

    public void skillUse()
    {
        if (skill_on_num != 0)
        {
            skill_on_num = 0;
            SM.SetforcedMatrix(1, 1.2f);
            StartCoroutine("skill_activate");
        }
    }

    IEnumerator skill_activate()
    {
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.1f));
            if (skill_on[i])
            {
                cutM.cutout(i);
            }
        }

        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            if (skill_on[i])
            {
                SkillUsage(skill_num[i]);
                skill_used[i] = skill_num[i];
                skill_on[i] = false;
                skill_num[i] = 0;
                
            }
        }
    }

    void SkillUsage(int num)
    {
        GameObject skill = new GameObject();
        string s = "Skill_";
        string n;

        if (num < 10)
            n = "0";
        else
            n = "";

        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(skill, "Assets/Scripts/Ingame/Skill/SKillManager.cs (146,9)", s + n + num);
    }

    public int ManaCheck(int n)
    {
        int num = 6;
        for (int i = 0; i < HudEventManager.playernum; i++)
        {
            if (player.players[i].GetComponent<PlayerBase>().position == (Position)n)
            {
                num = i;
                break;
            }
        }        


        if(skill_check(player.players_info[num].skill_num))
        {
            player.MP_current += player.players_info[num].skill_MP;
            if (player.MP_current > player.MP_max)
                player.MP_current = player.MP_max;
        }
        else if(usedcheck(player.players_info[num].skill_num))
        {
            return 2;
        }
        else if (player.players_info[num].skill_MP <= player.MP_current)
        {
                player.MP_current -= player.players_info[num].skill_MP;
                skill_stack(player.players_info[num].char_name, (int)player.players_info[num].attribute,
                    player.players_info[num].skill_num);    
                return 0;
        }
        else
        {
            return 1;
        }
         
        return 0;
    }




}
