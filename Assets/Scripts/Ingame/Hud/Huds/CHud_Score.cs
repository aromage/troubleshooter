using UnityEngine;
using System.Collections;

public class CHud_Score : CHud
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public override void Init()
    {
        original_pos = gameObject.transform.position;
    }
    public override void appear()
    {

    }
    public override void disappear()
    {

    }

    //****************************************************************
    public void Cheat()
    {
        GameObject.Find("PlayerManager").SendMessage("BeStrong");
    }
}
