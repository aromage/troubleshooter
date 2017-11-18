using UnityEngine;
using System.Collections;

public class CHud : MonoBehaviour {


    public Vector3 original_pos, disappear_pos;

    public virtual void Init()
    {
        original_pos = gameObject.transform.position;
    }

    public virtual void appear()
    {

    }
    public virtual void disappear()
    {

    }
}
