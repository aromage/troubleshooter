using UnityEngine;
using System.Collections;

public class LobbyPanel : MonoBehaviour, IWindow 
{
    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }
    public UIEventTrigger StageList, GuildManagement, Muhan, Shop, Setting;


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
        EventDelegate.Add(gameObject.transform.Find("QuestButton").GetComponent<UIEventTrigger>().onClick, GameObject.Find("UI Manager").GetComponent<UIManager>().gotoStagelist);

        EventDelegate.Add(gameObject.transform.Find("GuildButton").GetComponent<UIEventTrigger>().onClick, GameObject.Find("UI Manager").GetComponent<UIManager>().gotoGuildManagement);
        EventDelegate.Add(gameObject.transform.Find("MuhanButton").GetComponent<UIEventTrigger>().onClick, GameObject.Find("UI Manager").GetComponent<UIManager>().gotoMuhan);
       
    }
	
}
