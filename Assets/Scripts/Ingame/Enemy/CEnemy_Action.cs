using UnityEngine;
using System.Collections;

public partial class CEnemy : MonoBehaviour
{
	void StartKeepFollowing(float time_limit)
	{
		StartCoroutine("DirectionChanger");
		StartCoroutine("KeepFollowing");
		StartCoroutine("FollowingStopper", time_limit);
	}

	void StopAllActions()
	{
		iTween.Stop(gameObject);

		StopCoroutine("DirectionChanger");
		StopCoroutine("KeepFollowing");
		StopCoroutine("FollowingStopper");

		StopCoroutine("Stop");
	}

	Vector3 following_direction;

	IEnumerator KeepFollowing()
	{
		while (true)
		{
			yield return null;

			transform.Translate(following_direction * speed * Time.deltaTime, Space.Self);
		}
	}

	IEnumerator DirectionChanger()
	{
		GameObject target = GameObject.FindWithTag("player");
	    if (target != null)
	    {
            while (true)
            {
                Vector3 diff = target.transform.position - transform.position;

                following_direction = (diff.x > 0f) ? Vector3.right : Vector3.left;

                if (Mathf.Abs(diff.x) < speed * 0.1f)
                    following_direction = Vector3.zero;

                yield return new WaitForSeconds(0.2f);
            }
	    }
	}

	IEnumerator FollowingStopper(float time_limit)
	{
		yield return new WaitForSeconds(time_limit);
		
		StopCoroutine("KeepFollowing");
		StopCoroutine("DirectionChanger");
		
		OnAIActionComplete();
	}

	void StopFor(float time_limit)
	{
		StartCoroutine("Stop", time_limit);
	}

	IEnumerator Stop(float time_limit)
	{
		yield return new WaitForSeconds(time_limit);

		OnAIActionComplete();
	}

	void StartExclamationMark()
	{
		StartCoroutine(ExclamationMark());
	}

	IEnumerator ExclamationMark()
	{
		Sprite exclamation = ResourceLoad.PickSprite("Exclamation");
		GameObject mark = new GameObject();

		Vector3 offset = new Vector3(35f, 40f, -0.01f);

		mark.transform.parent = transform;
		mark.transform.position = transform.position + offset;
		mark.name = "Exclamation Mark";

		SpriteRenderer render = mark.AddComponent<SpriteRenderer>();
		render.sprite = exclamation;
		render.sortingLayerName = "Enemy";

		iTween.ScaleFrom(mark, new Vector3(4f, 4f, 4f), 0.4f);

		float duration = 1f;
		while (duration > 0f)
		{
			mark.transform.position = transform.position + offset;

			duration -= Time.deltaTime;

			yield return null;
		}

		Destroy(mark);
	}

	private class Action
	{
		delegate void ActionDelegate();
		
		GameObject gameObject;
		float speed;
		
		float distance;
		float angle;
		
		Vector3[] path;
		
		string tag;
		
		Vector3 direction;

		float time_limit;

		CEnemy.AI AI_type;
		float HP;

		Vector3 point;

		ActionDelegate action;
		
		void Init(GameObject gameObject, float speed)
		{
			this.gameObject = gameObject;
			this.speed = speed;
		}

		/// <summary>
		/// MoveByTowards 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>MoveByTowards Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="speed">속력</param>
		/// <param name="distance">거리</param>
		/// <param name="angle">각도</param>
		public static Action ActionMoveByTowards(GameObject gameObject, float speed, float distance, float angle)
		{
			Action constructed_action = new Action();

			constructed_action.Init(gameObject, speed);

			constructed_action.distance = distance;
			constructed_action.angle = angle;

			constructed_action.action = constructed_action.MoveByTowards;

			return constructed_action;
		}

		/// <summary>
		/// MoveByPath 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>MoveByPath Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="speed">속력</param>
		/// <param name="path">경로</param>
		public static Action ActionMoveByPath(GameObject gameObject, float speed, Vector3[] path)
		{
			Action constructed_action = new Action();

			constructed_action.Init(gameObject, speed);

			constructed_action.path = path;

			constructed_action.action = constructed_action.MoveByPath;

			return constructed_action;
		}

		/// <summary>
		/// MoveTowards 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>MoveTowards Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="speed">속력</param>
		/// <param name="tag">Tag</param>
		public static Action ActionMoveTowards(GameObject gameObject, float speed, string tag)
		{
			Action constructed_action = new Action();
			
			constructed_action.Init(gameObject, speed);
			
			constructed_action.tag = tag;
			
			constructed_action.action = constructed_action.MoveTowards;
			
			return constructed_action;
		}

		/// <summary>
		/// MoveTo 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>MoveTo Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="speed">속력</param>
		/// <param name="point">목적지</param>
		public static Action ActionMoveTo(GameObject gameObject, float speed, Vector3 point)
		{
			Action constructed_action = new Action();

			constructed_action.Init(gameObject, speed);

			constructed_action.point = point;

			constructed_action.action = constructed_action.MoveTo;

			return constructed_action;
		}

		/// <summary>
		/// KeepGoing 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>KeepGoing Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="speed">속력</param>
		public static Action ActionKeepGoing(GameObject gameObject, float speed)
		{
			Action constructed_action = new Action();
			
			constructed_action.Init(gameObject, speed);
			
			gameObject.GetComponent<CEnemy>().InitDirectionUpdater(constructed_action.SetDirection);
			
			constructed_action.action = constructed_action.KeepGoing;
			
			return constructed_action;
		}

		/// <summary>
		/// KeepFollowing 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>KeepFollowing Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="time_limit">제한 시간</param>
		public static Action ActionKeepFollowing(GameObject gameObject, float time_limit)
		{
			Action constructed_action = new Action();
			
			constructed_action.gameObject = gameObject;

			constructed_action.time_limit = time_limit;
			
			constructed_action.action = constructed_action.KeepFollowing;
			
			return constructed_action;
		}

		/// <summary>
		/// Stop 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>Stop Action</returns>
		/// <param name="gameObject">Game Object</param>
		/// <param name="time_limit">제한 시간</param>
		public static Action ActionStop(GameObject gameObject, float time_limit)
		{
			Action constructed_action = new Action();

			constructed_action.gameObject = gameObject;

			constructed_action.time_limit = time_limit;

			constructed_action.action = constructed_action.Stop;

			return constructed_action;
		}

		/// <summary>
		/// ShootOnce 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>ShootOnce Action</returns>
		/// <param name="gameObject">Game Object</param>
		public static Action ActionShootOnce(GameObject gameObject)
		{
			Action constructed_action = new Action();

			constructed_action.gameObject = gameObject;
			constructed_action.action = constructed_action.ShootOnce;

			return constructed_action;
		}

		/// <summary>
		/// StartShooting 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>StartShooting Action</returns>
		/// <param name="gameObject">Game Object</param>
		public static Action ActionStartShooting(GameObject gameObject)
		{
			Action constructed_action = new Action();

			constructed_action.gameObject = gameObject;
			constructed_action.action = constructed_action.StartShooting;

			return constructed_action;
		}

		/// <summary>
		/// StopShooting 액션을 생성해서 리턴합니다.
		/// </summary>
		/// <returns>StopShooting Action</returns>
		/// <param name="gameObject">Game Object</param>
		public static Action ActionStopShooting(GameObject gameObject)
		{
			Action constructed_action = new Action();
			
			constructed_action.gameObject = gameObject;
			constructed_action.action = constructed_action.StopShooting;
			
			return constructed_action;
		}

		public static Action ActionSummonMonsters(GameObject gameObject, CEnemy.AI AI_type, float HP, float speed)
		{
			// TODO
			Action constructed_action = new Action();

			constructed_action.gameObject = gameObject;

			constructed_action.AI_type = AI_type;
			constructed_action.HP = HP;
			constructed_action.speed = speed;

			constructed_action.action = constructed_action.SummonMonsters;

			return constructed_action;
		}
		
		/// <summary>
		/// 지정된 Action을 수행합니다.
		/// </summary>
		public void Execute()
		{
			// stop all actions
			gameObject.GetComponent<CEnemy>().StopAllActions();

			action();
		}
		
		void MoveByTowards()
		{
			Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f);
			Hashtable command = iTween.Hash("amount", distance * direction, "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "OnAIActionComplete");
			
			iTween.MoveBy (gameObject, command);
		}
		
		void MoveByPath()
		{
			path = CalibratePath(path);
			
			Hashtable command = iTween.Hash("path", path, "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "OnAIActionComplete");
			
			iTween.MoveTo(gameObject, command);
		}
		
		void MoveTowards()
		{
			gameObject.GetComponent<CEnemy>().StartExclamationMark();

			Vector3 target = new Vector3(0f, -800f, 0f);
			
			if (tag == "player")
			{
				GameObject player = GameObject.FindWithTag("player");
				
				target = (player != null)? player.transform.position : new Vector3(0f, -800f, 0f);
			}
			
			Hashtable command = iTween.Hash("position", target, "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "OnAIActionComplete");
			
			iTween.MoveTo(gameObject, command);
		}
		
		void KeepGoing()
		{
			Hashtable command = iTween.Hash("amount", 1470f * direction, "speed", speed, "easetype", iTween.EaseType.linear/*, "oncomplete", "OnAIActionComplete"*/);
			
			iTween.MoveBy(gameObject, command);
		}

		void DestroyItself()
		{
			Destroy(gameObject);
		}

		void KeepFollowing()
		{
			gameObject.GetComponent<CEnemy>().StartKeepFollowing(time_limit);
		}

		void Stop()
		{
			gameObject.GetComponent<CEnemy>().StopFor(time_limit);
		}

		void SummonMonsters()
		{
			// TODO
			GameObject enemy = ResourceLoad.PickGameObject("fire_monster");

			GameObject temp = (GameObject)Instantiate(enemy, gameObject.transform.position + new Vector3(0f, -100f, 0f), Quaternion.identity);
			CEnemy temp_enemy = temp.GetComponent<CEnemy>();
//			temp_enemy.Initialize(Enemy.Eye_F, AI_type, HP, speed, 0, 0, 0, 0);

			gameObject.GetComponent<CEnemy>().OnAIActionComplete();
		}

		void ShootOnce()
		{
			CEnemy temp = gameObject.GetComponent<CEnemy>();
			temp.ShootOnce();
			temp.OnAIActionComplete();
		}

		void StartShooting()
		{
			CEnemy temp = gameObject.GetComponent<CEnemy>();
			temp.StartShooting();
			temp.OnAIActionComplete();
		}

		void StopShooting()
		{
			CEnemy temp = gameObject.GetComponent<CEnemy>();
			temp.StopShooting();
			temp.OnAIActionComplete();
		}

		void MoveTo()
		{
			Hashtable command = iTween.Hash("position", point, "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "OnAIActionComplete");
			
			iTween.MoveTo(gameObject, command);
		}


		/// <summary>
		/// 현재 gameObject의 위치에 맞게 경로 조정
		/// </summary>
		/// <returns>수정된 경로</returns>
		/// <param name="supplied_path">경로</param>
		Vector3[] CalibratePath(Vector3[] supplied_path)
		{
			Vector3[] path = new Vector3[supplied_path.Length];
			
			for (int i = 0; i < supplied_path.Length; i++)
				path[i] = supplied_path[i] + gameObject.transform.position;
			
			return path;
		}

		void SetDirection(Vector3 direction)
		{
			this.direction = direction;
		}
	}

    public virtual void ShootOnce()
    {

    }

    public virtual void StartShooting()
    {

    }

    public virtual void StopShooting()
    {

    }

    public virtual void StartAiming()
    {

    }
}