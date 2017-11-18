using UnityEngine;
using System.Collections;

public class CHud_Leader_Frame : CHud
{
    [SerializeField]
    int counter = 0;

    public override void Init()
    {
        original_pos = gameObject.transform.position;
        disappear_pos = original_pos;
        disappear_pos.y = -1.2f;
    }
    public override void appear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", original_pos, "time", 0.2f, "easeType", "easeOutCubic", "ignoretimescale", true));
    }
    public override void disappear()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", disappear_pos, "time", 0.2f, "easeType", "easeOutCubic", "ignoretimescale", true));
    }
}
