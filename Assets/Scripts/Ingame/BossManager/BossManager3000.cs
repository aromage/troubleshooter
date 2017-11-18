using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossManager3000 : MonoBehaviour
{

    public static Deathra.DeathraState boss_state = Deathra.DeathraState.Intro;
    public static Deathra.WingState wing_state = Deathra.WingState.Intro;
    protected List<int> NextEnemyMgrIndices = new List<int>();
    void OnEnable()
    {
        if (NextEnemyMgrIndices.Count == 0)
        {
            NextEnemyMgrIndices.Add(1001);
            NextEnemyMgrIndices.Add(1002);
            NextEnemyMgrIndices.Add(1003);
            NextEnemyMgrIndices.Add(2001);
            NextEnemyMgrIndices.Add(2002);
            NextEnemyMgrIndices.Add(2003);
        }
        boss_state = Deathra.DeathraState.Intro;
        wing_state = Deathra.WingState.Intro;

        SummonDeathra();
    }

    void OnBossAppeared()
    {
        GameObject.Find("StageManager").SendMessage("MoveToBossPhase");
    }

    void SummonDeathra()
    {
        Instantiate(ResourceLoad.PickGameObject("deathra"), new Vector3(0f, 400f, 0f), Quaternion.identity);
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
