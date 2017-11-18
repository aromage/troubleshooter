using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManger.instance.ChangeSceneOnFadeColor(1,Color.black,1.0f);
        }
	}
}
