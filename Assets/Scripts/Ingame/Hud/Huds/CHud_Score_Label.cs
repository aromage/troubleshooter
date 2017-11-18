using UnityEngine;
using System.Collections;

public class CHud_Score_Label : MonoBehaviour {


    string text;
    UILabel me;
	// Use this for initialization
	void Start () {
        me = gameObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        int score = StageManager.score;

        if (score < 10)
            text = "0000000";
        else if (score < 100)
            text = "000000";
        else if (score < 1000)
            text = "00000";
        else if (score < 10000)
            text = "0000";

        me.text = text + score.ToString();
	}
}
