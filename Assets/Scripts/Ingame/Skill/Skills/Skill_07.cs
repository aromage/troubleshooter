using UnityEngine;
using System.Collections;

public class Skill_07 : MonoBehaviour {

    PlayerManager player;
    GameObject p_position;
    GameObject[] effect = new GameObject[5];
	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        p_position = GameObject.FindWithTag("player");

        StartCoroutine(Act());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Act()
    {
        for (int i = 0; i < 5; i++)
        {
            effect[i] = (GameObject)Instantiate(ResourceLoad.PickGameObject("eskill_7"));
        
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enm in enemy)
                enm.SendMessage("ApplyDamage", new float[2] { GameManager.CharacterInfo[0].char_ATK * 2, (float)Attribute.FIRE });
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.15f));
        }
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.5f));
        for (int i = 0; i < 5; i++)
        {
            Destroy(effect[i]);
        }
        Destroy(this.gameObject);
        SKillManager.usedend(7);
        yield return null;
    }
}
