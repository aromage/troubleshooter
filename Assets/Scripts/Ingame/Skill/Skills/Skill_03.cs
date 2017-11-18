using UnityEngine;
using System.Collections;

public class Skill_03 : MonoBehaviour {

    GameObject effect;

    void Start()
    {


        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_3"));
        if (effect == null)
        {
            return;
        }
        if (GameObject.FindWithTag("player") == null)
        {
            return;
        }
        effect.transform.position = GameObject.FindWithTag("player").transform.position + new Vector3(0, 10, 0);

        StartCoroutine(Act());
    }

    public IEnumerator Act()
    {
        Destroy(this.gameObject);
        yield return null;
    }


   
}
