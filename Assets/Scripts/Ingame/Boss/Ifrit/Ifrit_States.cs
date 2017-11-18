using UnityEngine;
using System.Collections;

public partial class Ifrit {

	public enum BossState
	{
		Intro,
		Diverge,
		State_1,
		State_2,
		State_3,
		State_4,
		State_5,
		State_6,
		Shooting1,
		Shooting2,
		BothRocketPunch,
		RocketPunch,
		Laser,
		ArmRegeneration_4,
		ArmRegeneration_5,
		EnergyBall,
		Destroying,
		Destroyed
	}

	bool core_exposed;

	IEnumerator FSM()
	{
		StartCoroutine(Counter());

		while(true)
		{
			switch(BossManager1.boss_state)
			{
			case BossState.Diverge:
				yield return StartCoroutine(Diverge());
				break;
			case BossState.State_1:
				yield return StartCoroutine(State_1());
				break;
			case BossState.State_2:
				yield return StartCoroutine(State_2());
				break;
			case BossState.State_3:
				yield return StartCoroutine(State_3());
				break;
			case BossState.State_4:
				yield return StartCoroutine(State_4());
				break;
			case BossState.State_5:
				yield return StartCoroutine(State_5());
				break;
			case BossState.State_6:
				yield return StartCoroutine(State_6());
				break;
			case BossState.Shooting1:
				yield return StartCoroutine(Shooting1());
				break;
			case BossState.Shooting2:
				yield return StartCoroutine(Shooting2());
				break;
			case BossState.BothRocketPunch:
				yield return StartCoroutine(BothRocketPunch());
				break;
			case BossState.RocketPunch:
				yield return StartCoroutine(RocketPunch());
				break;
			case BossState.Laser:
				yield return StartCoroutine(Laser());
				break;
			case BossState.ArmRegeneration_4:
				yield return StartCoroutine(ArmRegeneration_4());
				break;
			case BossState.ArmRegeneration_5:
				yield return StartCoroutine(ArmRegeneration_5());
				break;
			case BossState.EnergyBall:
				yield return StartCoroutine(EnergyBall());
				break;
			case BossState.Destroying:
				yield break;
			case BossState.Destroyed:
				yield break;
			}

			yield return null;
		}
	}

	IEnumerator State_1()
	{
		StartBreathing();
		left_shoulder.StartBreathing();

		if (core_exposed)
		{
			BossManager1.boss_state = BossState.State_6;
			yield break;
		}

		if (HP / max_HP < 0.75)
		{
			BossManager1.boss_state = BossState.State_2;
			yield break;
		}

		if (!left_arm.gameObject.activeSelf || !right_arm.gameObject.activeSelf)
		{
			BossManager1.boss_state = BossState.State_3;
			yield break;
		}

		yield return null;

		BossManager1.boss_state = BossState.Shooting1;
	}

	IEnumerator State_2()
	{
		StartBreathing();
		left_shoulder.StartBreathing();

		if (core_exposed)
		{
			BossManager1.boss_state = BossState.State_6;
			yield break;
		}

		if (HP / max_HP < 0.1)
		{
			BossManager1.boss_state = BossState.State_5;
			yield break;
		}

		if (!left_arm.gameObject.activeSelf || !right_arm.gameObject.activeSelf)
		{
			BossManager1.boss_state = BossState.State_3;
			yield break;
		}

		yield return null;

		float random = Random.Range(0f, 2f);
		if (random > 1f)
			BossManager1.boss_state = BossState.Shooting2;
		else
			BossManager1.boss_state = BossState.BothRocketPunch;
	}

	IEnumerator State_3()
	{
		StartBreathing();
		left_shoulder.StartBreathing();

		if (!left_arm.gameObject.activeSelf && !right_arm.gameObject.activeSelf)
		{
			BossManager1.boss_state = BossState.State_4;
			yield break;
		}

		yield return null;

		BossManager1.boss_state = BossState.RocketPunch;
	}

	bool laser_started;
	IEnumerator State_4()
	{
		StartBreathing();

		if (HP <= 0f)
		{
			StopCoroutine("FSM");
			yield break;
		}

		if (core_exposed)
		{
			StopCoroutine("ArmRegenerationCountDown");
			fifteen_seconds_taken = false;
			counting = false;

			if (laser_started)
			{
				left_shoulder.StartReturn();
				right_shoulder.StartReturn();

				laser_started = false;

				yield return new WaitForSeconds(3f);
			}

			BossManager1.boss_state = BossState.State_6;
			yield break;
		}

		yield return null;

		if (fifteen_seconds_taken)
		{
			fifteen_seconds_taken = false;

			if (laser_started)
			{
				left_shoulder.StartReturn();
				right_shoulder.StartReturn();
				
				laser_started = false;
				
				yield return new WaitForSeconds(3f);
			}

			BossManager1.boss_state = BossState.ArmRegeneration_4;
			yield break;
		}
		else
			BossManager1.boss_state = BossState.Laser;

		if (!counting)
			StartCoroutine("ArmRegenerationCountDown");
	}

	IEnumerator State_5()
	{
		StartBreathing();
		left_shoulder.StartBreathing();

		if (HP <= 0f)
		{
			StopCoroutine("FSM");

			yield break;
		}

		if (left_arm.gameObject.activeSelf && right_arm.gameObject.activeSelf)
		{
			yield return new WaitForSeconds(1.5f);
			BossManager1.boss_state = BossState.EnergyBall;
		}
		else if (!left_arm.gameObject.activeSelf && !right_arm.gameObject.activeSelf)
			BossManager1.boss_state = BossState.ArmRegeneration_5;
		else
		{
			if (left_arm.gameObject.activeSelf)
				left_arm.gameObject.SetActive(false);
			if (right_arm.gameObject.activeSelf)
				right_arm.gameObject.SetActive(false);

			yield return new WaitForSeconds(1f);

			BossManager1.boss_state = BossState.ArmRegeneration_5;
		}

		yield return null;
	}

	IEnumerator State_6()
	{
		StartBreathing();
		left_shoulder.StartBreathing();

		core.SetActive(true);

		gameObject.GetComponent<SpriteRenderer>().sprite = boss_destroyed;

		yield return new WaitForSeconds(5f);

		core.SetActive(false);
		gameObject.GetComponent<SpriteRenderer>().sprite = boss_normal;
		core_exposed = false;

		StartCoroutine(Counter());
		BossManager1.boss_state = BossState.State_1;
	}

	bool fifteen_seconds_taken;
	bool counting;
	IEnumerator ArmRegenerationCountDown()
	{
		counting = true;
		fifteen_seconds_taken = false;

		yield return new WaitForSeconds(15f);

		fifteen_seconds_taken = true;
		counting = false;
	}

	IEnumerator Shooting1()
	{
		left_hand.StartShooting();
		right_hand.StartShooting();

		yield return new WaitForSeconds(2f);

		left_hand.StopShooting();
		right_hand.StopShooting();

		BossManager1.boss_state = BossState.State_1;
	}

	IEnumerator Shooting2()
	{
		left_hand.StartShooting();
		right_hand.StartShooting();
		
		yield return new WaitForSeconds(2f);
		
		left_hand.StopShooting();
		right_hand.StopShooting();
		
		BossManager1.boss_state = BossState.State_2;
	}

	IEnumerator BothRocketPunch()
	{
		if (right_arm.gameObject.activeSelf)
		{
			right_arm.StartRocketPunch();
			left_hand.StartShooting();
		}

		yield return new WaitForSeconds(5f);

		left_hand.StopShooting();

		if (left_arm.gameObject.activeSelf)
		{
			left_arm.StartRocketPunch();
			right_hand.StartShooting();
		}

		yield return new WaitForSeconds(5f);

		right_hand.StopShooting();

		BossManager1.boss_state = BossState.State_2;
	}

	IEnumerator RocketPunch()
	{
		if (left_arm.gameObject.activeSelf)
			left_arm.StartRocketPunch();
		else if (right_arm.gameObject.activeSelf)
			right_arm.StartRocketPunch();

		SummonMonster();

		yield return new WaitForSeconds(5f);

		BossManager1.boss_state = BossState.State_3;
	}

	IEnumerator Laser()
	{
		if (!laser_started)
		{
			left_shoulder.StartShooter();
			right_shoulder.StartShooter();
			
			yield return new WaitForSeconds(3f);

			laser_started = true;
		}
		
		SummonMonster();
		SummonMonster();
		
		left_shoulder.StartShooting();
		
		yield return new WaitForSeconds(3f);

		BossManager1.boss_state = BossState.State_4;
	}

	IEnumerator ArmRegeneration_4()
	{
		left_arm.gameObject.SetActive(true);
		right_arm.gameObject.SetActive(true);

		yield return new WaitForSeconds(4f);

		BossManager1.boss_state = BossState.State_2;
	}

	IEnumerator ArmRegeneration_5()
	{
		left_arm.gameObject.SetActive(true);
		right_arm.gameObject.SetActive(true);
		
		yield return new WaitForSeconds(3f);
		
		BossManager1.boss_state = BossState.State_5;
	}

	bool energy_ball_completed;
	IEnumerator EnergyBall()
	{
		if (!left_arm.gameObject.activeSelf || !right_arm.gameObject.activeSelf)
		{
			BossManager1.boss_state = BossState.State_5;
			yield break;
		}

		left_arm.StartPillKill();
		right_arm.StartPillKill();
		
		while (!energy_ball_completed)
			yield return null;
		energy_ball_completed = false;

		BossManager1.boss_state = BossState.State_5;
	}

	void OnEnergyBallComplete()
	{
		energy_ball_completed = true;
	}

	IEnumerator Counter()
	{
		yield return new WaitForSeconds(80f);

		core_exposed = true;
	}

	void SummonMonster()
	{
		// TODO
	}
	
	IEnumerator Intro()
	{
		yield return new WaitForSeconds(1f);

		GameObject.Find("HudManager").SendMessage("Boss_Hp_Create", gameObject);

		Hashtable command = iTween.Hash("scale", new Vector3(1f, 1f, 1f), "time", 3f);
		iTween.ScaleTo(gameObject, command);

		yield return new WaitForSeconds(3f);
		transform.localScale = new Vector3(1f, 1f, 1f);

		BossManager1.boss_state = BossState.Diverge;
		StartCoroutine("FSM");
	}

	IEnumerator Diverge()
	{
		left_shoulder.Diverge();
		right_shoulder.Diverge();
		bottom.Diverge();

		yield return new WaitForSeconds(0.5f);

		left_arm.gameObject.SetActive(true);
		right_arm.gameObject.SetActive(true);

		yield return new WaitForSeconds(1f);

		//GameObject.Find("BossManager1").SendMessage("OnBossDiverseFinish");
        GameObject.Find("StageManager").SendMessage("BossDiverseFinish");
		BossManager1.boss_state = BossState.State_1;
	}
}