using UnityEngine;
using System.Collections;

public class Gonyak : CEnemy
{
    public override void SetMonsterType()
    {
        switch (gameObject.name)
        {
            case "Gonyak_F(Clone)":
                attribute = Attribute.FIRE;
                break;
            case "Gonyak_A(Clone)":
                attribute = Attribute.AQUA;
                break;
            case "Gonyak_N(Clone)":
                attribute = Attribute.NATURE;
                break;
            default:
                ////Debug.log("Enemy : Gonyak - Wrong Name");
                break;
        }
    }
    public override void SetItemDropRate()
    {
        heal_amount = 1;
        mana_amount = 0;
    }
}