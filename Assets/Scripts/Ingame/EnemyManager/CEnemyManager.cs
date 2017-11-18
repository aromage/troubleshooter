using UnityEngine;
using System.Collections;

public abstract class CEnemyManager : MonoBehaviour
{
    [SerializeField]
    private int boss_count;

    // Use this for initialization
    void Start()
    {
        ManageStage();
    }

    public abstract void ManageStage();

    public IEnumerator ClearEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        ////Debug.log("에너미 클리어");
        GameObject.Find("StageManager").SendMessage("MoveToBossIntro");
    }

    public IEnumerator AsClearBoss(float time)
    {
        GameObject[] boss;
        yield return new WaitForSeconds(time);
        boss = GameObject.FindGameObjectsWithTag("enemy");
        boss_count += boss.Length;
        for (int i = 0; i < boss.Length; i++)
        {
            while (boss[i] != null)
            {
                if (boss[i] != null)
                    yield return new WaitForSeconds(0.2f);
            }
            boss_count -= 1;
        }
        if (boss_count == 0)
        {
            yield return new WaitForSeconds(2.0f);
            GameObject.Find("StageManager").SendMessage("MoveToFinishPhase");
        }
        else if (boss_count  > 0)
        {
            Debug.Log("boss remain");
        }
        else
        {
            Debug.Log("Error");
        }

    }

    public IEnumerator SummonEnemy(float summon_time,
                            int number_of_summon,
                            EnemyStatus enemy_,
                            CEnemy.AI AI_type,
                            CEnemy.StartPosition start_position,
                            float delay = 0.5f,
                            int shooter_num = 0)
    {
        GameObject enemy;

        enemy = ResourceLoad.PickGameObject(enemy_.name.ToString());

        yield return new WaitForSeconds(summon_time);

        for (int formation = 0; formation < number_of_summon; formation++)
        {
            GameObject temp = (GameObject)Instantiate(enemy, CEnemy.GetStartPosition(start_position), Quaternion.identity);
            CEnemy temp_enemy = temp.GetComponent<CEnemy>();
            temp_enemy.Initialize(AI_type, enemy_.ATK, enemy_.HP, enemy_.SPD, enemy_.DEF, shooter_num, enemy_.coin_amount, enemy_.score);

            yield return new WaitForSeconds(delay);
        }
    }
}
