using UnityEngine;
using System.Collections;

public class enemyShooter : CShooter
{
    [SerializeField]
    bool is_aiming = false;

	public void Init(GameObject enemy)
	{
	    if (enemy != null)
	    {
            transform.parent = enemy.transform;    
	    }
		
		transform.localPosition = Vector3.zero;
	}

	public void StartAiming()
	{
		StartCoroutine(Aim());
        is_aiming = true;
	}

    public void StopAiming()
    {
        StopCoroutine(Aim());
        is_aiming = false;
    }

	GameObject player;
	Vector3 target;
	Vector3 diff;
	float angle;

	IEnumerator Aim()
	{
		player = GameObject.FindWithTag("player");
		while (true)
		{
			target = (player != null)? player.transform.position : new Vector3(0f, -800f, 0f);

			diff = target - transform.position;
			
			angle = Vector3.Angle(Vector3.down, diff);
			angle *= (diff.x > 0)? 1 : -1;
			
			transform.eulerAngles = new Vector3(0f, 0f, angle);

			if (player == null)
				player = GameObject.FindWithTag("player");

			yield return null;
		}
	}
}
