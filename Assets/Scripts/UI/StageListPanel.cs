using UnityEngine;
using System.Collections;

public class StageListPanel : MonoBehaviour, IWindow 
{


    public UIEventTrigger Back;
    public UIManager UIMRoot;

    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }



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
        GameObject QuestButton;
        GameObject UIRoot = GameObject.Find("StageGrid");
        UIMRoot = GameObject.Find("UI Manager").GetComponent<UIManager>();



        EventDelegate.Add(Back.onClick, UIMRoot.gotoLobby);
       
        for (int i = 0; i < GameManager.quest_count; i++)
        {
            QuestButton = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/Component/StageButton") as GameObject);
            //신전환 이벤트
            EventDelegate.Add(QuestButton.GetComponent<UIEventTrigger>().onClick, UIMRoot.gotoGameReady);
            QuestButton.GetComponent<StageButton>().my_id = i;
            QuestButton.GetComponent<StageButton>().InitializeButton(GameManager.QuestInfo[i].Name);
            QuestButton.GetComponent<StageButton>().ChangeMap(GameManager.QuestInfo[i].MapIndex);
        }
    }
}
