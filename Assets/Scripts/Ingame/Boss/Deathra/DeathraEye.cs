using UnityEngine;
using System.Collections;

public class DeathraEye : MonoBehaviour {

	GameObject player;
	Vector3 target;
	Vector3 diff;
	float angle;

	// Use this for initialization
	void Start () {
		player = new GameObject();
		player = GameObject.FindWithTag("player");
	}
	
	// Update is called once per frame
	void Update () {
		target = (player != null)? player.transform.position : new Vector3(0f, -800f, 0f);
		
		diff = target - transform.position;

		transform.Rotate(Time.deltaTime * 10f * Vector3.Cross(-transform.up, diff).normalized);

		if (player == null)
			player = GameObject.FindWithTag("player");
	}

	public void Calibrate()
	{
		target = (player != null)? player.transform.position : new Vector3(0f, -800f, 0f);
		
		diff = target - transform.position;
		
		angle = Vector3.Angle(Vector3.down, diff);
		angle *= (diff.x > 0)? 1 : -1;
		
		transform.eulerAngles = new Vector3(0f, 0f, angle);
	}
}
