using UnityEngine;
using System.Collections;

public class CMapPooler : ScriptableObject
{
    public void PoolMap(MapData mapdata, string select, ref GameObject[] map)
    {
        GameObject temp_obj = new GameObject();
        temp_obj.AddComponent<CMap>();
        temp_obj.AddComponent<SpriteRenderer>();

        for (int i = 0; i < map.Length; i++)
        {
            switch (select)
            {
                case "ground":
                    if (mapdata.Ground[i] != 0)
                    {
                        map[i] = (GameObject)Instantiate(temp_obj);
                        map[i].SetActive(false);
                        map[i].gameObject.name = "ground_"+ mapdata.Ground[i];
                        map[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Map/ground_" + mapdata.Ground[i]);
                        map[i].gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "BG_bottom";
                    }
                    else
                        map[i] = null;
                    break;
                case "sky":
                    if (mapdata.Sky[i] != 0)
                    {
                        map[i] = (GameObject)Instantiate(temp_obj);
                        map[i].SetActive(false);
                        map[i].gameObject.name = "sky_" + mapdata.Sky[i];
                        map[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Map/sky_" + mapdata.Sky[i]);
                        map[i].gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "BG_upper";
                    }
                    else
                        map[i] = null;
                    break;
                case "r_ground":
                    if (mapdata.RandomGround[i] != 0)
                    {
                        map[i] = (GameObject)Instantiate(temp_obj);
                        map[i].SetActive(false);
                        map[i].gameObject.name = "r_ground_" + mapdata.RandomGround[i];
                        map[i].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Map/r_ground_" + mapdata.RandomGround[i]);
                        map[i].gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "BG_bottom";
                    }
                    else
                        map[i] = null;
                    break;
                default:
                    ////Debug.log("wrong map select");
                    break;
            }
        }
    }
}
