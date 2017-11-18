using UnityEngine;
using System.Collections;

public partial class Deathra {

	public enum WingState
	{
		Intro,
		Appearing,
		State_1,
		State_2,
		State_3,
		Destroying
	}

	IEnumerator WingFSM()
	{
		while (true)
		{
			switch(BossManager3.boss_state)
			{
			case DeathraState.State_1:
				yield return StartCoroutine(WingState_1());
				break;
			case DeathraState.State_2:
				yield return StartCoroutine(WingState_2());
				break;
			case DeathraState.State_3:
				yield return StartCoroutine(WingState_3());
				break;
			case DeathraState.Destroying:
				yield break;
			default:
				yield break;
			}
			
			yield return null;
		}
	}

	IEnumerator WingState_1()
	{
		if(HP / max_HP < 0.5f)
		{
			BossManager3.wing_state = WingState.State_2;
			yield break;
		}

		if (BossManager3.boss_state == DeathraState.State_1)
			yield break;

		yield return new WaitForSeconds(0.5f);

		float random = Random.Range(0f, 1f);
		if (random < 0.5f)
			yield return StartCoroutine(Laser());
		else
			yield return StartCoroutine(Shoot_2());
	}

	IEnumerator WingState_2()
	{
		if(HP <= 0)
		{
			BossManager3.wing_state = WingState.State_3;
			yield break;
		}

		yield return new WaitForSeconds(0.5f);

		float random = Random.Range(0f, 1f);
		if (random < 0.5f)
			yield return StartCoroutine(Laser());
		else if (random < 0.7f)
			yield return StartCoroutine(Shoot_1());
		else if (random < 0.9f)
			yield return StartCoroutine(Shoot_2());
		else
			yield return StartCoroutine(Summon());
	}

	IEnumerator WingState_3()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = broken_body[attribute_index];

		BossManager3.wing_state = WingState.Destroying;

		yield break;
	}

	IEnumerator Shoot_1()
	{
		shooter[0].StartShooting();
		shooter[2].StartShooting();
		yield return new WaitForSeconds(1f);
		shooter[0].StopShooting();
		shooter[2].StopShooting();
	}

	IEnumerator Shoot_2()
	{
		shooter[1].StartShooting();
		shooter[3].StartShooting();
		yield return new WaitForSeconds(2f);
		shooter[1].StopShooting();
		shooter[3].StopShooting();
	}

	IEnumerator Laser()
	{
		left_wing_laser.SetActive(true);
		right_wing_laser.SetActive(true);

		DeathraWingLaser left_laser = left_wing_laser.GetComponent<DeathraWingLaser>();
		DeathraWingLaser right_laser = right_wing_laser.GetComponent<DeathraWingLaser>();

		left_laser.StartShooting();
		right_laser.StartShooting();

		yield return new WaitForSeconds(0.35f);

		left_laser.FadeOut();
		right_laser.FadeOut();

		yield return new WaitForSeconds(0.15f);

		left_wing_laser.SetActive(false);
		right_wing_laser.SetActive(false);
	}

	IEnumerator Summon()
	{
		for (int i = 0; i < 2; i++)
			StartCoroutine(SummonEnemy(1, 
			                           Enemy.Shooter_A, 
			                           CEnemy.AI.Wat, 
			                           i, 
			                           2000f, 300f, 0f, 0.5f, 2));

		yield return new WaitForSeconds(1f);
	}

	IEnumerator SummonEnemy(int number_of_summon,
	                        Enemy monster,
	                        CEnemy.AI AI_type,
	                        int start_position,
                            float ATK,
	                        float HP,
	                        float speed,
	                        float defense = 0,
	                        float delay = 0.5f,
	                        int shooter_num = 0)
	{
		GameObject enemy;
		
		enemy = ResourceLoad.PickGameObject(monster.ToString());
		
		for (int formation = 0; formation < number_of_summon; formation++)
		{
			GameObject temp = (GameObject)Instantiate(enemy,
			                                          (start_position == 0)? left_wing.transform.position : right_wing.transform.position,
			                                          Quaternion.identity);
			CEnemy temp_enemy = temp.GetComponent<CEnemy>();
			temp_enemy.Initialize(AI_type, ATK, HP, speed, defense, shooter_num,0,100);
			
			yield return new WaitForSeconds(delay);
		}
	}
}
