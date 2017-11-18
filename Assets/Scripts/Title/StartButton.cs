using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	StartCoroutine(Kiraring());
	}

    public IEnumerator Kiraring()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(Kiraring());
    }
}
