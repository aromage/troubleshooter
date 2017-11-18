using UnityEngine;
using System.Collections;

public class IfritBeam : MonoBehaviour {

	const float Width = 98f;
	const float Height = 1251f;

	[SerializeField]
	SpriteRenderer sprite_renderer;
	[SerializeField]
	BoxCollider2D collider;
	[SerializeField]
	Texture2D texture;

	[SerializeField]
	Transform shooter;

	Vector2 center;
	float speed;

	Sprite new_sprite;
	Rect new_rect;
	
	// Use this for initialization
	void Start () {
		center = new Vector2(0.5f, 0.5f);
		speed = 1000f;
	}

	void OnEnable()
	{
		transform.position = shooter.position - 70f * shooter.up.normalized;

		Color color = GetComponent<Renderer>().material.color;
		color.a = 1f;
		GetComponent<Renderer>().material.color = color;

		sprite_renderer.sprite = null;
		collider.size = new Vector2(Width, 0f);
	}

	void OnComplete()
	{
		gameObject.SetActive(false);
	}

	public void StartShooting()
	{
		StartCoroutine(Shooting());
	}

	IEnumerator Shooting()
	{
		float height = 0f;

		GameObject beam_tail = new GameObject();
		beam_tail.name = "Beam Tail";
		beam_tail.transform.parent = transform.parent;
		beam_tail.transform.rotation = transform.parent.rotation;
		beam_tail.transform.position = shooter.position - 100f * shooter.up.normalized;
		beam_tail.transform.position += new Vector3(0f, 0f, -0.01f);
		beam_tail.AddComponent<SpriteRenderer>().sortingLayerName = "Bullet";
		Animator animator = beam_tail.AddComponent<Animator>();
		animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Boss/BeamTail");
		animator.Play("BeamTail");
	
		yield return new WaitForSeconds(0.7f);

		GameObject beam_head = new GameObject();
		beam_head.name = "Beam Head";
		beam_head.tag = "laser";
		Sprite head_sprite = ResourceLoad.PickSprite("beam_head");
		beam_head.transform.parent = transform.parent;
		beam_head.transform.rotation = transform.parent.rotation;
		SpriteRenderer render = beam_head.AddComponent<SpriteRenderer>();
		render.sprite = head_sprite;
		render.sortingLayerName = "Bullet";


		while (height < Height)
		{
			if (iTween.Count(gameObject) == 0 && height > 0.7f * Height)
			{
				Hashtable command = iTween.Hash("alpha", 0f, "time", 1f, "oncomplete", "OnComplete");
				iTween.FadeTo(gameObject, command);
				iTween.FadeTo(beam_tail, command);
			}

			height += 2f * speed * Time.deltaTime;
			collider.size = new Vector2(Width, height);

			if (height > Height)
			{
				height = Height;
				transform.position = shooter.position - (70f + Height / 2f) * shooter.up.normalized;
			}
			else
				transform.position += - speed * Time.deltaTime * shooter.up.normalized;

			beam_head.transform.position = transform.position - (height / 2f - 17.1f) * shooter.up.normalized;

			new_rect = new Rect(0f, Height - height, Width, height);
			new_sprite = Sprite.Create(texture, new_rect, center, 1f);

			sprite_renderer.sprite = new_sprite;

			yield return null;
		}

		yield return new WaitForSeconds(0.7f);

		Destroy(beam_head);
		Destroy(beam_tail);
	}
}
