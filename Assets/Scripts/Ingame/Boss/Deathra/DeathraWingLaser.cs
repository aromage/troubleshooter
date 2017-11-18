using UnityEngine;
using System.Collections;

public class DeathraWingLaser : MonoBehaviour {

	[SerializeField]
	GameObject laser_tail;
	[SerializeField]
	SpriteRenderer sprite_renderer;
	[SerializeField]
	GameObject wing;
	[SerializeField]
	Deathra deathra;
	
	void OnEnable()
	{
		sprite_renderer.sprite = null;
		transform.localPosition = Vector3.zero;
		laser_tail.SetActive(true);
	}
	
	void OnDisable()
	{
		iTween.Stop(gameObject);
		iTween.Stop(laser_tail);

		Color temp = new Color();
		temp = GetComponent<Renderer>().material.color;
		temp.a = 1f;
		GetComponent<Renderer>().material.color = temp;
		temp = laser_tail.GetComponent<Renderer>().material.color;
		temp.a = 1f;
		laser_tail.GetComponent<Renderer>().material.color = temp;

		laser_tail.SetActive(false);
	}
	
	[SerializeField]
	Texture2D fire_laser;
	[SerializeField]
	Texture2D leaf_laser;
	[SerializeField]
	Texture2D water_laser;
	
	const float Width = 53f;
	const float Height = 948f;
	
	public void StartShooting()
	{
		StartCoroutine(Shoot());
	}
	
	IEnumerator Shoot()
	{
		PlayTailAnimation();
		
		yield return new WaitForSeconds(0.15f);
		
		float height = 0f;
		float speed = 1500f;

		Vector3 direction = - transform.parent.up.normalized;
		Vector3 position = new Vector3();
		position = transform.position;
		Vector3 euler = transform.parent.eulerAngles;
		Rect new_rect;
		Sprite new_sprite;


		while (true)
		{
			transform.position = position;
			transform.eulerAngles = euler;
			yield return null;
		}
		
		yield break;
	}
	
	void PlayTailAnimation()
	{
		string state_name;
		
		switch(deathra.attribute)
		{
		case Attribute.FIRE:
			state_name = "WingFireTail";
			break;
		case Attribute.NATURE:
			state_name = "WingLeafTail";
			break;
		case Attribute.AQUA:
			state_name = "WingWaterTail";
			break;
		default:
			return;
		}
		
		laser_tail.GetComponent<Animator>().Play(state_name);
	}
	
	Texture2D GetLaserTexture()
	{
		switch(deathra.attribute)
		{
		case Attribute.FIRE:
			return fire_laser;
		case Attribute.NATURE:
			return leaf_laser;
		case Attribute.AQUA:
			return water_laser;
		default:
			return null;
		}
	}

	public void FadeOut()
	{
		Hashtable command = iTween.Hash("alpha", 0f, "time", 0.15f);
		iTween.FadeTo(gameObject, command);
		iTween.FadeTo(laser_tail, command);
	}
}
