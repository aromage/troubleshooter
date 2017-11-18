using UnityEngine;
using System.Collections;

public class RewardPanel : MonoBehaviour, IWindow
{
    public UILabel Coin, Score, Stage, Level;
    public UISprite Rank;
    public UIProgressBar Exp;
    public UIButton ok_b;
    public GameObject stage_sprite;
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
        EventDelegate.Add(gameObject.transform.Find("ok_b").GetComponent<UIEventTrigger>().onClick, GameObject.Find("GameManager").GetComponent<GameManager>().EscapeStage);
    }
}
