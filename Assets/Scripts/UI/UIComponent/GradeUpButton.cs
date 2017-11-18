using UnityEngine;
using System.Collections;

public class GradeUpButton : MonoBehaviour {

    public int id;
	// Use this for initialization
	void Start () {
	
	}
	
	public void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LevelUpCharacter(id);
    }
}
