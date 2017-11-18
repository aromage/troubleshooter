using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] players;
    public PlayerBase[] players_info = new PlayerBase[3];
    public int member_count;

    PartyStatus current_party;
    public float MP_current;
    public float MP_max;
    public float HP_current;
    public float HP_max;

	// Use this for initialization
    void Awake()
    {
        GameObject cursor = (GameObject)Instantiate(ResourceLoad.PickGameObject("cursor"));
        cursor.SetActive(false);

        member_count = 0;
        current_party = GameManager.User.party;
        for (int i = 0; i < 3; i++)
        {
            if (current_party.member[i].char_name != "NULL")
            {
                member_count++;
            }
        }

        players = new GameObject[member_count];
        int k=0;
        for (int i = 0; i < member_count; i++)
        {
            if (current_party.member[i].char_name == "NULL")
            {
                k++;
                if (k == 3)
                {
                    return;
                }
            }
            players[i] = (GameObject)Instantiate(ResourceLoad.PickGameObject("player"+k.ToString()));
            GiveInfo(i, k);
            players[i].name = players_info[i].name;
            players[i].SendMessage("SetMain", players_info[0].name);
            switch (i)
            {
                case 0:
                    players_info[i].position = Position.FIRST;
                    players[i].tag = "player";
                    break;
                case 1:
                    players_info[i].position = Position.SECOND;
                    players[i].tag = "player_sub";
                    break;
                case 2:
                    players_info[i].position = Position.THIRD;
                    players[i].tag = "player_sub";
                    break;
                default:
                    break;
            }
            k++;
        }

        HP_max = current_party.total_HP;
        HP_current = HP_max;
        MP_max = current_party.total_MP;
        MP_current = 0;
    }

    public void StartShoot()
    {
        for (int i = 0; i < member_count; i++)
        {
            players_info[i].StartShooting();
        }
    }

    public void StopShoot()
    {
        for (int i = 0; i < member_count; i++)
        {
            players_info[i].StopShooting();
        }
    }

    void GiveInfo(int i, int k) // DB로 부터 기본 정보
    {
        players_info[i] = players[i].GetComponent<PlayerBase>();

        players_info[i].index = k;

        players_info[i].char_name = current_party.member[k].char_name;
        players_info[i].char_HP = current_party.member[k].char_HP;
        players_info[i].char_MP = current_party.member[k].char_MP;
        players_info[i].char_ATK = current_party.member[k].char_ATK;
        players_info[i].char_SPD = current_party.member[k].char_SPD;
        players_info[i].attribute = current_party.member[k].attribute;

        players_info[i].skill_num = current_party.member[k].Askill_num;
        players_info[i].skill_MP = current_party.member[k].Askill_MP;

        players_info[i].bullet_move = current_party.member[k].bullet_move_type;
        players_info[i].bullet_hit_type = current_party.member[k].bullet_hit_type;
        players_info[i].bullet_size = current_party.member[k].bullet_size;
        players_info[i].bullet_SPD = current_party.member[k].bullet_SPD;

        players_info[i].shooting_way = current_party.member[k].shooting_way;
        players_info[i].shooting_amount = current_party.member[k].shooting_amount;
        players_info[i].shooting_repeat = current_party.member[k].shooting_repeat;
        players_info[i].shooting_period = current_party.member[k].shooting_period;
        players_info[i].shooting_delay = current_party.member[k].shooting_delay;
        players_info[i].shooting_angle = current_party.member[k].shooting_angle;
    }

    void ChangePosition(Position[] pos) // 리더 변경
    {
        int t1 = 0, t2 = 0;
        for (int i = 0; i < member_count; i++)
        {
            if (players_info[i].position == pos[0])
            {
                t1 = i;
            }
            if (players_info[i].position == pos[1])
            {
                t2 = i;
            }
        }
        string temp_tag = players[t1].tag;

        players_info[t1].position = pos[1];
        players[t1].tag = players[t2].tag;
        players_info[t2].position = pos[0];
        players[t2].tag = temp_tag;
        for(int k = 0; k<3;k++)
        {
            if (players_info[k].position == Position.FIRST)
            {
                for (int l = 0; l < member_count; l++)
                {
                    players[l].SendMessage("SetMain", players_info[k].name);
                }
                break;
            }
        }
        for (int i = 0; i < member_count; i++)
        {
            players[i].SendMessage("ChangeATK");
        }
    }

    void ChangeMP(float ratio_) //MP 변경
    {
        if ((MP_current += (MP_max * ratio_)) >= MP_max) { MP_current = MP_max; }
    }

    void ChangeHP(float ratio_) //HP 변경
    {
        if ((HP_current += (HP_max * ratio_)) >= HP_max) { HP_current = HP_max; }
    }

    void ApplyDamage(float damage_)
    {
        GameObject.Find("HudManager").SendMessage("damaged");

        if (damage_ < 1)
        {
            damage_ = HP_max * damage_;
        }

        if ((HP_current -= damage_) <= 0)
        {
            HP_current = 0;
            StartCoroutine(PlayerDead());
            for (int i = 0; i < member_count; i++)
            {
                players[i].GetComponent<PlayerMain>().mover_phase = MoverPhase.DESTROY;
            }
        }
    }

    IEnumerator PlayerDead()
    {
        GameObject die;
        die = (GameObject)Instantiate(ResourceLoad.PickGameObject("killed_effect"));
        die.transform.position = GameObject.FindWithTag("player").transform.position;

        yield return new WaitForSeconds(0.7f);
        DestroyImmediate(die);
        GameObject.Find("StageManager").SendMessage("MoveToFinishPhase");
    }

    //************************************
    public void BeStrong()
    {
        HP_max = 1000000;
        HP_current = HP_max;
        MP_current = MP_max;
    }
}
