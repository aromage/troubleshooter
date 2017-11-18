using UnityEngine;
using System.Collections;

public struct PartyStatus
{
    public CharacterStatus[] member;
    public float total_HP;
    public float total_MP;
}

public struct CharacterStatus
{
    public int index;
    public float My_exp;
    public float My_Level;

    public int char_ID;
    public string char_name;
    public string char_hanname;
    public float char_HP;
    public float char_MP;
    public float char_ATK;
    public float char_SPD;
    public Attribute attribute;
   
    public int Askill_num;
    public float Askill_MP;
    public string Askill_name;
    public string Askill_info;

    public int bullet_num;

    public BulletMove bullet_move_type;
    public HitType bullet_hit_type;
    public float bullet_SPD;
    public float bullet_size;

    public int shooting_way;
    public int shooting_amount;
    public int shooting_repeat;
    public float shooting_period;
    public float shooting_delay;
    public float shooting_angle;
}

public struct EnemyStatus
{
    public Enemy name;
    public float ATK;
    public float HP;
    public float DEF;
    public float SPD;
    public int coin_amount;
    public int score;

    public EnemyStatus(Enemy name_, float ATK_, float HP_, float DEF_, float SPD_, int coin_amount_, int score_)
    {
        name = name_;
        ATK = ATK_;
        HP = HP_;
        DEF = DEF_;
        SPD = SPD_;
        coin_amount = coin_amount_;
        score = score_;
    }
}