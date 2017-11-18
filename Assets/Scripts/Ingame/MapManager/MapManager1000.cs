using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager1000 : MonoBehaviour
{
    [SerializeField]
    GameObject[] ground;
    [SerializeField]
    AudioSource bgm;

    private List<CMap> mapScripts = new List<CMap>();

    private int ground_count;

    CMap GetNextMapTransform(int listIndex)
    {
        // 나보다 먼저 생성된 맵들의 최종위기 가져오기.
        for (int j = listIndex; 0 <= j; j--)
        {
            if (mapScripts[j].Type == mapScripts[listIndex].Type && mapScripts[j].gameObject.activeInHierarchy == true)
            {
                return mapScripts[j];
            }
        }

        // 나보다 먼저 생성된 맵들의 위치를 가져오지 못했을 경우는 늦은 순으로 생성된 맵들의 최종위치 가져오기.
        for (int j = mapScripts.Count - 1; 0 <= j; j--)
        {
            if (mapScripts[j].Type == mapScripts[listIndex].Type && mapScripts[j].gameObject.activeInHierarchy == true)
            {
                return mapScripts[j];
            }
        }
        return null;

    }
    void FixedUpdate()
    {
        for (int i = 0; i < mapScripts.Count; i++)
        {
            if (mapScripts[i].Type == CMap.MapType.GROUND)
            {
                if (mapScripts[i].gameObject.activeInHierarchy == false)
                {
                    CMap mapScript = GetNextMapTransform(i);

                    if (mapScript != null)
                    {
                        mapScripts[i].gameObject.transform.position = new Vector3(0f, mapScript.transform.position.y + 2000.0f, 0f);
                        mapScripts[i].gameObject.SetActive(true);
                    }

                }
            }
        }
    }
    void OnEnable()
    {
        bgm = gameObject.GetComponent<AudioSource>();
        bgm.Play();
    }

    // Use this for initialization
    void Start()
    {
        ground_count = 3;
        int offset = (int)Random.RandomRange(0.0f,3.0f);

        ground = new GameObject[ground_count];
        for (int i = 0; i < ground_count; i++)
        {
            ground[i] = ResourceLoad.PickGameObject("map_ground" + (i+offset*3).ToString());
            if (ground[i] != null)
            {
                CMap mapInfo = ground[i].GetComponent<CMap>();
                if (mapInfo == null)
                {
                    continue;
                }
                mapScripts.Add(mapInfo);
                mapInfo.SetSpeed = 0;
                mapInfo.Type = CMap.MapType.GROUND;

                if (mapScripts.Count <= 1)
                {
                    ground[i].gameObject.transform.position = new Vector3(0f, -640f, 0f);
                }
                else
                {
                    ground[i].gameObject.transform.position = new Vector3(0f,
                        mapScripts[mapScripts.Count - 2].gameObject.transform.position.y + 2000.0f, 0f);
                }
            }
        }

       

        for (int i = 0; i < ground_count; i++)
        {
            if (ground[i] != null)
            {
                ground[i].SetActive(true);
            }
        }
    }

    void StartMap()
    {
        StartCoroutine(ControlSpeed());
    }

    IEnumerator ControlSpeed()
    {
        SetMapSpeed(200);
        yield return null;
    }

    void SetMapSpeed(float speed_)
    {
        for (int i = 0; i < mapScripts.Count; i++)
        {
            if (mapScripts[i] != null)
            {
                mapScripts[i].SetSpeed = speed_;
            }
        }
    }
}
