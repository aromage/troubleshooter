using UnityEngine;
using System.Collections;


/// <summary>
/// 0831 가장 많이바뀐 코드
/// </summary>

public class CIcon : CHud
{
    int num;
    public Attribute att;//속성
    public Vector3 saved_position;
    public Position my_number;

    GameObject player;
    GameObject Hud;
    public UILabel skilllabel;

    public bool check = false;
    GameObject[] checkicon = new GameObject[2];
    int checknum = 0;

    // Use this for initialization
    void Start()
    {
        saved_position = gameObject.transform.position;
        skilllabel = GameObject.Find("SkillCheck").GetComponent<UILabel>();
     }

    public void Swapped()
    {
        if (checknum != 0)
        {
            Position[] send = new Position[2];
            send[0] = my_number;
            send[1] = checkicon[0].GetComponent<CIcon>().my_number;

            player.SendMessage("ChangePosition", send);

            Position temp = my_number;
            my_number = checkicon[0].GetComponent<CIcon>().my_number;
            checkicon[0].GetComponent<CIcon>().my_number = temp;

            Vector3 temp_pos = saved_position;
            saved_position = checkicon[0].GetComponent<CIcon>().saved_position;
            checkicon[0].GetComponent<CIcon>().saved_position = temp_pos;

            temp_pos = disappear_pos;
            disappear_pos = checkicon[0].GetComponent<CIcon>().disappear_pos;
            checkicon[0].GetComponent<CIcon>().disappear_pos = temp_pos;

            SlowReturn();
            checkicon[0].GetComponent<CIcon>().SlowReturn();
        }
    }
    public void skillcheck()
    {
        
        int a = Hud.GetComponent<SKillManager>().ManaCheck((int)my_number);
        
        if(a != 0)
        {
            StartCoroutine("settext", a);
        }
    }

    IEnumerator settext(int a)
    {
        switch(a)
        {
            case 1:
                skilllabel.text = "마나가 부족해요";
                break;

            case 2:
                skilllabel.text = "지금은 쓸 수 없어요";
                break;
        }
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.5f));
        skilllabel.text = "";
    }
    

    IEnumerator EndMessage()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.6f));
    }

    public override void Init()
    {

        original_pos = gameObject.transform.position;
        disappear_pos = original_pos;
        disappear_pos.y = -1.2f;
        player = GameObject.Find("PlayerManager");
        Hud = GameObject.Find("StageManager");

        ////Debug.log(player.GetComponent<PlayerManager>().players_info[(int)my_number].char_name);
        gameObject.GetComponentInParent<UISprite>().spriteName = player.GetComponent<PlayerManager>().players_info[(int)my_number].char_name;
        gameObject.GetComponentInParent<UIButton>().normalSprite = player.GetComponent<PlayerManager>().players_info[(int)my_number].char_name;
        if (gameObject.GetComponentInParent<UISprite>().spriteName == "NONE")
        {
            gameObject.GetComponentInParent<UISprite>().height = 0;
            gameObject.GetComponentInParent<UISprite>().width = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            if (player.GetComponent<PlayerManager>().players[i].GetComponent<PlayerBase>().position == (Position)my_number)
            {
                num = i;
                break;
            }
        }
    }

    public override void appear()
    {
        iTween.MoveTo(gameObject.transform.parent.gameObject, iTween.Hash("position", saved_position, "time", 0.2f, "easeType", "easeOutCubic", "ignoretimescale", true));
    }
    public override void disappear()
    {
        iTween.MoveTo(gameObject.transform.parent.gameObject, iTween.Hash("position", disappear_pos, "time", 0.2f, "easeType", "easeOutCubic", "ignoretimescale", true));
    }
    
    public void Return()
    {
        iTween.MoveTo(gameObject.transform.parent.gameObject, iTween.Hash("position", saved_position, "time", 0.1f, "easeType", "easeOutCubic", "ignoretimescale", true));
    }
    public void SlowReturn()
    {
        iTween.MoveTo(gameObject.transform.parent.gameObject, iTween.Hash("position", saved_position, "time", 0.15f, "easeType", "easeOutCubic", "ignoretimescale", true));
        gameObject.GetComponentInParent<UIButton>().defaultColor = Color.white;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "icon")
        {
            ////Debug.log(coll.gameObject.name);
             checkicon[checknum] = coll.gameObject;
             checknum++;
             gameObject.GetComponentInParent<UIButton>().defaultColor = Color.Lerp(Color.white, Color.blue, 0.3f);
        }
    }
   void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "icon")
        {
            if (checknum == 2)
            {
                checkicon[0] = checkicon[1];
                checkicon[1] = null;
            }
            else if (checknum == 1)
            {
                checkicon[0] = null;
                gameObject.GetComponentInParent<UIButton>().defaultColor = Color.white;
        
            }
            checknum--;
        }
    }
}