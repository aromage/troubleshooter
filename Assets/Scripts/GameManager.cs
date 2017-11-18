using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        TITLE,//타이틀화면
        MAIN,//메인화면, 로비
        LOADING_STAGE,//로딩화면
        IN_STAGE,//인게임
        ESCAPE_STAGE//인게임 종료
    }

    public static float setting_sound;
    public static float setting_vibration;
    public static float setting_control;
    public static float setting_formation;

    //[데이터 정보]
    public static int ticket;
    public static UserData User;
    public static int quest_num = 0;
    public static CharacterStatus[] CharacterInfo;
    public static QuestData[] QuestInfo;
    LevelData leveldata;
    public static int[] charnum;
    public static int char_count, quest_count;
    public static int[] partynum = new int[3];
    public static bool firstInit;
    public static int muhanscore;
    public static bool lobbyin = false;

    [SerializeField]
    GameState state;
    [SerializeField]
    public static UIManager.ID main_state;
    [SerializeField]
    float current_timescale;

	// Use this for initialization
	void Awake ()
    {
        muhanscore = 0;
        
        DontDestroyOnLoad(this.gameObject);
        DataManager.Get();

	    state = GameState.TITLE;
        main_state = UIManager.ID.LOBBY;

        ModifySetting();
    
	    Application.targetFrameRate = 60;

        //UserData Initialize
        User = new UserData();
        User.Name = "임시";
        User.Level = 1;
        User.Gold = 1000000;
        User.Exp = 0;
        User.Ruby = 1000000;
        User.party.member  = new CharacterStatus[3];

        //temp chardata
        char_count = DataManager.Get().CharDatas.Count;
        quest_count = DataManager.Get().QuestDatas.Count - 1;
        CharacterInfo = new CharacterStatus[char_count];
        QuestInfo = new QuestData[quest_count];
        charnum = new int[char_count];
        CharacterData chardata;
        BulletData bulletdata;
        for (int i = 0; i < char_count; i++)
        {
            charnum[i] = (i + 1) * 10000 + 101;
            DataManager.Get().CharDatas.TryGetValue(i + 1, out chardata);
            DataManager.Get().LevelDatas.TryGetValue(charnum[i], out leveldata);
            if (chardata == null)
            {
                ////Debug.log("character data missing");

            }

            CharacterInfo[i].index = chardata.Index-1;
            CharacterInfo[i].My_Level = charnum[i]%100;
            CharacterInfo[i].My_exp = leveldata.Gold;
            CharacterInfo[i].char_name = chardata.ResourceName + ((charnum[i]/100)%100).ToString();
            CharacterInfo[i].char_hanname = chardata.Name;
            CharacterInfo[i].attribute = (Attribute)chardata.Attribute;
            CharacterInfo[i].char_MP = chardata.ManaPoint;
            CharacterInfo[i].char_HP = leveldata.HealthPoint + (User.Level*0.3f);
            CharacterInfo[i].char_ATK = leveldata.AttackPoint + (User.Level * 0.3f);
            CharacterInfo[i].char_SPD = chardata.Speed;
            CharacterInfo[i].Askill_num = chardata.SkillIndex;
            CharacterInfo[i].Askill_name = chardata.SkillName;
            CharacterInfo[i].Askill_info = chardata.SkillDesc;
            CharacterInfo[i].Askill_MP = chardata.SkillManaCost;
            CharacterInfo[i].bullet_num = chardata.BulletIndex;

            DataManager.Get().BulletDatas.TryGetValue(CharacterInfo[i].bullet_num, out bulletdata);
            if (bulletdata == null)
            {
                Debug.Log("bullet data missing");
                GameObject.Find("GameManager").SendMessage("GotoMain");
            }

            CharacterInfo[i].bullet_move_type = (BulletMove)bulletdata.MoveType;
            CharacterInfo[i].bullet_hit_type = (HitType)bulletdata.HitType;
            CharacterInfo[i].bullet_SPD = bulletdata.Speed;
            CharacterInfo[i].bullet_size = bulletdata.Size;
            CharacterInfo[i].shooting_way = bulletdata.MuzzleCount;
            CharacterInfo[i].shooting_angle = bulletdata.MuzzleAngle;
            CharacterInfo[i].shooting_amount = bulletdata.Amount;
            CharacterInfo[i].shooting_repeat = bulletdata.Repeat;
            CharacterInfo[i].shooting_delay = bulletdata.Delay;
            CharacterInfo[i].shooting_period = bulletdata.Period;
        }
        
        for (int i = 0; i < quest_count; i++)
        {
            DataManager.Get().QuestDatas.TryGetValue(i+1, out QuestInfo[i]);
            if (QuestInfo[i] == null)
            {
                //Debug.Log("퀘스트 불러오기 실패 : " + i.ToString());
            }
        }
    }

    public void SetRank(int exp)
    
    {
        while (User.Exp >= User.Level * 500)
        {
            User.Exp += exp;

            if (User.Exp >= User.Level * 500)
            {
                User.Exp -= User.Level * 500;
                User.Level++;
                for (int i = 0; i < char_count; i++)
                {
                    DataManager.Get().LevelDatas.TryGetValue(charnum[i], out leveldata);
                    CharacterInfo[i].char_HP = leveldata.HealthPoint + (1 + (User.Level * 0.03f));
                    CharacterInfo[i].char_ATK = leveldata.AttackPoint + (1 + (User.Level * 0.03f));
                    
                }
                for(int i=0; i<3; i++)
                {
                    User.party.member[i].char_HP = CharacterInfo[User.party.member[i].index].char_HP;
                    User.party.member[i].char_ATK = CharacterInfo[User.party.member[i].index].char_ATK;
                }
            }
        }
    }

    public void InitParty()
    {
        for (int i = 0; i < 3; i++)
        {
            User.party.member[i] = CharacterInfo[i];
            partynum[i] = i;
            SetPartyStatus();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (state)
        {
            case GameState.TITLE :
                if (Input.GetMouseButtonDown(0))
                {
                    GotoMain();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                    GotoMain();
                break;
            case GameState.MAIN:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    switch (main_state)
                    {
                        case UIManager.ID.LOBBY:
                            //Todo: 종료 확인
                            GameObject.Find("UI Manager").SendMessage("gotoGameEnd");
                            break;
                        case UIManager.ID.CONFIG:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        case UIManager.ID.STORE:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        case UIManager.ID.HEADHUNTER_CENTER:
                            GameObject.Find("UI Manager").SendMessage("gotoGuildManagement");
                            break;
                        case UIManager.ID.GUILD_MANAGEMENT:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        case UIManager.ID.STAGE_LIST:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        case UIManager.ID.GAME_READY:
                            GameObject.Find("UI Manager").SendMessage("gotoStagelist");
                            break;
                        case UIManager.ID.GAME_END:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        case UIManager.ID.MUHAN:
                            GameObject.Find("UI Manager").SendMessage("gotoLobby");
                            break;
                        default:
                            break;
                    }
                }
                break;
            case GameState.LOADING_STAGE:
                break;
            case GameState.IN_STAGE:
                break;
            case GameState.ESCAPE_STAGE:
                if (ResourceLoad.ResetDic())
                {
                    GotoMain();
                }
                break;
        }

	}

    // Title
    
    // Main
    public static void SetPartyStatus()
    {
        User.party.total_HP = User.party.member[0].char_HP + User.party.member[1].char_HP + User.party.member[2].char_HP;
        User.party.total_MP = User.party.member[0].char_MP + User.party.member[1].char_MP + User.party.member[2].char_MP;
        GameObject.Find("GuildManagementPanel(Clone)").GetComponent<GuildManagementPanel>().SetStatus();
    }

    public static bool SubtractParty(int party_num)
    {
        if(User.party.member[party_num].char_name != "NULL")
        {
            User.party.member[party_num].char_name = "NULL";
            partynum[party_num] = 1000;
            SetPartyStatus();
            return true;
        }
        return false;
    }

    public static void PartyChange(int party_num, int char_id)
    {
        GuildManagementPanel  gp = GameObject.Find("GuildManagementPanel(Clone)").GetComponent<GuildManagementPanel>();
        int memnum = party_num;
        for (int i = 0; i < 3; i++)
        {
            if (User.party.member[i].char_name == CharacterInfo[char_id].char_name)
                memnum = i;
        }
        if (memnum != party_num)
        {
            gp.party[memnum].GetComponent<PartyIconCollider>().SetImage("NULL");
            User.party.member[memnum].char_name = "NULL";
            partynum[memnum] = 1000;
        }

        gp.party[party_num].GetComponent<PartyIconCollider>().SetImage(CharacterInfo[char_id].char_name);
        User.party.member[party_num] = CharacterInfo[char_id];
        partynum[party_num] = char_id;

        SetPartyStatus();
       
    }

    public void LevelUpCharacter(int id)
    {
        DataManager.Get().LevelDatas.TryGetValue(charnum[id], out leveldata);
        if ((charnum[id] % 100) < ((charnum[id]/100)%100)*20)
        {
            if (User.Gold >= leveldata.Gold)
            {
                User.Gold -= leveldata.Gold;
                charnum[id]++;
                DataManager.Get().LevelDatas.TryGetValue(charnum[id], out leveldata);
                CharacterInfo[id].char_HP = leveldata.HealthPoint + (1 + (User.Level * 0.03f));
                CharacterInfo[id].char_ATK = leveldata.AttackPoint + (1 + (User.Level * 0.03f));
                CharacterInfo[id].My_Level = charnum[id] % 100;
                CharacterInfo[id].My_exp = leveldata.Gold;
                GameObject.Find("UI Manager").GetComponent<UIManager>().Set();
                GameObject.Find("HeadHunterCenterPanel(Clone)").GetComponent<HeadHunterCenterPanel>().miniSet(CharacterInfo[id]);
                
                for(int i=0; i<3; i++)
                {
                    if(partynum[i] == id)
                    {
                        User.party.member[i] = CharacterInfo[id];
                    }
                }
            }
        }
        else if (((charnum[id] % 100) == ((charnum[id] / 100) % 100) * 20) && (((charnum[id] / 100) % 100) < 3))
        {
            if (User.Gold >= leveldata.Gold)
            {
                User.Gold -= leveldata.Gold;
                charnum[id]++;
                charnum[id] += 100;
                DataManager.Get().LevelDatas.TryGetValue(charnum[id], out leveldata);
                CharacterInfo[id].char_name = CharacterInfo[id].char_name.Remove(CharacterInfo[id].char_name.Length - 1, 1);
                CharacterInfo[id].char_name += ((charnum[id] / 100) % 100).ToString();
                CharacterInfo[id].char_HP = leveldata.HealthPoint * (1 + (User.Level * 0.03f));
                CharacterInfo[id].char_ATK = leveldata.AttackPoint + (1 + (User.Level * 0.03f));
                CharacterInfo[id].My_Level = charnum[id] % 100;
                CharacterInfo[id].My_exp = leveldata.Gold;
                GameObject.Find("UI Manager").GetComponent<UIManager>().Set();
                GameObject.Find("HeadHunterCenterPanel(Clone)").GetComponent<HeadHunterCenterPanel>().SetData(CharacterInfo[id], id);
                
                BulletData bulletdata;
                DataManager.Get().BulletDatas.TryGetValue(charnum[id]/100, out bulletdata);
                if (bulletdata == null)
                {
                    ////Debug.log("bullet data missing");
                    GameObject.Find("GameManager").SendMessage("GotoMain");
                }

                CharacterInfo[id].bullet_move_type = (BulletMove)bulletdata.MoveType;
                CharacterInfo[id].bullet_hit_type = (HitType)bulletdata.HitType;
                CharacterInfo[id].bullet_SPD = bulletdata.Speed;
                CharacterInfo[id].bullet_size = bulletdata.Size;
                CharacterInfo[id].shooting_way = bulletdata.MuzzleCount;
                CharacterInfo[id].shooting_angle = bulletdata.MuzzleAngle;
                CharacterInfo[id].shooting_amount = bulletdata.Amount;
                CharacterInfo[id].shooting_repeat = bulletdata.Repeat;
                CharacterInfo[id].shooting_delay = bulletdata.Delay;
                CharacterInfo[id].shooting_period = bulletdata.Period;

                GameObject.Find("UI Manager").GetComponent<UIManager>().GuildManagementPanel.GetComponent<GuildManagementPanel>().CharacterButton[id].ChangeSprite(CharacterInfo[id].char_name);

                for (int i = 0; i < 3; i++)
                {
                    if (partynum[i] == id)
                    {
                        User.party.member[i] = CharacterInfo[id];
                    }
                }
            }
        }
    }



    public void GotoStage(int stage_num) // 인게임으로 넘길 정보 셋팅
    {
        if (stage_num < 1000)
        {
            if (User.Ruby >= QuestInfo[stage_num-1].StaminaCost)
            {
                quest_num = stage_num;

                Application.LoadLevel("loading");
                state = GameState.LOADING_STAGE;
                User.Ruby -= QuestInfo[stage_num-1].StaminaCost;
            }
            else
            {
                //Todo: 스테미너 부족 패널 띄우기
            }
        }
        else
        {
            quest_num = stage_num;

            Application.LoadLevel("loading");
            state = GameState.LOADING_STAGE;
        }
    }

    // Loading_Stage
    void IntoStage()
    {
        state = GameState.IN_STAGE;
    }

    // In_Stage
    public void EscapeStage()
    {
        state = GameState.ESCAPE_STAGE;
        lobbyin = true;
    }

    // Escape_Stage

    // 전체
    public void GotoMain()
    {
        Application.LoadLevel("main");
        BossManager1.boss_state = Ifrit.BossState.Intro; //임시 코드
        state = GameState.MAIN;
        Time.timeScale = 1.0f;
    }




    void ModifySetting()
    {
        //세팅에 대한 디비 없음 - 만들어야 함
        setting_sound = 0;
        setting_vibration = 0;
        setting_control = 0;
        setting_formation = 0;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
