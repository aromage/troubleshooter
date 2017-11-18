using UnityEngine;
using System.Collections;

public partial class HudEventManager : MonoBehaviour
{
   int icontouched = 0;

   public static bool IsSkill = false;

    //temp
   GameObject icon_temp;

    //Hud
    public GameObject player_hp_bar;
    public GameObject boss_hp_bar;
    public GameObject player_Mp_bar;
    public CIcon []icon = new CIcon[3];
    public GameObject pause;
    public GameObject score;
    public GameObject leader_frame;
    public GameObject Damaged, HudPanel;
    public GameObject RewardPanel, PausePanel;
    
    public static int playernum;

	// Use this for initialization
	void Start () {

        RewardPanel = NGUITools.AddChild(GameObject.Find("UI Root"), Resources.Load("Prefabs/UI/RewardPanel") as GameObject);
        RewardPanel.GetComponent<RewardPanel>().Hide();
        PausePanel = NGUITools.AddChild(GameObject.Find("UI Root"), Resources.Load("Prefabs/UI/PausePanel") as GameObject);
        PausePanel.GetComponent<PausePanel>().Hide();

        
        HudPanel = GameObject.Find("HudPanel");
        player_hp_bar = GameObject.Find("Player_Hp_Bar");
        player_Mp_bar = GameObject.Find("Player_Mp_Bar");
        boss_hp_bar = GameObject.Find("Boss_Hp_Bar");
        boss_hp_bar.SetActive(false);
        pause = GameObject.Find("Pause");
        score = GameObject.Find("Score");
        leader_frame = GameObject.Find("leader_frame");
        Damaged = GameObject.Find("Damaged");
        Damaged.GetComponent<UISprite>().alpha = 0.0f;


        player_hp_bar.SendMessage("Init");
        player_Mp_bar.SendMessage("Init");
        pause.SendMessage("Init");

        GameObject player = GameObject.Find("PlayerManager");
        playernum = player.GetComponent<PlayerManager>().member_count;
        for (int i = 0; i < playernum; i++)
        {
            icon_temp = NGUITools.AddChild(GameObject.Find("Icon_Panel"), Resources.Load("Prefabs/hud/icon_prefab") as GameObject);
            icon[i] = icon_temp.transform.Find("collider").GetComponent<CIcon>();

            Vector3 t_Pos = new Vector3();
            switch(i)
            { 
                case 0:
                    t_Pos.x = 0.0f;
                    t_Pos.y = -0.86f;
                    t_Pos.z = 0.0f;
                    break;
                case 1:
                    t_Pos.x = -0.25f;
                    t_Pos.y = -0.86f;
                    t_Pos.z = 0.0f;
                    break;
                case 2:
                    t_Pos.x = 0.25f;
                    t_Pos.y = -0.86f;
                    t_Pos.z = 0.0f;
                    break;
            }
            icon_temp.transform.position = t_Pos;
            icon[i].my_number = (Position)i;
            icon[i].Init();
        }
        leader_frame.SendMessage("Init");
	}

    public void Boss_Hp_Create(GameObject g)
    {
        boss_hp_bar.SetActive(true);
        boss_hp_bar.SendMessage("SetHp", g);
    }

    public void Boss_Hp_Delete()
    {
        boss_hp_bar.SendMessage("SetOff");

        boss_hp_bar.SetActive(false);
    }
    
    public void SetPause()
    {
        PausePanel.GetComponent<PausePanel>().Show();
    }

    public void QuitPause()
    {
        PausePanel.GetComponent<PausePanel>().Hide();
    }

    void SetReward()
    {
        QuestData qd;
        DataManager.Get().QuestDatas.TryGetValue( GameManager.quest_num, out qd);
        
        RewardPanel.GetComponent<RewardPanel>().Show();
        if (qd.Index == 1000)
        {
            RewardPanel.GetComponent<RewardPanel>().stage_sprite.SetActive(false);
            RewardPanel.GetComponent<RewardPanel>().Stage.text = "무한모드";
            RewardPanel.GetComponent<RewardPanel>().Level.text = "Level - " + StageManager.InfinityModeCount.ToString();
        }
        else
        {
            RewardPanel.GetComponent<RewardPanel>().Level.text = "";
            RewardPanel.GetComponent<RewardPanel>().Stage.text = "Stage" + qd.Index.ToString() + "-" + qd.Name;
        }
        RewardPanel.GetComponent<RewardPanel>().Score.text = StageManager.score.ToString();
        RewardPanel.GetComponent<RewardPanel>().Coin.text = StageManager.get_coin.ToString();
        string rankname;
        if(StageManager.score < qd.GoodScore)
        {
            rankname = "bad";
        }
        else if(StageManager.score < qd.GreatScore)
        {
            rankname = "good";
        }
        else
        {
            rankname = "great";
        }
        RewardPanel.GetComponent<RewardPanel>().Rank.spriteName = rankname;

        if(qd.Index == 1000)
        {
            if(GameManager.muhanscore < StageManager.score)
                GameManager.muhanscore = StageManager.score;
        }
    }

    void appear()
    {

        player_hp_bar.SendMessage("appear");
        player_Mp_bar.SendMessage("appear");
        pause.SendMessage("appear");
        for (int i = 0; i < playernum; i++)
            icon[i].appear();
        leader_frame.SendMessage("appear");
    }

    void disappear()
    {

        player_hp_bar.SendMessage("disappear");
        player_Mp_bar.SendMessage("disappear");
        pause.SendMessage("disappear");
        for (int i = 0; i < playernum; i++)
            icon[i].disappear();
        leader_frame.SendMessage("disappear");
    }

    public void skill_abandoned(string a)
    {

    }


    void damaged()
    {
        Damaged.GetComponent<UISprite>().alpha = 0.0f;
        StopCoroutine("DamagedSprite");
        StartCoroutine("DamagedSprite");
    }

    IEnumerator DamagedSprite()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", 0.3f, "onupdate", "alphavaluechange", "ignoretimescale", true));
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.4f));
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0.0f, "time", 0.3f, "onupdate", "alphavaluechange", "ignoretimescale", true));
        yield return null;
    }

    void alphavaluechange(float a)
    {
        Damaged.GetComponent<UISprite>().alpha = a;
    }
}
