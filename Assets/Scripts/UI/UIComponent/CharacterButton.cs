using UnityEngine;
using System.Collections;

public class CharacterButton : MonoBehaviour {


    public int my_id, coin;

	// Use this for initialization
	void Start () {
	    
	}

   

    public void InitializeButton(int index)
    {
        my_id = index;
    }

    public void ChangeSprite(string name)
    {
        gameObject.GetComponent<UIButton>().normalSprite = name;
    }

    public void OnClick()
    {
        GameObject.Find("UI Manager").GetComponent<UIManager>().SetCharacter(GameManager.CharacterInfo[my_id], my_id);
    }
}
