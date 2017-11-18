using UnityEngine;
using System.Collections;

public class Boss_Boom : MonoBehaviour {

    GameObject[] boom = new GameObject[8];

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Boom());
	}
    IEnumerator Boom()
    {
        boom[0] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[0].transform.localScale *= 0.5f;
        boom[0].transform.position = gameObject.transform.position;

        yield return new WaitForSeconds(0.1f);
        boom[1] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[1].transform.localScale *= 1.7f;
        boom[1].transform.position = gameObject.transform.position + new Vector3(100, 105f, 0f);

        yield return new WaitForSeconds(0.1f);
        boom[2] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[2].transform.localScale *= 1.35f;
        boom[2].transform.position = gameObject.transform.position + new Vector3(150f, -200f, 0f);

        yield return new WaitForSeconds(0.1f);
        boom[3] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[3].transform.localScale *= 0.9f;
        boom[3].transform.position = gameObject.transform.position + new Vector3(100f, -150f, 0f);

        yield return new WaitForSeconds(0.05f);
        boom[4] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[4].transform.localScale *= 0.65f;
        boom[4].transform.position = gameObject.transform.position + new Vector3(-50f, 50f, 0f);

        yield return new WaitForSeconds(0.2f);
        boom[5] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[5].transform.localScale *= 1.85f;
        boom[5].transform.position = gameObject.transform.position + new Vector3(50f, 150f, 0f);

        yield return new WaitForSeconds(0.15f);
        boom[6] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[6].transform.localScale *= 0.30f;
        boom[6].transform.position = gameObject.transform.position + new Vector3(100f, -150f, 0f);

        yield return new WaitForSeconds(0.3f);
        boom[7] = (GameObject)Instantiate(ResourceLoad.PickGameObject("splash"));
        boom[7].transform.localScale *= 0.25f;
        boom[7].transform.position = gameObject.transform.position + new Vector3(-60f, -100f, 0f);

        yield return new WaitForSeconds(0.45f);
        for (int i = 0; i < 8; i++)
        {
            DestroyImmediate(boom[i]);
        }
    }
}