using UnityEngine;
using System.Collections;

public class ShopPanel : MonoBehaviour, IWindow
{
    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }
    public UIEventTrigger Back;


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
        //EventDelegate.Add(Back.onClick, GameObject.Find("UI Manager").GetComponent<UIManager>().gotoLobby);
    }
}

