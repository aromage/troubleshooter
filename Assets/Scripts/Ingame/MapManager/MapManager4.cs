using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager4 : MonoBehaviour
{
    [SerializeField]
    GameObject[] map_ground;
    [SerializeField]
    GameObject[] map_sky;
    [SerializeField]
    AudioSource bgm;


    int map_ground_count, map_sky_count;

   
    void OnEnable()
    {
        bgm = gameObject.GetComponent<AudioSource>();
        bgm.Play();
    }

    // Use this for initialization
    void Start()
    {
        map_ground_count = 13;
        map_sky_count = 13;

        map_ground = new GameObject[map_ground_count];
        for (int i = 0; i < map_ground_count; i++)
        {
            map_ground[i] = ResourceLoad.PickGameObject("map_ground" + i.ToString());
            if (map_ground[i] != null)
            {
                map_ground[i].GetComponent<CMap>().SetSpeed = 0;
                map_ground[i].gameObject.transform.position = new Vector3(0f, -640f + 2000f * i, 0f);
            }
        }

        map_sky = new GameObject[map_sky_count];
        for (int i = 0; i < map_sky_count; i++)
        {
            map_sky[i] = ResourceLoad.PickGameObject("map_sky" + i.ToString());
            if (map_sky[i] != null)
            {
                map_sky[i].GetComponent<CMap>().SetSpeed = 0;
                map_sky[i].gameObject.transform.position = new Vector3(0f, -640f + 2000f * i, 0f);
            }
        }

        for (int i = 0; i < map_ground_count; i++)
        {
            if (map_ground[i] != null)
            {
                map_ground[i].SetActive(true);
            }
        }

        for (int i = 0; i < map_sky_count; i++)
        {
            if (map_sky[i] != null)
            {
                map_sky[i].SetActive(true);
            }
        }
    }

    void StartMap()
    {
        StartCoroutine(ControlSpeed());
    }

    IEnumerator ControlSpeed()
    {
SetMapSpeed(map_ground, 1400);
        SetMapSpeed(map_sky, 1400);
        yield return new WaitForSeconds(2.4f);
        SetMapSpeed(map_ground, 200);
        SetMapSpeed(map_sky, 200);
        yield return new WaitForSeconds(85f);
        SetMapSpeed(map_ground, 200);
        SetMapSpeed(map_sky, 200);
        yield return new WaitForSeconds(20.45f);
        SetMapSpeed(map_ground, 0);
        SetMapSpeed(map_sky, 0);
    }

    void SetMapSpeed(GameObject[] map_, float speed_)
    {
        for (int i = 0; i < map_.Length; i++)
        {
            if (map_[i] != null)
            {
                map_[i].GetComponent<CMap>().SetSpeed = speed_;
            }
        }
    }

    void PauseBGM()
    {
        bgm.Pause();
    }

    void PlayBGM()
    {
        bgm.Play();
    }
}
