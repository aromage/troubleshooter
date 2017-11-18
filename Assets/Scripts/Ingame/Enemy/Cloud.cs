using UnityEngine;
using System.Collections;

public class Cloud : CEnemy
{
    public override void SetMonsterType()
    {
        switch (gameObject.name)
        {
            case "Cloud1(Clone)":
            case "Cloud2(Clone)":
                attribute = Attribute.EMPTY;
                break;
            default:
                ////Debug.log("Enemy : Cloud - Wrong Name");
                break;
        }
    }
}
