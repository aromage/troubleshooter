using UnityEngine;
using System.Collections;

public class CHud_Boss_Hp_Bar : CHud
{
    GameObject Boss;
    UILabel name;
    UISlider me;
    float anim = 0.0f;
    public bool complete = false;
    int Bossnum;

    Color temp_color;
	// Use this for initialization
	void Start () {
        me = gameObject.GetComponent<UISlider>();
        temp_color = Color.white;
        name = GameObject.Find("BossName").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (complete)
        {
            me.value = ((Boss.GetComponent<CBoss>().HP) / (Boss.GetComponent<CBoss>().max_HP)) * anim;
            temp_color.g = ((Boss.GetComponent<CBoss>().HP) / (Boss.GetComponent<CBoss>().max_HP)) * anim;
        
            me.foregroundWidget.GetComponent<UISprite>().color = temp_color;
        }
	}
    public override void Init()
    {
        original_pos = gameObject.transform.position;
        
    }

    IEnumerator SetHp(GameObject g)
    {
        Boss = g;
/*
        name.text = Boss.GetComponent<CBoss>().name;
        float intro_time = Boss.GetComponent<CBoss>().intro_time;

        iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", intro_time, "time", 4.3f, "onupdate", "hp_anim", "ignoretimescale", true));
        */

        if (g.name == "Ifrit(Clone)")
            Bossnum = 1;
        else if (g.name == "IceWitch(Clone)")
            Bossnum = 2;
        else if (g.name == "Deathra(Clone)")
            Bossnum = 3;


       
        switch (Bossnum)
        {
            case 1:
                name.text = "불의 정령 이프리트";
                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", 4.3f, "onupdate", "hp_anim", "ignoretimescale", true));
                break;
            case 2:
                name.text = "얼음의 마녀 아이시";
                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", 1.0f, "onupdate", "hp_anim", "ignoretimescale", true));
                break;
            case 3:
                name.text = "탐욕의 석상 데스라";
                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", 1.0f, "onupdate", "hp_anim", "ignoretimescale", true));
                break;
            default:
                break;
        }
        

        complete = true;
        yield return null;
    }

    void hp_anim(float a)
    {
        anim = a;
    }

    public void SetOff()
    {
        anim = 0.0f;
        complete = false;
    }

    public override void appear()
    {

    }
    public override void disappear()
    {

    }
}
