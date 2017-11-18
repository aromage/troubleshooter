using UnityEngine;
using System.Collections;

public partial class IceWitch {

	public enum IceWitchState
	{
		Intro,
		Appearing,
		State_1,
		State_2,
		State_3,
		State_4,
		Overwhelming,
		Overwhelming_ready,
		Destroying
	}

	IEnumerator Intro()
	{
		BossManager2.boss_state = IceWitchState.State_1;

		StartCoroutine("FSM");

		GameObject.Find("HudManager").SendMessage("Boss_Hp_Create", gameObject);
		GameObject.Find("StageManager").SendMessage("OnBossAppeared");

		yield break;
	}

	IEnumerator FSM()
	{
		while (true)
		{
			switch(BossManager2.boss_state)
			{
			case IceWitchState.Appearing:
				break;
			case IceWitchState.State_1:
				yield return StartCoroutine(State_1());
				break;
			case IceWitchState.State_2:
				yield return StartCoroutine(State_2());
				break;
			case IceWitchState.State_3:
				yield return StartCoroutine(State_3());
				break;
			case IceWitchState.State_4:
				yield return StartCoroutine(State_4());
				break;
			case IceWitchState.Destroying:
				yield return StartCoroutine(Destroying());
				yield break;
			default:
				yield break;
			}

			yield return null;
		}
	}

	IEnumerator State_1()
	{
		if(HP / max_HP < 0.8)
		{
			BossManager2.boss_state = IceWitchState.State_2;
			yield break;
		}

		yield return null;

		float random = Random.Range(0f, 1f);
		if (random < 0.4f)
		{
			yield return StartCoroutine(Move_1());
			yield return StartCoroutine(Shoot_1());
		}
		else
		{
			yield return StartCoroutine(Move_2());
			yield return StartCoroutine(Shoot_2());
		}
	}

	IEnumerator State_2()
	{
		if(HP / max_HP < 0.5)
		{
			BossManager2.boss_state = IceWitchState.State_3;
			yield break;
		}

		yield return null;

		float random = Random.Range(0f, 1f);
		if (random < 0.2f)
		{
			StartCoroutine(Shoot_1());
			yield return StartCoroutine(Move_1());
			StartCoroutine(Summon_1());
		}
		else if (random < 0.8f)
		{
			StartCoroutine(Shoot_2());
			yield return StartCoroutine(Move_2());
		}
		else
		{
			yield return StartCoroutine(Move_3());
			yield return StartCoroutine(Swing_1());
		}
	}

	IEnumerator State_3()
	{
		if(HP / max_HP < 0.2)
		{
			BossManager2.boss_state = IceWitchState.State_4;
			yield break;
		}

		yield return null;

		yield return StartCoroutine(Move_3());
		yield return StartCoroutine(Overwhelming());

		// TODO: Check and Expose core

		float random = Random.Range(0f, 1f);
		if (random < 0.3f)
		{
			StartCoroutine(Shoot_2(2));
			yield return StartCoroutine(Move_2());
		}
		else
		{
			yield return StartCoroutine(Move_3());
			yield return StartCoroutine(Swing_2());
		}
	}

	IEnumerator State_4()
	{
		if (HP <= 0)
		{
			BossManager2.boss_state = IceWitchState.Destroying;
			yield break;
		}

		yield return null;

		float random;

		while ((random = Random.Range(0f, 1f)) < 0.1f)
		{
			yield return new WaitForSeconds(3f);
			StartCoroutine(Raise());
		}

		if (random < 0.7f)
		{
			StartCoroutine(Shoot_1(2));
			StartCoroutine(Shoot_2(2));
			yield return StartCoroutine(Move_2());

			StartCoroutine(Summon_1());
			StartCoroutine(Summon_2());
		}
		else
		{
			yield return StartCoroutine(Move_3());
			yield return StartCoroutine(Swing_2());
		}
	}

	float GetDuration()
	{
		switch(BossManager2.boss_state)
		{
		case IceWitchState.State_1:
			return 2f;
		case IceWitchState.State_2:
			return 2f;
		case IceWitchState.State_3:
			return 1.5f;
		case IceWitchState.State_4:
			return 1f;
		default:
			return 2f;
		}
	}

	IEnumerator Move_1()
	{
		bool is_upper = (transform.position.y > 320f);
		float duration = GetDuration();

		GameObject player = GameObject.FindWithTag("player");

		Hashtable command = iTween.Hash();
		command.Add("position", new Vector3(((player != null)? player.transform.position.x : 0f), 
		                                    ((is_upper)? 200f : 400f), 0f));
		command.Add("time", duration);
		iTween.MoveTo(gameObject, command);
		
		yield return new WaitForSeconds(duration);
	}

	IEnumerator Move_2()
	{
		bool is_upper = (transform.position.y > 320f);
		float duration = GetDuration();

		float target_x;
		float random = Random.Range(0f, 3f);
		if (random < 1f)
			target_x = -400f;
		else if (random < 2f)
			target_x = 0f;
		else
			target_x = 400f;

		Hashtable command = iTween.Hash();
		command.Add("position", new Vector3(target_x, ((is_upper)? 200f : 400f), 0f));
		command.Add("time", duration);

		iTween.MoveTo(gameObject, command);

		yield return new WaitForSeconds(duration);
	}

	IEnumerator Move_3()
	{
		bool is_upper = (transform.position.y > 320f);
		float duration = GetDuration();

		Hashtable command = iTween.Hash();
		command.Add("amount", 200f * ((is_upper)? Vector3.down : Vector3.up));
		command.Add("time", duration);

		iTween.MoveBy(gameObject, command);

		yield return new WaitForSeconds(duration);
	}

	IEnumerator Shoot_1(int repeat = 1)
	{
		for (int i = 0; i < 5 * repeat; i++)
		{
			shooter[0].ShootOnce();
			yield return new WaitForSeconds(0.15f);
		}
	}

	IEnumerator Shoot_2(int repeat = 1)
	{
		for (int i = 0; i < 5 * repeat; i++)
		{
			shooter[1].ShootOnce();
			yield return new WaitForSeconds(0.15f);
		}
	}

	IEnumerator Swing_1()
	{
		shooter[2].StartShooting();
		yield return new WaitForSeconds(0.75f);
		shooter[2].StopShooting();
	}

	IEnumerator Swing_2()
	{
		shooter[3].StartShooting();
		yield return new WaitForSeconds(1.65f);
		shooter[3].StopShooting();
	}

	IEnumerator Raise()
	{
		for (int count = 1; count <= 4; count++)
		{
			if (count == 1)
				Instantiate(ResourceLoad.PickGameObject("IceMass1"),
				                               new Vector3(0f, 400f, 0f), Quaternion.identity);
			else
			{
				int offset = 1200 / (count + 1);

				for (int i = 0; i < count; i++)
				{
					int random = (int)Random.Range(1f, 4f);
					if (random == 4)
						random = 3;
					Instantiate(ResourceLoad.PickGameObject("IceMass" + random), 
					                               new Vector3(offset * (i + 1) - 600f, 400f, 0f), Quaternion.identity);
				}
			}

			yield return new WaitForSeconds(2f);
		}
	}

	IEnumerator Summon_1()
	{
		StartCoroutine (SummonEnemy (1, Enemy.Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0f, 2000f, 300f, 0f, 0.5f, 1)); //sho
        StartCoroutine(SummonEnemy(1, Enemy.Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0f, 2000f, 300f, 0f, 0.5f, 1)); //sho

		yield break;
	}

	IEnumerator Summon_2()
	{
		StartCoroutine (SummonEnemy (1, Enemy.Bat_A, CEnemy.AI.RE_T, CEnemy.StartPosition.T2, 0f, 5000f, 800f));
        StartCoroutine(SummonEnemy(1, Enemy.Bat_A, CEnemy.AI.RE_T, CEnemy.StartPosition.T6, 0f, 5000f, 800f));

		yield break;
	}

	IEnumerator SummonEnemy(int number_of_summon,
	                        Enemy monster,
	                        CEnemy.AI AI_type,
	                        CEnemy.StartPosition start_position,
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
			GameObject temp = (GameObject)Instantiate(enemy, CEnemy.GetStartPosition(start_position), Quaternion.identity);
			CEnemy temp_enemy = temp.GetComponent<CEnemy>();
			temp_enemy.Initialize(AI_type, ATK, HP, speed, defense, shooter_num,0,100);
			
			yield return new WaitForSeconds(delay);
		}
	}

	int hit_counter;
	IEnumerator Overwhelming()
	{
		BossManager2.boss_state = IceWitchState.Overwhelming_ready;

		mirror.StopAllCoroutines();
		mirror.GetComponent<Renderer>().material.color = Color.white;

		Hashtable command_out = new Hashtable();
		command_out.Add("alpha", 0f);
		command_out.Add("time", 1f);
		command_out.Add("includechildren", false);

		iTween.MoveTo(gameObject, new Vector3(0f, transform.position.y), 1f);

		yield return new WaitForSeconds(1f);

		iTween.Stop(gameObject);
		transform.position = new Vector3(0f, transform.position.y);

		StartCoroutine(Raise());

		GetComponent<Renderer>().material.color = Color.white;
		iTween.FadeTo(gameObject, command_out); // Fade Out

		yield return new WaitForSeconds(1f);

		iTween.Stop(gameObject);

		StopCoroutine("Animator");
		sprite_renderer.sprite = witch_in_mirror;

		BoxCollider2D temp_coll = gameObject.GetComponent<BoxCollider2D>();
		temp_coll.offset = new Vector2(31.6f, 59.6f);
		temp_coll.size = new Vector2(200f, 200f);


		Color temp = GetComponent<Renderer>().material.color;
		temp.a = 1f;
		GetComponent<Renderer>().material.color = temp;

		GetComponent<Renderer>().material.color = Color.white;
		iTween.Init(gameObject);
		iTween.FadeFrom(gameObject, command_out); // Fade In

		yield return new WaitForSeconds(1f);

		mirror.gameObject.SetActive(false);

		iTween.Stop(gameObject);
		temp = GetComponent<Renderer>().material.color;
		temp.a = 1f;
		GetComponent<Renderer>().material.color = temp;

		hit_counter = 0;
		float duration = 15f;
		BossManager2.boss_state = IceWitchState.Overwhelming;
		while (hit_counter < 100 && duration > 0f)
		{
			yield return null;
			duration -= Time.deltaTime;
		}
		BossManager2.boss_state = IceWitchState.Overwhelming_ready;

		GetComponent<Renderer>().material.color = Color.white;

//		if (duration > 0f)
			// TODO: Expose Core

		mirror.gameObject.SetActive(true);

		GetComponent<Renderer>().material.color = Color.white;
		iTween.FadeTo(gameObject, command_out); // Fade Out

		yield return new WaitForSeconds(1f);

		iTween.Stop(gameObject);
		StartCoroutine("Animator");

		temp_coll = gameObject.GetComponent<BoxCollider2D>();
		temp_coll.offset = new Vector2();
		temp_coll.size = new Vector2(300f, 400f);

		temp = GetComponent<Renderer>().material.color;
		temp.a = 1f;
		GetComponent<Renderer>().material.color = temp;

		GetComponent<Renderer>().material.color = Color.white;
		iTween.Init(gameObject);
		iTween.FadeFrom(gameObject, command_out); // Fade In

		yield return new WaitForSeconds(1f);

		iTween.Stop(gameObject);
		temp = GetComponent<Renderer>().material.color;
		temp.a = 1f;
		GetComponent<Renderer>().material.color = temp;

//		StartCoroutine("Animator");

		BossManager2.boss_state = IceWitchState.State_3;
	}

	IEnumerator Destroying()
	{
		DestroyBoss();
		
		yield break;
	}
}
