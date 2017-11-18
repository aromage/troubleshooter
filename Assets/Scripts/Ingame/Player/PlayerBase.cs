using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour
{
    //캐릭터 고유 값
    public int index;
    public string char_name;
    public float char_HP;
    public float char_MP;
    public float char_ATK;
    public float char_SPD;
    public Attribute attribute;

    public int skill_num;
    public float skill_MP;
    
    public BulletMove bullet_move;
    public HitType bullet_hit_type;
    public float bullet_size;
    public float bullet_SPD;
    public State bullet_state;
    
    public int shooting_way;
    public int shooting_amount;
    public int shooting_repeat;
    public float shooting_period;
    public float shooting_delay;
    public float shooting_angle;

    public myShooter shooter;

    public Position position;

    public IEnumerator Kiraring()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.06f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public virtual void StartShooting() { }

    public virtual void StopShooting() { }
}
