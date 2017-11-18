using UnityEngine;
using System.Collections;

public class IfritBottom : MonoBehaviour {

	public Transform boss;

	// Use this for initialization
	void Start () {
		transform.position = boss.position + new Vector3(boss.localScale.x * 14.5f, boss.localScale.y * -272f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (BossManager1.boss_state == Ifrit.BossState.Intro)
			transform.position = boss.position + new Vector3(boss.localScale.x * 14.5f, boss.localScale.y * -182f, 0.01f);
		else if (BossManager1.boss_state != Ifrit.BossState.Diverge)
			transform.position = boss.position + new Vector3(boss.localScale.x * 14.5f, boss.localScale.y * -272f, 0f);
	}

	public void Diverge()
	{
		Hashtable command = new Hashtable();
		command.Add("position", boss.position + new Vector3(14.5f, -272f, 0.01f));
		command.Add("easetype", iTween.EaseType.easeInExpo);
		command.Add("time", 0.5f);
		
		iTween.MoveTo(gameObject, command);
	}

	public void StartKiraring()
	{
		StartCoroutine(Kiraring());
	}

	IEnumerator Kiraring()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(0.06f);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}

	void ApplyState(float[] state_DMG) {} // {applying_state, percent, duration}

	void ApplyDamage(float[] damage)
	{
		boss.SendMessage("ApplyDamage", damage);
	}
}