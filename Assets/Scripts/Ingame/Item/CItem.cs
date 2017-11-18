using UnityEngine;
using System.Collections;

public class CItem : MonoBehaviour
{
	[SerializeField]
	Vector3 velocity;

    private GameObject player;
	void Start()
	{
        player = GameObject.FindWithTag("player");

        tag = "item";
		StartCoroutine(StartCountDown());

		velocity = new Vector3(Random.Range(-100f, 100f), Random.Range(400f, 600f), 0f);
        if (gameObject.name == "item_coin(Clone)")
        {
            gameObject.GetComponent<Animator>().speed = Random.Range(0.1f,0.75f);
        }
	}

	IEnumerator StartCountDown()
	{
		yield return new WaitForSeconds(5f);
		
		Destroy(gameObject);
	}

	// Update is called once per frame
    void Update()
    {
       	Move();
		Attracted();
    }

    void Move()
    {
        transform.Translate(velocity * Time.deltaTime);

		velocity.y -= 800f * Time.deltaTime;
    }

	void Attracted()
	{
		if (player == null)
			return;

		Vector3 target = player.transform.position;

		Vector3 diff = target - transform.position;

		if (diff.magnitude > 300f)
			return;

		transform.Translate(1000f * diff.normalized * Time.deltaTime);
	}
}