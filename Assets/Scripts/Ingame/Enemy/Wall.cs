using UnityEngine;
using System.Collections;

public class Wall : CEnemy
{
    public override void SetMonsterType()
    {
        switch (gameObject.name)
        {
            case "Wall1_F(Clone)":
            case "Wall2_F(Clone)":
                attribute = Attribute.FIRE;
                break;
            case "Wall1_A(Clone)":
            case "Wall2_A(Clone)":
                attribute = Attribute.AQUA;
                break;
            case "Wall1_N(Clone)":
            case "Wall2_N(Clone)":
                attribute = Attribute.NATURE;
                break;
            default:
                ////Debug.log("Enemy : Wall - Wrong Name");
                break;
        }
    }

    public override void SetItemDropRate()
    {
        heal_amount = 1;
        mana_amount = 1;
    }
}
