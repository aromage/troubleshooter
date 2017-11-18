using UnityEngine;
using System.Collections;

public class MuhanPanel : MonoBehaviour,IWindow {


    public UISprite[] party = new UISprite[3];
    public UILabel HP, Atk, MP, Score;

    public UIEventTrigger Back, Startb;
    public UIManager UIMRoot;


    public int questnum;
    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }


  
    // Use this for initialization
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
        questnum = 1000;
        EventDelegate.Add(Back.onClick, UIMRoot.gotoLobby);

        EventDelegate.Parameter param1 = new EventDelegate.Parameter();
        param1.obj = gameObject.GetComponent<MuhanPanel>();
        param1.field = "questnum";
        EventDelegate SetOn = new EventDelegate(GameObject.Find("GameManager").GetComponent<GameManager>(), "GotoStage");
        SetOn.parameters[0] = param1;
        EventDelegate.Add(Startb.onClick, SetOn);
    }

    public void Setting()
    {
        HP.text = GameManager.User.party.total_HP.ToString();
        MP.text =  GameManager.User.party.total_MP.ToString();
        Atk.text =(900 + ((GameManager.User.party.member[0].My_Level - 1 + GameManager.User.party.member[1].My_Level - 1 + GameManager.User.party.member[2].My_Level - 1) * 16)).ToString();
        for(int i=0; i<3; i++)
        {
            party[i].spriteName = GameManager.User.party.member[i].char_name;
        }
        Score.text = GameManager.muhanscore.ToString();
    }

}
