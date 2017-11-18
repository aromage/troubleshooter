using UnityEngine;
using System.Collections;

public class CMap : MonoBehaviour
{
    [SerializeField]
    float map_speed;
    public int re;

    public enum MapType : int
    {
        SKY     = 0,
        GROUND  = 1,
    }

    void Awake()
    {
        re = 0;
    }
	// Update is called once per frame
	void Update () {
		Move();
    }

    public float SetSpeed { set { map_speed = value; } }
    public MapType Type { get; set; }  
    void SetFirstPosition()
    {
        gameObject.transform.position = new Vector3(0,2000,0.0f);
    }

    void Move()
    {
        gameObject.transform.Translate(0.0f,-map_speed * Time.deltaTime,0.0f);
        if (gameObject.transform.position.y < -2640.0f)
        {
            // 얘를 top으로 올려보자
            gameObject.SetActive(false);
            
            if (re != 0)
            {
                gameObject.transform.Translate(0.0f,6000.0f,0.0f);
                gameObject.SetActive(true);
 //               re -= 1;
            }
        }
    }
}
