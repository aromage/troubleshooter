using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour, IWindow {

    public UILabel Discript;
    public UIButton Button1, Button2;

    
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
        Discript.text = "종료 하시겠습니까?";
        EventDelegate.Add(Button2.GetComponent<UIEventTrigger>().onClick, GameObject.Find("StageManager").GetComponent<StageManager>().ExitPause);
        EventDelegate.Add(Button1.GetComponent<UIEventTrigger>().onClick, GameObject.Find("StageManager").GetComponent<StageManager>().EscapeFromPause);
    }
}
