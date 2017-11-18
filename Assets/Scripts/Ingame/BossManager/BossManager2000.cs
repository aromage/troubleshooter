using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossManager2000 : MonoBehaviour
{

    public static IceWitch.IceWitchState boss_state = IceWitch.IceWitchState.Intro;
    public static Mirror.MirrorState mirror_state = Mirror.MirrorState.Intro;
    protected List<int> NextEnemyMgrIndices = new List<int>();

    void OnEnable()
    {
        if (NextEnemyMgrIndices.Count == 0)
        {
            NextEnemyMgrIndices.Add(1001);
            NextEnemyMgrIndices.Add(1002);
            NextEnemyMgrIndices.Add(1003);
            NextEnemyMgrIndices.Add(3001);
            NextEnemyMgrIndices.Add(3002);
            NextEnemyMgrIndices.Add(3003);
        }

        boss_state = IceWitch.IceWitchState.Intro;
        mirror_state = Mirror.MirrorState.Intro;

        SummonIceWitch();
    }

    void OnBossAppeared()
    {
        GameObject.Find("StageManager").SendMessage("MoveToBossPhase");
    }

    void SummonIceWitch()
    {
        Instantiate(ResourceLoad.PickGameObject("ice_witch"), new Vector3(0f, 200f, 0f), Quaternion.identity);
    }

    void OnBossDestroy()
    {
        if (NextEnemyMgrIndices.Count == 0)
        {
            ////Debug.log("에러 상황: count is zero");
            return;
        }
        else
        {
            int Index = UnityEngine.Random.Range(0, NextEnemyMgrIndices.Count);

            GameObject.Find("StageManager").SendMessage("CallEnemyManager", (int)NextEnemyMgrIndices[Index]);
            GameObject.Find("StageManager").SendMessage("DestroyBossManager");
        }
    }
}
