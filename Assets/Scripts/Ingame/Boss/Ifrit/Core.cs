using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	[SerializeField]
	GameObject boss;
	[SerializeField]
	enemyShooter shooter;

	void Awake()
	{
        shooter.SetBulletInfo(666, (Attribute)0, (HitType)0, 300f, 0.05f, State.NONE, 15f);
		shooter.SetShooitngInfo(40, 1, 10, 0.1f, 0.1f, 359f);
	}

	// Use this for initialization
	void Start () {

	}

	void OnEnable()
	{
		shooter.StartShooting();
	}

	// Update is called once per frame
	void Update () {
		transform.position = boss.transform.position + new Vector3(0f, 15f, 0f);
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "player")
			boss.GetComponent<Ifrit>().DestroyBoss();
	}
}
