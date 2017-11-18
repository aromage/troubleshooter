using UnityEngine;
using System.Collections;

public class bullet_hit_booming_ : MonoBehaviour {

	CircleCollider2D thisiscollider;
    public float ATK;
    public Attribute attribute;

	// Use this for initialization
	void Start () {
        tag = "bullet";
		thisiscollider = transform.GetComponent<CircleCollider2D>();
		thisiscollider.radius = 85f;
        StartCoroutine(Boom());
	}

	public IEnumerator Boom()
	{
		yield return new WaitForSeconds(0.45f);
        DestroyImmediate(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (BossManager1.boss_state != Ifrit.BossState.EnergyBall)
        {
            if (coll.tag == "enemy" || coll.tag == "boss" || coll.tag == "boss_part" || coll.tag == "boss_element")
            {
                coll.gameObject.SendMessage("ApplyDamage", new float[2] { ATK, (float)attribute });
            }
        }
    }
}
