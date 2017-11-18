using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossManager1000 : MonoBehaviour
{

    public static Ifrit.BossState boss_state = Ifrit.BossState.Intro;

    [SerializeField]
    Sprite[] circle = new Sprite[2];
    [SerializeField]
    Sprite[] flash = new Sprite[4];
    [SerializeField]
    Sprite screen;

    protected List<int> NextEnemyMgrIndices = new List<int>();
    void OnEnable()
    {
        if (NextEnemyMgrIndices.Count == 0)
        {
            NextEnemyMgrIndices.Add(2001);
            NextEnemyMgrIndices.Add(2002);
            NextEnemyMgrIndices.Add(2003);
            NextEnemyMgrIndices.Add(3001);
            NextEnemyMgrIndices.Add(3002);
            NextEnemyMgrIndices.Add(3003);
        }
        SummonBoss();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        for (int i = 0; i < 2; i++)
        {
            circle[i] = Resources.Load<Sprite>("Images/Enemy/Boss/Circle" + (i + 1));
            yield return null;
        }

        for (int i = 0; i < 4; i++)
        {
            flash[i] = Resources.Load<Sprite>("Images/Enemy/Boss/Flash" + (i + 1));
            yield return null;
        }

        screen = Resources.Load<Sprite>("Images/Enemy/Boss/screen");
    }

    void OnBossDiverseFinish()
    {
        GameObject.Find("StageManager").SendMessage("MoveToBossPhase");
        ////Debug.log("Boss Diversion Event Finished");
    }

    // Boss 소환
    void SummonBoss()
    {
        Instantiate(ResourceLoad.PickGameObject("Ifrit"), new Vector3(0f, 200f, 0f), Quaternion.identity);
    }

    void OnBossDestroy()
    {
        StartCoroutine(BossDestroyDelay());
    }
    IEnumerator BossDestroyDelay()
    {
        Transform boss = GameObject.Find("Ifrit(Clone)").transform;

        GameObject circle0 = new GameObject();
        circle0.name = "circle0";
        circle0.AddComponent<SpriteRenderer>();
        circle0.transform.position = boss.position + new Vector3(0f, 15f, 0f);
        SpriteRenderer circle0_renderer = circle0.GetComponent<SpriteRenderer>();
        circle0.GetComponent<Renderer>().sortingLayerName = "Skill";

        GameObject circle1 = new GameObject();
        circle1.name = "circle1";
        circle1.AddComponent<SpriteRenderer>();
        circle1.transform.position = boss.position + new Vector3(0f, 15f, 0f);
        SpriteRenderer circle1_renderer = circle1.GetComponent<SpriteRenderer>();
        circle1.GetComponent<Renderer>().sortingLayerName = "Skill";

        GameObject flash_ = new GameObject();
        flash_.name = "flash";
        flash_.AddComponent<SpriteRenderer>();
        flash_.transform.position = boss.position + new Vector3(0f, 15f, 0f);
        SpriteRenderer flash_renderer = flash_.GetComponent<SpriteRenderer>();
        flash_.GetComponent<Renderer>().sortingLayerName = "Skill";

        GameObject screen_ = new GameObject();
        screen_.name = "screen";
        screen_.AddComponent<SpriteRenderer>();
        screen_.transform.position = Vector3.zero;
        SpriteRenderer screen_renderer = screen_.GetComponent<SpriteRenderer>();
        screen_.GetComponent<Renderer>().sortingLayerName = "Screen";

        int frame_counter = 0;

        while (frame_counter < 20)
        {
            switch (frame_counter)
            {
                case 0:
                    flash_renderer.sprite = flash[0];
                    break;
                case 2:
                    circle1_renderer.sprite = circle[1];
                    circle1.transform.localScale *= 0.06f;
                    Hashtable command = iTween.Hash("scale", new Vector3(1.1f, 1.1f, 1.1f), "time", 1.1f);
                    iTween.ScaleTo(circle1, command);
                    break;
                case 3:
                    flash_renderer.sprite = flash[1];
                    break;
                case 6:
                    flash_renderer.sprite = flash[2];
                    break;
                case 7:
                    screen_renderer.sprite = screen;

                    Color color = screen_renderer.color;
                    color.a = 1f;
                    screen_renderer.color = color;

                    command = iTween.Hash("alpha", 0f, "time", 0.4f, "easetype", iTween.EaseType.linear);
                    iTween.FadeFrom(screen_, command);

                    break;
                case 8:
                    circle0_renderer.sprite = circle[0];
                    circle0.transform.localScale *= 0.15f;
                    command = iTween.Hash("scale", new Vector3(0.75f, 0.75f, 0.75f), "time", 0.7f);
                    iTween.ScaleTo(circle0, command);

                    break;
                case 9:
                    flash_renderer.sprite = flash[3];
                    break;
                case 13:
                    Destroy(circle1);
                    break;
                case 15:
                    circle0.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    break;
                case 17:
                    iTween.Stop(screen_);

                    color = screen_renderer.color;
                    color.a = 0f;
                    screen_renderer.color = color;

                    command = iTween.Hash("alpha", 1f, "time", 2f);

                    iTween.FadeFrom(screen_, command);

                    Destroy(circle0);
                    Destroy(flash_);
                    break;
            }

            frame_counter++;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);
        Destroy(screen_);
        yield return new WaitForSeconds(1f);

        BossManager1.boss_state = Ifrit.BossState.Intro;
        if (NextEnemyMgrIndices.Count == 0)
        {
            ////Debug.log("에러 상황: count is zero");
            yield break;
        }
        else
        {
            int Index = UnityEngine.Random.Range(0, NextEnemyMgrIndices.Count);

            GameObject.Find("StageManager").SendMessage("CallEnemyManager", (int)NextEnemyMgrIndices[Index]);
            GameObject.Find("StageManager").SendMessage("DestroyBossManager");    
        }
    }
}
