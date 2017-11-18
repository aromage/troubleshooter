using UnityEngine;
using System.Collections;

public class StageButton : MonoBehaviour {


    public int my_id;
	// Use this for initialization
	void Start () 
    {
	
	}

	public void InitializeButton(string qn)
    {
        gameObject.transform.Find("Label").GetComponent<UILabel>().text = qn;
    }

    public void ChangeMap(int mapindex)
    {

        string mapname;
        switch (mapindex)
         {
             case 1:
                 mapname = "Forestmap";
                 break;
             case 2:
                 mapname = "Icemap";
                 break;
             case 3:
                 mapname = "Lavamap";
                 break;
             case 4:
                 mapname = "Lavamap";
                 break;
             case 5:
                 mapname = "Icemap";
                 break;
             case 6:
                 mapname = "Forestmap";
                 break;
             default:
                 mapname = "forestmap";
                 break;
         }          
       gameObject.transform.Find("Map").GetComponent<UISprite>().spriteName = mapname;
    }
    public void OnClick()
    {
        GameObject.Find("UI Manager").GetComponent<UIManager>().SetQuest(GameManager.QuestInfo[my_id]);
    }

}
