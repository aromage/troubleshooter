using UnityEngine;
using System.Collections;

public class CCutinManager : MonoBehaviour {


    public GameObject[] cut_back = new GameObject[5];
    public GameObject[] cut_sprite = new GameObject[5];
    GameObject player;
    Vector3 []back_save = new Vector3[3];
    Vector3 []sprite_save = new Vector3[3];

    Vector3[] back_move = new Vector3[3];
    Vector3[] sprite_move = new Vector3[3];
	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerManager");

        for(int i=0; i<3; i++)
        {
            back_save[i] = cut_back[i].transform.position;
            sprite_save[i] = cut_sprite[i].transform.position;
            back_move[i] = back_save[i];
            sprite_move[i] = sprite_save[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
    public void CutInUsage(string name, int att, int num)
    {
        if (5 < num)
        {
            return;
        }
        UISprite cutSprite = cut_sprite[num].GetComponent<UISprite>();
        if (cutSprite == null)
        {
            return;
        }
        cutSprite.spriteName = name;

        UISprite cutBackSprite = cut_back[num].GetComponent<UISprite>();
        if (cutBackSprite == null)
        {
            return;
        }

        switch (att)
        {
            case 1:
                cutBackSprite.spriteName = "Fire";
                break;
            case 2:
                cutBackSprite.spriteName = "Aqua";
                break;
            case 3:
                cutBackSprite.spriteName = "Nature";
                break;
            default:
                break;
        }
    }

    public void cutin(int num)
    {
        if (5 < num)
        {
            return;
        }
        cut_sprite[num].transform.position = sprite_save[num];
        cut_back[num].transform.position = back_save[num];

        back_move[num].x = 0.0f;
        sprite_move[num].x = 0.0f;
        iTween.MoveTo(cut_sprite[num], iTween.Hash("position", sprite_move[num], "easeType", "easeOutExpo", "time", 0.2f, "ignoretimescale", true));
        iTween.MoveTo(cut_back[num], iTween.Hash("position", back_move[num], "easeType", "easeOutExpo", "time", 0.2f, "ignoretimescale", true));
    }

    public void cutout(int num)
    {
        if (5 < num)
        {
            return;
        }
        back_move[num].x = -1.5f;
        sprite_move[num].x = -1.5f;
        iTween.MoveTo(cut_sprite[num], iTween.Hash("position", sprite_move[num], "easeType", "easeOutExpo", "time", 0.4f, "ignoretimescale", true));
        iTween.MoveTo(cut_back[num], iTween.Hash("position", back_move[num], "easeType", "easeOutExpo", "time", 0.4f, "ignoretimescale", true));
    }

    public void cutback(int num)
    {
        if (5 < num)
        {
            return;
        }
        iTween.MoveTo(cut_sprite[num], iTween.Hash("position", sprite_save[num], "easeType", "easeOutExpo", "time", 0.2f, "ignoretimescale", true));
        iTween.MoveTo(cut_back[num], iTween.Hash("position", back_save[num], "easeType", "easeOutExpo", "time", 0.2f, "ignoretimescale", true));
    }

}
