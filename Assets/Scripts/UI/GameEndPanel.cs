using UnityEngine;
using System.Collections;

public class GameEndPanel : MonoBehaviour, IWindow 
{

    public UILabel label;
    public GameObject Yes, No;
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
	public void Start()
    {
        label.text = "종료 하시겠습니까?";
        EventDelegate.Add(No.GetComponent<UIEventTrigger>().onClick, GameObject.Find("UI Manager").GetComponent<UIManager>().gotoLobby);
        EventDelegate.Add(Yes.GetComponent<UIEventTrigger>().onClick, GameObject.Find("GameManager").GetComponent<GameManager>().QuitGame);
    }
}
