using UnityEngine;
using System.Collections;

public class Skill_08 : MonoBehaviour {

    GameObject effect;
	// Use this for initialization
	void Start () {

        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_8"));
        StartCoroutine(Act());
        if (effect == null)
        {
            return;
        }
        effect.transform.position = new Vector3(0, -800, 0);
        StartCoroutine(Act());
	}
	

    public IEnumerator Act()
    {
        Destroy(this.gameObject);
        yield return null;
    }
}
