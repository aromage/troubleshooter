using UnityEngine;
using System.Collections;

public abstract class CBullet : MonoBehaviour
{
    public float ATK;
    protected float lifetime = 8f;
    int hit_count = 0;
    public float bullet_SPD;

    public Vector3 moved_pos;
    public Attribute attribute;
    public BulletPhase bullet_phase;
    public HitType hit_type;
    public State bullet_state;

    public void SetBullet(Attribute attribute_, HitType hit_type_, float SPD_, float ATK_, State state_)
    {
        attribute = attribute_;
        hit_type = hit_type_;
        bullet_SPD = SPD_;
        ATK = ATK_;
        bullet_state = state_;
    }

    public virtual void OnEnable()
    {
        bullet_phase = BulletPhase.LIVE;
        if (GetComponent<ParticleSystem>() != null)
        {
            
        }
        Invoke("DisableBullet",lifetime);
    }

    public virtual void OnDisable()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
        CancelInvoke();
    }

    public void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    public virtual void Move() { }

    // Update is called once per frame
    void Update()
    {
        switch(bullet_phase)
        {
            case BulletPhase.LIVE:
                Move();
                break;
            case BulletPhase.MISS:
                DisableBullet();
                break;
            case BulletPhase.HIT:
                GameObject hit_effect;
                switch (attribute)
                {
                    case Attribute.FIRE:
                        hit_effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("hit_fire"));
                        hit_effect.transform.position = gameObject.transform.position;
                        break;
                    case Attribute.NATURE:
                        hit_effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("hit_leaf"));
                        hit_effect.transform.position = gameObject.transform.position;
                        break;
                    case Attribute.AQUA:
                        hit_effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("hit_water"));
                        hit_effect.transform.position = gameObject.transform.position;
                        break;
                }
                switch (hit_type)
                {
                    case HitType.NORMAL:
                        DisableBullet();
                        break;
                    case HitType.PIERCE:
                        bullet_phase = BulletPhase.LIVE;
                        break;
                    case HitType.BOOMING:
                        GameObject bomb = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
                      	bomb.transform.position = gameObject.transform.position;
                      	bomb.AddComponent<bullet_hit_booming_>();
                      	bomb.AddComponent<CircleCollider2D>().isTrigger = true;
                      	bomb.AddComponent<Rigidbody2D>().isKinematic = true;
                        bomb.GetComponent<bullet_hit_booming_>().ATK = ATK;
                        bomb.GetComponent<bullet_hit_booming_>().attribute = attribute;
                        DisableBullet();
                        break;
                    case HitType.GUARD:
                        break;
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        string tag = coll.gameObject.tag;

        switch (gameObject.tag)
        {
            case "bullet":
                if (BossManager1.boss_state == Ifrit.BossState.EnergyBall)
                {
                    if (tag == "energy_ball")
                        bullet_phase = BulletPhase.HIT;
                    return;
                }
                
                if (tag == "enemy" || tag == "boss" || tag == "boss_part" || tag == "boss_element")
                {
                    coll.gameObject.SendMessage("ApplyDamage", new float[2] { ATK, (float)attribute });
                    coll.gameObject.SendMessage("ApplyState", new float[3] { (float)bullet_state, 0.1f, 3f});
                    bullet_phase = BulletPhase.HIT;
                }
            break;
            case "bullet_enemy":
                if (coll.gameObject.tag == "player")
                {
                    coll.gameObject.SendMessage("ApplyDamage", ATK);
                    bullet_phase = BulletPhase.HIT;
                }
                else if (coll.gameObject.tag == "shield")
                {
                    bullet_phase = BulletPhase.HIT;
                }
            break;
        }
    }
}
