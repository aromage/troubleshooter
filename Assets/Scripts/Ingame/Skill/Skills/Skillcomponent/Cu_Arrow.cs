using UnityEngine;
using System.Collections;

public class Cu_Arrow : MonoBehaviour {

    Vector3 pos;
    float damage;
	// Use this for initialization
	void Start () {

        pos = gameObject.transform.position;
        damage = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().MP_current*0.5f;
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().MP_current -= damage;
        StartCoroutine(dest());

	}
	
	// Update is called once per frame
	void Update () {
        pos.y += 1500.0f*Time.deltaTime;
        gameObject.transform.position = pos;

	}

    IEnumerator dest()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        SKillManager.usedend(3);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "enemy" || coll.gameObject.tag == "boss")
        {
            coll.gameObject.SendMessage("ApplyDamage", new float[2] { 2*damage*GameManager.CharacterInfo[2].char_ATK, (float)Attribute.NATURE });
        }

    }

}
