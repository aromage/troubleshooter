using UnityEngine;
using System.Collections;

public class CharacterButtonCollider : UIDragDropItem {

    [SerializeField]
    Collider m_collider;




    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();

        m_collider.enabled = false;

    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        m_collider.enabled = true;
    }

}
