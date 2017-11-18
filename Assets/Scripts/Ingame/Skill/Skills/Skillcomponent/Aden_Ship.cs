using UnityEngine;
using System.Collections;

public class Aden_Ship : MonoBehaviour {

	Vector3 pos;
	// Use this for initialization
	void Start () {

        pos = gameObject.transform.position;
        StartCoroutine(dest());

	}
	
	// Update is called once per frame
	void Update () {
        pos.y += 1800.0f*Time.deltaTime;
        gameObject.transform.position = pos;

	}

    IEnumerator dest()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        SKillManager.usedend(8);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "enemy" || coll.gameObject.tag == "boss")
        {
            coll.gameObject.SendMessage("ApplyDamage", new float[2] { GameManager.CharacterInfo[7].char_ATK*10, (float)Attribute.AQUA });
        }

    }
}





