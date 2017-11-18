using UnityEngine;
using System.Collections;

public class GameReadyPanel : MonoBehaviour, IWindow 
{
    public UISprite party1, party2, party3, mapattribute;
    public UILabel QuestName, Questbreif;
    QuestData saveddata;
    public int questnum;

    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }

    public UIEventTrigger Back;
    public UIManager UIMRoot;

    public void Show()
    {
        isActive = true;
        thisObject.SetActive(true);
    }

    public void Hide()
    {
        isActive = false;
        thisObject.SetActive(false);
    }
    void Start()
    {
        UIMRoot = GameObject.Find("UI Manager").GetComponent<UIManager>();
        EventDelegate.Add(Back.onClick, UIMRoot.gotoStagelist);
            EventDelegate.Parameter param1 = new EventDelegate.Parameter();
            param1.obj = gameObject.GetComponent<GameReadyPanel>();
            param1.field = "questnum";
            EventDelegate SetOn = new EventDelegate(GameObject.Find("GameManager").GetComponent<GameManager>(), "GotoStage");
            SetOn.parameters[0] = param1;
            EventDelegate.Add(gameObject.transform.Find("GameStartButton").GetComponent<UIEventTrigger>().onClick, SetOn);
           
    }

    public void SetData(QuestData qd)
    {
        saveddata = qd;
        QuestName.text = saveddata.Name;
        Questbreif.text = saveddata.Description;
        questnum = saveddata.Index;
        party1.spriteName = GameManager.User.party.member[0].char_name;
        party2.spriteName = GameManager.User.party.member[1].char_name;
        party3.spriteName = GameManager.User.party.member[2].char_name;
    }
}
