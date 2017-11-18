using UnityEngine;
using System.Collections;

public class IfritFire : MonoBehaviour {
	const int NUMBER_OF_FIRE_IMAGES = 4;

	public Transform boss;

	Sprite[] sprites = new Sprite[NUMBER_OF_FIRE_IMAGES];
	int animation_index;

	// Use this for initialization
	void Start () {
		transform.position = boss.position + new Vector3(boss.localScale.x * 33f, boss.localScale.y * 250f, 0f);
		StartCoroutine(Animator());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = boss.position + new Vector3(boss.localScale.x * 33f, boss.localScale.y * 250f, 0f);
	}

	IEnumerator LoadSprites()
	{
		for (int i = 1; i < 1 + NUMBER_OF_FIRE_IMAGES; i++)
		{
			sprites[i - 1] = Resources.Load<Sprite>("Images/Enemy/Boss/Fire_" + i.ToString());

			yield return null;
		}
	}

	void ChangeSprite(int index)
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
	}

	IEnumerator Animator()
	{
		StartCoroutine(LoadSprites());

		int index = 0;

		while (true)
		{
			ChangeSprite(index);

			index += (index != 3)? 1 : -3;
			yield return new WaitForSeconds(0.2f);
		}
	}

	void ApplyState(float[] state_DMG) {} // {applying_state, percent, duration}

	void ApplyDamage(float[] damage) {}
}
