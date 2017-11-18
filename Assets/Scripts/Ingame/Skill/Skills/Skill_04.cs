using UnityEngine;
using System.Collections;

public class Skill_04 : MonoBehaviour {


    // Use this for initialization
    GameObject p_position;
    GameObject effect;
    Vector3 op = Vector3.zero;
 
    void Start()
    {
       
        p_position = GameObject.FindWithTag("player");


        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_4"));
        effect.transform.position = p_position.transform.position;
        StartCoroutine(Act());
        op.x = -60.0f;
    }

    void Update()
    {
       
        effect.transform.position = effect.transform.position = p_position.transform.position;
        
    }

    public IEnumerator Act()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.7f));

        GameObject[] bullet = GameObject.FindGameObjectsWithTag("bullet_enemy");
        foreach (GameObject bul in bullet)
            bul.SetActive(false);

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enm in enemy)
            enm.SendMessage("ApplyState", new float[3] { (float)State.Frozen, 100.0f, 2.0f });
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.5f));
        Destroy(effect);
        Destroy(this.gameObject);
        SKillManager.usedend(4);
        yield return null;
    }

 
}



