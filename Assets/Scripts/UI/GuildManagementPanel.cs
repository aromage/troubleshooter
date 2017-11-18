using UnityEngine;
using System.Collections;

public class GuildManagementPanel : MonoBehaviour, IWindow 
{
    public UILabel Total_HP, Total_Mana, Total_Atk;
    public GameObject[] party = new GameObject[3];

    public UIEventTrigger Back;

    public CharacterButton[] CharacterButton;


    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }
    GameObject UIRoot;
    UIManager UIMRoot;
    

    public void SetStatus()
    {
        Total_HP.text = GameManager.User.party.total_HP.ToString();
        Total_Mana.text = GameManager.User.party.total_MP.ToString();
        Total_Atk.text = (900 +  ((GameManager.User.party.member[0].My_Level-1 + GameManager.User.party.member[1].My_Level-1 + GameManager.User.party.member[2].My_Level-1)*16)).ToString();
    }

        
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
        UIRoot = GameObject.Find("CharacterGrid");
        UIMRoot = GameObject.Find("UI Manager").GetComponent<UIManager>();
        GameObject CharButton;

        EventDelegate.Add(Back.onClick, UIMRoot.GetComponent<UIManager>().gotoLobby);
       // EventDelegate.Add(party[0].GetComponent<UIEventTrigger>().onClick, UIMRoot.gotoHeadHunterCenter);
      //  EventDelegate.Add(party[1].GetComponent<UIEventTrigger>().onClick, UIMRoot.gotoHeadHunterCenter);
      //  EventDelegate.Add(party[2].GetComponent<UIEventTrigger>().onClick, UIMRoot.gotoHeadHunterCenter);

        CharacterButton = new CharacterButton[GameManager.char_count];
        for (int i = 0; i < GameManager.char_count; i++)
        {
            CharButton = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/Component/CharacterButton") as GameObject);
       //     EventDelegate.Add(CharButton.GetComponent<UIEventTrigger>().onClick, UIMRoot.gotoHeadHunterCenter);
            CharButton.GetComponent<CharacterButton>().my_id = i;
            CharButton.GetComponent<CharacterButton>().ChangeSprite(GameManager.CharacterInfo[i].char_name);
            CharacterButton[i] = CharButton.GetComponent<CharacterButton>();
        }
        

        for(int i=0; i<3; i++)
        {
            party[i].GetComponent<PartyIconCollider>().Init();
        }
    }
   

}
