using UnityEngine;
using System.Collections;

public class IfritRightHand : MonoBehaviour {

	const int NUMBER_OF_HAND_IMAGES = 9;

	[SerializeField]
	Transform boss;
	[SerializeField]
	Transform right_arm;

	enemyShooter shooter;

	Sprite[] sprites = new Sprite[NUMBER_OF_HAND_IMAGES];

	// Use this for initialization
	void Start () {
		transform.position = right_arm.position + new Vector3(boss.localScale.x * 66f, boss.localScale.y * -106.5f, -0.02f);

		shooter = gameObject.GetComponent<enemyShooter>();
        shooter.SetBulletInfo(666, (Attribute)0, (HitType)0, 350f, 0.05f, State.NONE, 15f);
        shooter.SetShooitngInfo(8, 4, 3, 1.0f, 0.2f, 50f);

		StartCoroutine(LoadSprites());
	}
	
	void OnEnable()
	{
		if (sprites[3] != null)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
	}

	// Update is called once per frame
	void Update () {
		transform.position = right_arm.position + 66f * boss.localScale.x * right_arm.right.normalized -106.5f * boss.localScale.y * right_arm.up.normalized -0.02f * right_arm.forward.normalized;
	}

	IEnumerator LoadSprites()
	{
		for (int i = 1; i < 1 + NUMBER_OF_HAND_IMAGES; i++)
		{
			sprites[i - 1] = (i <= 4)? Resources.Load<Sprite>("Images/Enemy/Boss/Rhand_" + i.ToString()) : Resources.Load<Sprite>("Images/Enemy/Boss/RPKhand_" + (i - 4).ToString());
		
			yield return null;
		}
	}

	public void StartRocketPunch()
	{
		StopCoroutine("Return");
		StartCoroutine("RocketPunch");
	}

	IEnumerator RocketPunch()
	{
		for (int i = 0; i < 3; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2 - i];

			yield return new WaitForSeconds(0.1f);
		}
	}

	public void StartReturn()
	{
		StartCoroutine("Return");
	}

	IEnumerator Return()
	{
		for (int i = 0; i < 3; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i + 1];

			yield return new WaitForSeconds(0.2f);
		}
	}

	public void StartPillKillGrab()
	{
		StartCoroutine(PillKillGrab());
	}
	
	IEnumerator PillKillGrab()
	{
		for (int i = 0; i < 3; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2 - i];
			
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void StartPillKillUnfold()
	{
		StartCoroutine(PillKillUnfold());
	}
	
	IEnumerator PillKillUnfold()
	{
		for (int i = 0; i < 5; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i + 4];
			
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void StartPillKillReturn()
	{
		StartCoroutine(PillKillReturn());
	}
	
	IEnumerator PillKillReturn()
	{
		for (int i = 0; i < 8; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = (i < 4)? sprites[7 - i] : sprites[i - 4];
			
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void StartShooting()
	{
		shooter.StartShooting();
	}

	public void StopShooting()
	{
		shooter.StopShooting();
	}


	IEnumerator Kiraring()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(0.06f);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}
	
	public void StartKiraring()
	{
		StartCoroutine(Kiraring());
	}

	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
		if (right_arm.gameObject.activeSelf)
			right_arm.SendMessage("ApplyState", state_DMG);
	}

	void ApplyDamage(float[] damage) 
	{
		right_arm.SendMessage("ApplyDamage", damage);
	}
}
