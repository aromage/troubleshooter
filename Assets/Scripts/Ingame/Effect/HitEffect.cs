using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMyself", 1f);
    }

    void DestroyMyself()
    {
        DestroyImmediate(gameObject);
    }
}
