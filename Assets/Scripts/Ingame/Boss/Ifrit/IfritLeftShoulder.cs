using UnityEngine;
using System.Collections;

public class IfritLeftShoulder : MonoBehaviour {
	[SerializeField]
	Transform boss;
	[SerializeField]
	Sprite shooter;
	[SerializeField]
	Sprite shoulder;
	[SerializeField]
	GameObject boss_beam;

	// Use this for initialization
	void Start () {
		transform.position = boss.position + new Vector3(boss.localScale.x * 323f, boss.localScale.y * 216f, 0f);
	}

	// Update is called once per frame
	void Update () {
		if (BossManager1.boss_state == Ifrit.BossState.Intro)
			transform.position = boss.position + new Vector3(boss.localScale.x * 193f, boss.localScale.y * 146f, -0.01f);
	}

	public void Diverge()
	{
		Hashtable command = new Hashtable();
		command.Add("position", boss.position + new Vector3(323f, 216f, -0.01f));
		command.Add("easetype", iTween.EaseType.easeInExpo);
		command.Add("time", 0.5f);

		iTween.MoveTo(gameObject, command);
	}
	
	void GetInvisible()
	{
		Color color = gameObject.GetComponent<SpriteRenderer>().color;
		color.a = 0f;
		gameObject.GetComponent<SpriteRenderer>().color = color;
	}

	void GetVisible()
	{
		Color color = gameObject.GetComponent<SpriteRenderer>().color;
		color.a = 1f;
		gameObject.GetComponent<SpriteRenderer>().color = color;
	}

	public void StartBreathing()
	{
		Hashtable command = iTween.Hash("amount", 22.5f * Vector3.up, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad, "time", 2.0f);
		iTween.MoveBy(gameObject, command);
	}

	public void StartShooter()
	{
		StartCoroutine(Shooter());
	}

	IEnumerator Shooter()
	{
		iTween.Stop(gameObject);

		Hashtable rotate_command = iTween.Hash("rotation", Vector3.forward * -55f, "time", 0.7f);
		iTween.RotateTo(gameObject, rotate_command);

		yield return new WaitForSeconds(1f);

		Hashtable move_command = iTween.Hash("position", new Vector3(45f, 0f, -0.01f), "time", 1f, "easetype", iTween.EaseType.easeInQuad);
		iTween.MoveTo(gameObject, move_command);

		yield return new WaitForSeconds(1f);

		GetInvisible();

		iTween.Stop(gameObject);
		gameObject.GetComponent<SpriteRenderer>().sprite = shooter;
		transform.position = new Vector3(0f, 0f, -0.01f);
		transform.eulerAngles = Vector3.zero;

		GetVisible();
	}

	public void StartShooting()
	{
		StartCoroutine(Shooting());
	}

	IEnumerator Shooting()
	{
		Vector3 target = GameObject.FindWithTag("player").transform.position;
		Vector3 diff = target - transform.position;
		
		float angle = Vector3.Angle(Vector3.down, diff);
		
		angle *= (diff.x > 0)? 1 : -1;
		
		iTween.RotateTo(gameObject, Vector3.forward * angle, 0.5f);

		yield return new WaitForSeconds(0.6f);

		boss_beam.SetActive(true);
		boss_beam.GetComponent<IfritBeam>().StartShooting();
	}

	public void StartReturn()
	{
		StartCoroutine(Return());
	}

	IEnumerator Return()
	{
		transform.eulerAngles = new Vector3(0f, 0f, -55f);
		gameObject.GetComponent<SpriteRenderer>().sprite = shoulder;
		transform.position = new Vector3(45f, 0f, -0.01f);
		
		Hashtable move_command = iTween.Hash("position", boss.position + new Vector3(323f, 216f, 0f), "time", 2f, "easetype", iTween.EaseType.easeOutQuad);
		iTween.MoveTo(gameObject, move_command);
		
		yield return new WaitForSeconds(2f);
		
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.zero, "time", 0.7f);
		iTween.RotateTo(gameObject, rotate_command);
		
		yield return new WaitForSeconds(0.7f);
		
		StartBreathing();
	}

	void ApplyState(float[] state_DMG) {} // {applying_state, percent, duration}

	void ApplyDamage(float[] damage) {}
}

