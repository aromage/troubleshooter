using UnityEngine;
using System.Collections;

public class Skill_01 : MonoBehaviour 
{
    
    // Use this for initialization
    GameObject p_position;
    GameObject effect;
    void Start() 
    {
       
        
        effect = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_1"));
        if (effect == null)
        {
            return;
        }
        p_position = GameObject.FindWithTag("player");
        if (p_position == null)
        {
            return;
        }

        effect.transform.position = p_position.transform.position;
        StartCoroutine(Act());
        p_position = GameObject.FindWithTag("player");
      
    }

    void Update()
    {
        if (effect == null)
        {
            return;
        }
        if (p_position == null)
        {
            return;
        }
        effect.transform.position = p_position.transform.position;
    }

    public IEnumerator Act()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.9f));
        GameObject[] bullet = GameObject.FindGameObjectsWithTag("bullet_enemy");
        foreach (GameObject bul in bullet)
            bul.SetActive(false);
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enm in enemy)
            enm.SendMessage("ApplyDamage", new float[2]{GameManager.CharacterInfo[0].char_ATK*10, (float)Attribute.FIRE});
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.5f));
        Destroy(effect);
        Destroy(this.gameObject);
        SKillManager.usedend(1);
        yield return null;
    }


   
   
}