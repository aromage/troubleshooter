using System;
using UnityEngine;

public enum SceneType
{
    Main,
    Popup,
}

public interface IWindow
{
    bool                    isActive { get; set; }
    GameObject              thisObject { get; }
    SceneType               type { get; }

    void                    Show();
    void                    Hide();
}


