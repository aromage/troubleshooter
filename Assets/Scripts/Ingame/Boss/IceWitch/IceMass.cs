using UnityEngine;
using System.Collections;

public class IceMass : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Translate(Time.deltaTime * 1000f * Vector3.down, Space.World);

		if (transform.position.y < -700f)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "player")
		{
			coll.gameObject.SendMessage("ApplyDamage", 200f);
			Destroy(gameObject);
		}
	}
}
