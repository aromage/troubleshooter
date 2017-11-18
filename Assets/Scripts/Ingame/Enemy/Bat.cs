using UnityEngine;
using System.Collections;

public class Bat : CEnemy
{
    public override void SetMonsterType()
    {
        switch (gameObject.name)
        {
            case "Bat_F(Clone)":
                attribute = Attribute.FIRE;
                break;
            case "Bat_A(Clone)":
                attribute = Attribute.AQUA;
                break;
            case "Bat_N(Clone)":
                attribute = Attribute.NATURE;
                break;
            default:
                ////Debug.log("Enemy : Bat - Wrong Name");
                break;
        }
    }

    public override void SetItemDropRate()
    {
        heal_amount = 0;
        mana_amount = 1;
    }
}
