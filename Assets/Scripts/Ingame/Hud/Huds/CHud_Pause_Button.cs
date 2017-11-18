using UnityEngine;
using System.Collections;

public class CHud_Pause_Button : CHud
{
    public override void Init()
    {
        original_pos = gameObject.transform.position;
        disappear_pos = original_pos;
        disappear_pos.x = 0.8f;
    }
    public override void appear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", original_pos, "easeType", "easeInOutCubic", "time", 0.1f, "ignoretimescale", true));
    }
    public override void disappear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", disappear_pos, "easeType", "easeInOutCubic", "time", 0.1f, "ignoretimescale", true));
    }

    public void joystick()
    {
        GameObject.Find("StageManager").SendMessage("EnterPause");
        //GameObject.Find("HudManager").SendMessage("Reward_Appear");
        //GameObject.Find("player").SendMessage("temp_get");
    }
}
