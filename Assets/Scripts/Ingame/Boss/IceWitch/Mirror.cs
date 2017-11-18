using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {

	[SerializeField]
	IceWitch ice_witch;

	enemyShooter[] shooter = new enemyShooter[3];

	void OnEnable()
	{
        ////Debug.log("enable");
        AddShooter();
		transform.localPosition = new Vector3(31.6f, 59.6f, 0.01f);

		if (BossManager2.mirror_state != MirrorState.Intro)
		{
		    for (int i = 0; i < 3; i++)
		    {
                shooter[i].Init(gameObject);
		    }
				
			shooter[0].StartAiming();
		}

		StartCoroutine(Intro());
	}

	void AddShooter()
	{
		GameObject[] shooter_object = new GameObject[3];
		
		for (int i = 0; i < 3; i++)
		{
			shooter_object[i] = new GameObject();
			shooter_object[i].AddComponent<enemyShooter>();
			shooter_object[i].name = "EnemyShooter";
			shooter[i] = shooter_object[i].GetComponent<enemyShooter>();
			shooter[i].Init(gameObject);
		}
		shooter[0].SetBulletInfo(700, (Attribute)0, (HitType)0, 200f, 0.15f, State.NONE, 15f);
		shooter[0].SetShooitngInfo(1, 1, 1, 2f, 2f, 50f);
		shooter[0].StartAiming();
		
		shooter[1].SetBulletInfo(700, (Attribute)0, (HitType)0, 200f, 0.15f, State.NONE, 15f);
		shooter[1].SetShooitngInfo(3, 8, 1, 2f, 1.5f, 45f);

		shooter[2].SetBulletInfo(700, (Attribute)0, (HitType)0, 200f, 0.2f, State.NONE, 15f);
		shooter[2].SetShooitngInfo(1, 8, 2, 2f, 1f, 50f);
	}
	
	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{

	}

	void ApplyDamage(float[] damage) // {damage, attribute)
	{

	}

	public void StartKiraring() 
	{
		StartCoroutine(Kiraring());
	}
	
	IEnumerator Kiraring()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(0.06f);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}

	public enum MirrorState
	{
		Intro,
		Appearing,
		State_1,
		State_2,
		State_3,
		Destroying
	}

	IEnumerator Intro()
	{
		BossManager2.mirror_state = MirrorState.State_1;

		while (BossManager2.boss_state == IceWitch.IceWitchState.Overwhelming ||
		       BossManager2.boss_state == IceWitch.IceWitchState.Overwhelming_ready)
			yield return null;
		
		StartCoroutine("FSM");
		
		yield break;
	}

	IEnumerator FSM()
	{
		while (true)
		{
			switch(BossManager2.mirror_state)
			{
			case MirrorState.Appearing:
				break;
			case MirrorState.State_1:
				yield return StartCoroutine(State_1());
				break;
			case MirrorState.State_2:
				yield return StartCoroutine(State_2());
				break;
			case MirrorState.State_3:
				yield return StartCoroutine(State_3());
				break;
			case MirrorState.Destroying:
				yield break;
			default:
				yield break;
			}
			
			yield return null;
		}
	}

	IEnumerator State_1()
	{
		if (ice_witch.HP / ice_witch.max_HP < 0.6)
		{
			shooter[0].StopShooting();
			BossManager2.mirror_state = MirrorState.State_2;
			yield break;
		}

		yield return null;

		shooter[0].StartShooting();
	}

	IEnumerator State_2()
	{
		if (ice_witch.HP / ice_witch.max_HP < 0.2)
		{
			shooter[1].StopShooting();
			BossManager2.mirror_state = MirrorState.State_3;
			yield break;
		}

		yield return null;

		shooter[1].StartShooting();
	}

	IEnumerator State_3()
	{
		if (ice_witch.HP <= 0f)
		{
			shooter[2].StopShooting();
			BossManager2.mirror_state = MirrorState.Destroying;
			yield break;
		}

		yield return null;

		shooter[2].StartShooting();
	}
}
