using UnityEngine;
using System.Collections;

public class PartyIconCollider : MonoBehaviour
{
    public int my_number;
    // Use this for initialization
    void Start()
    {
        
    }

    public void Init()
    {
        gameObject.GetComponent<UISprite>().spriteName = GameManager.User.party.member[my_number].char_name;
    }
    public void SetImage(string name)
    {
        gameObject.GetComponent<UISprite>().spriteName = name;
    }

    void OnDrop(GameObject dropped)
    {
        if(dropped.tag == "icon")
        {
            GameManager.PartyChange(my_number, dropped.GetComponent<CharacterButton>().my_id);
        }
    }

    public void OnClick()
    {
        GameObject.Find("UI Manager").GetComponent<UIManager>().SetCharacter(GameManager.User.party.member[my_number], GameManager.User.party.member[my_number].index);
        /*if(GameManager.SubtractParty(my_number))
        {
            gameObject.GetComponent<UISprite>().spriteName = "NULL";
        }*/
    }
}
