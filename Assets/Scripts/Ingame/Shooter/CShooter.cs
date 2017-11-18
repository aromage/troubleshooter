using UnityEngine;
using System.Collections;

public abstract class CShooter : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] bullet_to_shoot;

    [SerializeField]
    protected int shooting_way;
    [SerializeField]
    protected int shooting_amount;
    [SerializeField]
    protected int shooting_repeat;
    [SerializeField]
    protected float shooting_period;
    [SerializeField]
    protected float shooting_delay;
    [SerializeField]
    protected float shooting_angle;
    [SerializeField]
    protected float[] way_angle;

    [SerializeField]
    public int bullet_num;
    [SerializeField]
    protected Attribute attribute;
    [SerializeField]
    protected HitType hit_type;
    [SerializeField]
    protected float bullet_SPD;
    [SerializeField]
    protected float bullet_ATK;
    [SerializeField]
    protected float bullet_size;
    [SerializeField]
    protected State bullet_state;
    [SerializeField]
	bool is_shooting;

    int j = 0;

    public float GetBulletATK()
    {
        return bullet_ATK;
    }

    public void SetBulletATK(float newATK)
    {
        bullet_ATK = newATK;
    }
    public void SetBulletInfo(int num_, Attribute attribute_, HitType hit_type_, float SPD_, float ATK_, State state_, float size_)
    {
        bullet_num = num_;
        attribute = attribute_;
        hit_type = hit_type_;
        bullet_SPD = SPD_;
        bullet_ATK = ATK_;
        bullet_state = state_;
        bullet_size = size_;
    }

    public void SetShooitngInfo(int way_, int amount_, int reapeat_, float period_, float delay_, float angle_)
    {
        shooting_way = way_;
        shooting_amount = amount_;
        shooting_repeat = reapeat_;
        shooting_period = period_;
        shooting_delay = delay_;
        shooting_angle = angle_;
        DefineWay();
    }

    public virtual void ShootOnce()
    {
        StartCoroutine("Shoot");
    }

    public void StartShooting()
    {
		if (!is_shooting)
		{
			is_shooting = true;
			InvokeRepeating("ShootOnce", 0.2f, shooting_period);
		}
    }

    public void StopShooting()
    {
		if (is_shooting)
		{
			is_shooting = false;
	        CancelInvoke();
            StopCoroutine("Shoot");
		}
    }

    void OnDisable()
    {
        StopShooting();
    }

    IEnumerator Shoot()
    {
        for (int k = 0; k < shooting_repeat; k++)
        {
            BulletEnabler();
            yield return new WaitForSeconds(shooting_delay);
        }
    }

    public void BulletEnabler()
    {
        bullet_to_shoot = new GameObject[shooting_amount];
        for (int i = 0; i < shooting_amount; i++)
        {
            bullet_to_shoot[i] = ResourceLoad.PickBulletPuller(bullet_num).GetUnusedBullet();
            bullet_to_shoot[i].GetComponent<CBullet>().SetBullet(attribute, hit_type, bullet_SPD, bullet_ATK, bullet_state);
            bullet_to_shoot[i].SetActive(true);
        }
        if (shooting_angle == 0)
        {
            for (int i = 0; i < shooting_amount; i++)
            {
                bullet_to_shoot[i].transform.position = gameObject.transform.position;
                bullet_to_shoot[i].transform.rotation = gameObject.transform.rotation;
                bullet_to_shoot[i].transform.Translate(new Vector3((j - ((shooting_way - 1) / 2)) * bullet_size, 0, 0));
                j++;
                if (j == shooting_way) j = 0;
            }
        }
        else
        {
            for (int i = 0; i < shooting_amount; i++)
            {
                bullet_to_shoot[i].transform.position = gameObject.transform.position;
                bullet_to_shoot[i].transform.rotation = gameObject.transform.rotation;
                bullet_to_shoot[i].transform.Rotate(0f, 0f, way_angle[j]);
                j++;
                if (j == shooting_way) j = 0;
            }
        }
    }

    public void DefineWay()
    {
        way_angle = new float[shooting_way];
        for(int i = 0; i < shooting_way; i++)
            way_angle[i] = (((shooting_angle * 2) / (shooting_way + 1)) * (i + 1)) - shooting_angle;
    }

	public bool IsShooting() { return is_shooting; }
}

