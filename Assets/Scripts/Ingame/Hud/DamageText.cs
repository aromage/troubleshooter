using UnityEngine;
using System.Collections;

public class DamageText : MonoBehaviour {

    TextMesh text;
    GameObject target;
    Vector3 location;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        location.y += 1.0f;
        gameObject.transform.position = location;
	}

    public void Init(float f, float att, Vector3 loc)
    {
        text = gameObject.GetComponent<TextMesh>();
        text.text = "" + f;
       switch((Attribute)att)
       {
           case Attribute.FIRE:
               text.color = Color.red;
               break;
           case Attribute.NATURE:
               text.color = Color.green;
               break;
           case Attribute.AQUA:
               text.color = Color.blue;
               break;
           case Attribute.DARK:
               text.color = Color.black;
               break;
           case Attribute.LIGHT:
               text.color = Color.yellow;
               break;
           case Attribute.EMPTY:
               break;
       }
        location = loc;
        gameObject.transform.position = location;
        StartCoroutine("deletetext", 1.0f);
    }


    IEnumerator deletetext(float time)
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(time));
        Destroy(this.gameObject);
    }
}
