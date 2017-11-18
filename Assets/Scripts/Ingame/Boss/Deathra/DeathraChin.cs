using UnityEngine;
using System.Collections;

public class DeathraChin : MonoBehaviour {
	
	void ApplyState(float[] state_DMG) {} // {applying_state, percent, duration}

	void ApplyDamage(float[] damage) {} // {damage, attribute)

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

	public void OpenMouth()
	{
		Hashtable command = new Hashtable();
		command.Add("y", -128f);
		command.Add("time", 0.5f);
		command.Add("islocal", true);
		command.Add("easetyoe", iTween.EaseType.easeOutBack);
		iTween.MoveBy(gameObject, command);
	}

	public void CloseMouth()
	{
		Hashtable command = new Hashtable();
		command.Add("y", 128f);
		command.Add("time", 0.5f);
		command.Add("islocal", true);
		command.Add("easetyoe", iTween.EaseType.easeOutBack);
		iTween.MoveBy(gameObject, command);
	}
}
