using UnityEngine;
using System.Collections;

public class AccountPanel : MonoBehaviour, IWindow 
{
    public UILabel Name, Rank, Coin, CurrentStam, MaxStam;
    public UIProgressBar Exp;
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
	
}
