using UnityEngine;
using System.Collections;

public class EnergyBall : MonoBehaviour {
	
	[SerializeField]
	Transform left_hand;
	[SerializeField]
	Transform right_hand;
	[SerializeField]
	IfritLeftArm left_arm;
	[SerializeField]
	IfritRightArm right_arm;

	public float HP;
    GameObject do_skill;

	[SerializeField]
	Sprite[] sprites = new Sprite[11];

	bool exploding;

	// Use this for initialization
	void Start () {
		HP = 2000f;
	}

	void OnEnable()
	{
		exploding = false;
		HP = 2000f;

		gameObject.GetComponent<CircleCollider2D>().radius = 200f;

		if (sprites[0] != null)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

		gameObject.GetComponent<Renderer>().material.color = Color.white;

		transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		transform.position = (left_hand.position + right_hand.position) / 2 + new Vector3(0f, 0f, -0.01f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (exploding)
			return;

		if (coll.gameObject.tag == "bullet")
		{
			HP -= coll.gameObject.GetComponent<CBullet>().ATK;

			StartCoroutine(Kiraring());

			if (HP <= 0)
			{
				left_arm.CancelPillKill();
				right_arm.CancelPillKill();

				iTween.Stop(gameObject);

				gameObject.SetActive(false);
			}
		}
	}
	
	public void StartShirink()
	{
		StartCoroutine(Animator());
	}

	IEnumerator Animator()
	{
		int count = 0;
		for (int i = 0; i < 9; i++)
		{
			yield return new WaitForSeconds(0.1f);

			if (count == 0 && i == 3)
			{
				Hashtable command = iTween.Hash("scale", new Vector3(0.01f, 0.01f, 0.01f), "time", 7.4f, "easetype", iTween.EaseType.linear, "oncomplete", "OnShirinkComplete");
				iTween.ScaleTo(gameObject, command);
			}

			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i + 1];

			if (i == 5 && count < 19)
			{
				i = 3;
				count++;
			}
		}


	}

	void OnShirinkComplete()
	{
		StartCoroutine(Explode());
	}

	IEnumerator Explode()
	{
		exploding = true;
	
		gameObject.GetComponent<CircleCollider2D>().radius = 680f;

		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[10];

		Hashtable command = new Hashtable();
		command.Add("amount", new Vector3(200f, 200f, 200f));
		command.Add("speed", 0.8f);

		iTween.ScaleBy(gameObject, command);

		yield return new WaitForSeconds(1f);

		iTween.Stop(gameObject);
		gameObject.SetActive(false);
	}

	public void StartAppear()
	{
		Hashtable command = iTween.Hash("alpha", 1f, "time", 1f);

		iTween.FadeFrom(gameObject, command);
	}

	IEnumerator Kiraring()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(0.06f);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}
}
