using UnityEngine;
using System.Collections;

public class IfritRightShoulder : MonoBehaviour {

	[SerializeField]
	Transform boss;
	[SerializeField]
	Transform left_shoulder;

	// Use this for initialization
	void Start () {
		transform.position = left_shoulder.position + new Vector3(boss.localScale.x * -635f, boss.localScale.y * 2f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (BossManager1.boss_state == Ifrit.BossState.Intro)
			transform.position = left_shoulder.position + new Vector3(boss.localScale.x * -375f, boss.localScale.y * 2f, -0.01f);
		else if (BossManager1.boss_state != Ifrit.BossState.Diverge &&
		         BossManager1.boss_state != Ifrit.BossState.Laser &&
		         BossManager1.boss_state != Ifrit.BossState.State_4)
			transform.position = left_shoulder.position + new Vector3(boss.localScale.x * -635f, boss.localScale.y * 2f, 0f);
	}

	public void Diverge()
	{
		Hashtable command = new Hashtable();
		command.Add("position", boss.position + new Vector3(-312f, 218f, -0.01f));
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

	public void StartShooter()
	{
		StartCoroutine(Shooter());
	}
	
	IEnumerator Shooter()
	{
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.forward * 55f, "time", 1f);
		iTween.RotateTo(gameObject, rotate_command);
		
		yield return new WaitForSeconds(1f);
		
		Hashtable move_command = iTween.Hash("position", new Vector3(-45f, 0f, -0.01f), "time", 1f, "easetype", iTween.EaseType.easeInQuad);
		iTween.MoveTo(gameObject, move_command);

		yield return new WaitForSeconds(1f);

		GetInvisible();
	}

	public void StartReturn()
	{
		StartCoroutine(Return());
	}

	IEnumerator Return()
	{
		GetVisible();
		
		Hashtable move_command = iTween.Hash("position", new Vector3(-312f, 418f, 0f), "time", 2f, "easetype", iTween.EaseType.easeOutQuad);
		iTween.MoveTo(gameObject, move_command);
		
		yield return new WaitForSeconds(2f);
		
		Hashtable rotate_command = iTween.Hash("rotation", Vector3.zero, "time", 0.7f);
		iTween.RotateTo(gameObject, rotate_command);
	}

	void ApplyState(float[] state_DMG) {} // {applying_state, percent, duration}

	void ApplyDamage(float[] damage) {}
}
