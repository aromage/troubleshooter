using UnityEngine;
using System.Collections;

public partial class Deathra {

	public enum DeathraState
	{
		Intro,
		Appearing,
		State_1,
		State_2,
		State_3,
		Overwhelming,
		Overwhelming_ready,
		Destroying
	}

	IEnumerator Intro()
	{
		BossManager3.boss_state = DeathraState.State_1;
		BossManager3.wing_state = WingState.State_1;

		StartCoroutine("FSM");
		StartCoroutine("WingFSM");
		
		GameObject.Find("HudManager").SendMessage("Boss_Hp_Create", gameObject);
		GameObject.Find("StageManager").SendMessage("OnBossAppeared");

		yield break;
	}

	IEnumerator FSM()
	{
		while (true)
		{
			switch(BossManager3.boss_state)
			{
			case DeathraState.State_1:
				yield return StartCoroutine(State_1());
				break;
			case DeathraState.State_2:
				yield return StartCoroutine(State_2());
				break;
			case DeathraState.State_3:
				yield return StartCoroutine(State_3());
				break;
			case DeathraState.Destroying:
				yield return StartCoroutine(Destroying());
				yield break;
			default:
				yield break;
			}
			
			yield return null;
		}
	}

    float a;
	IEnumerator State_1()
	{
		if(HP / max_HP < 0.999f)
		{
			BossManager3.boss_state = DeathraState.State_2;
			yield break;
		}

		// TODO: Image Change

		yield break;
	}

	IEnumerator State_2()
	{
		if(HP / max_HP < 0.3f)
		{
			BossManager3.boss_state = DeathraState.State_3;
			yield break;
		}

		int counter = 0;
		float random;
		while (counter != 3)
		{
			yield return new WaitForSeconds(0.5f);

			random = Random.Range(0f, 1f);
			if (random < 0.3f)
				yield return new WaitForSeconds(1f);
			else 
//				yield return StartCoroutine(EyeLaser());

			counter++;
		}

		yield return new WaitForSeconds(0.5f);

		random = Random.Range(0f, 3f);
		if (random < 1f)
			attribute = Attribute.FIRE;
		else if (random < 2f)
			attribute = Attribute.NATURE;
		else
			attribute = Attribute.AQUA;
		SetAttributeIndex();

		gameObject.GetComponent<SpriteRenderer>().sprite = normal_body[attribute_index];
		chin.gameObject.GetComponent<SpriteRenderer>().sprite = normal_chin[attribute_index];
	}

	IEnumerator State_3()
	{
		attribute = Attribute.FIRE;
		SetAttributeIndex();
		chin.GetComponent<SpriteRenderer>().sprite = broken_chin[attribute_index];

//		StartCoroutine("EyeLaserRepeater");

		while (true)
		{
			if(HP <= 0f)
			{
				BossManager3.boss_state = DeathraState.Destroying;
				StopCoroutine("EyeLaserRepeater");
				yield break;
			}

			yield return new WaitForSeconds(0.5f);

			float random = Random.Range(0f, 1f);
			if (random < 0.5f)
				yield return StartCoroutine(MouthLaser());
			else
			{
				// TODO: Shout (3 sec)
			}
		}
	}

	IEnumerator Destroying()
	{
		DestroyBoss();
		
		yield break;
	}

	IEnumerator EyeLaser()
	{
		left_eye_laser.SetActive(true);
		right_eye_laser.SetActive(true);

		DeathraEyeLaser left_laser = left_eye_laser.GetComponent<DeathraEyeLaser>();
		DeathraEyeLaser right_laser = right_eye_laser.GetComponent<DeathraEyeLaser>();

		left_laser.StartShooting();
		right_laser.StartShooting();

		yield return new WaitForSeconds(3.85f);

		left_laser.FadeOut();
		right_laser.FadeOut();

		yield return new WaitForSeconds(0.15f);
		
		left_eye_laser.SetActive(false);
		right_eye_laser.SetActive(false);
	}

	IEnumerator EyeLaserRepeater()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			yield return StartCoroutine(EyeLaser());
		}
	}

	IEnumerator MouthLaser()
	{
		chin.GetComponent<DeathraChin>().OpenMouth();
		yield return new WaitForSeconds(0.5f);

		mouth.SetActive(true);
		PlayLaserAnimation();

		yield return new WaitForSeconds(1.45f);

		mouth.SetActive(false);

		chin.GetComponent<DeathraChin>().CloseMouth();
		yield return new WaitForSeconds(0.5f);
	}

	void PlayLaserAnimation()
	{
		string state_name;
		
		switch(attribute)
		{
		case Attribute.FIRE:
			state_name = "MouthFireLaser";
			break;
		case Attribute.NATURE:
			state_name = "MouthLeafLaser";
			break;
		case Attribute.AQUA:
			state_name = "MouthWaterLaser";
			break;
		default:
			return;
		}
		
		mouth.GetComponent<Animator>().Play(state_name);
	}
}
