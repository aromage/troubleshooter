using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBulletPooler : ScriptableObject
{
    protected GameObject pooled_bullet;
    protected int pooled_amount;
    protected bool extend = true;
    GameObject temp_obj;
    
    protected List<GameObject> pooled_bullets = new List<GameObject>();

    public void PoolBullet(CharacterStatus character, int amount_ = 10)
    {
        pooled_amount = amount_;

        temp_obj = new GameObject();
        temp_obj.SetActive(false);
        temp_obj.name = "bullet_" + character.char_name;
        temp_obj.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bullet/bullet_"+character.char_name);
        temp_obj.GetComponent<SpriteRenderer>().sortingLayerName = "Bullet";
        temp_obj.AddComponent<CircleCollider2D>().radius = character.bullet_size;
        temp_obj.GetComponent<CircleCollider2D>().isTrigger = true;
        
        SetMove(temp_obj,character.bullet_move_type);
        SetParticle(temp_obj,character.attribute);

        for (int i = 0; i < pooled_amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(temp_obj,new Vector3(4000,0,0),Quaternion.identity);
            pooled_bullets.Add(obj);
        }
    }

    public void PoolBullet(string bullet_name_, BulletMove bullet_move_, int amount_ = 50)
    {
        pooled_amount = amount_;

        temp_obj = new GameObject();
        temp_obj.SetActive(false);
        temp_obj.name = bullet_name_;
        temp_obj.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Bullet/" + bullet_name_);
        temp_obj.GetComponent<SpriteRenderer>().sortingLayerName = "Bullet";
        temp_obj.AddComponent<CircleCollider2D>().radius = 25f;
        temp_obj.GetComponent<CircleCollider2D>().isTrigger = true;
        SetMove(temp_obj, bullet_move_);

        for (int i = 0; i < pooled_amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(temp_obj, new Vector3(4000, 0, 0), Quaternion.identity);
            pooled_bullets.Add(obj);
        }
    }

    void SetMove(GameObject bullet, BulletMove bullet_move_)
    {
        switch (bullet_move_)
        {
            case BulletMove.STRAIGHT:
                bullet.AddComponent<bullet_straight>();
                break;
            case BulletMove.HOMING:
                bullet.AddComponent<bullet_homing>();
                break;
            case BulletMove.ENEMY_STRAIGHT:
                bullet.AddComponent<bullet_enemy_straight>();
                break;
            case BulletMove.ENEMY_HOMING:
                bullet.AddComponent<bullet_enemy_homing>();
                break;
            case BulletMove.STRAIGHT_2:
                bullet.AddComponent<bullet_straingt_2>();
                break;
        }
    }
    void SetParticle(GameObject bullet, Attribute attribute_)
    {
        switch (attribute_)
        {
            case Attribute.AQUA:
                NGUITools.AddChild(bullet,Resources.Load<GameObject>("Prefabs/Bullet/bullet_particle_A"));
                break;
            case Attribute.FIRE:
                NGUITools.AddChild(bullet,Resources.Load<GameObject>("Prefabs/Bullet/bullet_particle_F"));
                break;
            case Attribute.NATURE:
                NGUITools.AddChild(bullet,Resources.Load<GameObject>("Prefabs/Bullet/bullet_particle_N"));
                break;
            case Attribute.DARK:
            case Attribute.LIGHT:
                break;
        }
    }

    public virtual GameObject GetUnusedBullet()
    {
        for (int i = 0; i < pooled_amount; i++)
        {
            if (!pooled_bullets[i].activeInHierarchy)
            {
                return pooled_bullets[i];
            }
        }

        if (extend)
        {
            GameObject obj = (GameObject)Instantiate(temp_obj, new Vector3(4000, 0, 0), Quaternion.identity);
            pooled_bullets.Add(obj);
            pooled_amount++;
            return obj;
        }
        return null;
    }
}
