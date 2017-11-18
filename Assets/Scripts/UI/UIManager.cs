using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour//Singleton<UIManager>
{
    public enum ID : int
    {
        ACCOUNT_INFO, // always show
        LOBBY,
        CONFIG, // stop
        STORE,  // stop
        HEADHUNTER_CENTER,
        GUILD_MANAGEMENT,
        STAGE_LIST,
        GAME_READY,
        GAME_END,
        MUHAN,
    };

    // UIs holder
    // open
    // close
    // 

    public GameObject AccountPanel;
    public GameObject GameReadyPanel;
    public GameObject GameEndPanel;
    public GameObject GuildManagementPanel;
    public GameObject HeadHunterCenterPanel;
    public GameObject LobbyPanel;
    public GameObject StageListPanel;
    public GameObject ShopPanel;
    public GameObject MuhanPanel;
    
    public AccountPanel                 Account;
    public GameReadyPanel               GameReady;
    public GameEndPanel                 GameEnd;
    public GuildManagementPanel         GuildManagement;
    public HeadHunterCenterPanel        HeadHunterCenter;
    public LobbyPanel                   Lobby;
    public StageListPanel               StageList;
    public ShopPanel                    Shop;
    public MuhanPanel                   Muhan;
    

    

    public Dictionary<UIManager.ID, IWindow> windows = new Dictionary<ID, IWindow>();
    private IWindow currentWindow;

    


    void Awake()
    {
       // DontDestroyOnLoad(this.gameObject);
        GameObject UIRoot = GameObject.Find("UI Root");
        

        AccountPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/AccountPanel") as GameObject);
        GameReadyPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/GameReadyPanel") as GameObject);
        GameEndPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/GameEndPanel") as GameObject);
        GuildManagementPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/GuildManagementPanel") as GameObject);
        HeadHunterCenterPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/HeadHunterCenterPanel") as GameObject);
        LobbyPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/LobbyPanel") as GameObject);
        StageListPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/StageListPanel") as GameObject);
        ShopPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/ShopPanel") as GameObject);
        MuhanPanel = NGUITools.AddChild(UIRoot, Resources.Load("Prefabs/UI/MuhanPanel") as GameObject);

        Account = AccountPanel.GetComponent<AccountPanel>();
        GameReady = GameReadyPanel.GetComponent<GameReadyPanel>();
        GameEnd = GameEndPanel.GetComponent<GameEndPanel>();
        GuildManagement = GuildManagementPanel.GetComponent<GuildManagementPanel>();
        HeadHunterCenter = HeadHunterCenterPanel.GetComponent<HeadHunterCenterPanel>();
        Lobby = LobbyPanel.GetComponent<LobbyPanel>();
        StageList = StageListPanel.GetComponent<StageListPanel>();
        Shop = ShopPanel.GetComponent<ShopPanel>();
        Muhan = MuhanPanel.GetComponent<MuhanPanel>();
        
        if (!windows.ContainsKey(ID.ACCOUNT_INFO))
        {
            windows.Add(ID.ACCOUNT_INFO, Account);
            windows.Add(ID.GAME_READY, GameReady);
            windows.Add(ID.GAME_END, GameEnd);
            windows.Add(ID.GUILD_MANAGEMENT, GuildManagement);
            windows.Add(ID.HEADHUNTER_CENTER, HeadHunterCenter);
            windows.Add(ID.LOBBY, Lobby);
            windows.Add(ID.STAGE_LIST, StageList);
            windows.Add(ID.STORE, Shop);
            windows.Add(ID.MUHAN, Muhan);
        }
        //Initialize temp;;
        if (!GameManager.firstInit)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().InitParty();
            GameManager.firstInit = true;
        }
        GameReady.Hide();
        GameEnd.Hide();
        GuildManagement.Hide();
        HeadHunterCenter.Hide();
        Lobby.Hide();
        StageList.Hide();
        Shop.Hide();
        Muhan.Hide();
        
        if(GameManager.lobbyin)
        {
            if (GameManager.quest_num == 1000)
            {
                gotoMuhan();
                GameManager.lobbyin = false;
            }
            else
            {
                gotoStagelist();
                GameManager.lobbyin = false;
            }
        }
        else
        {
            ChangeScene(ID.LOBBY);
        }
        StartCoroutine("updateAccountInfo");
    }

    public void gotoMuhan()
    {
        ChangeScene(ID.MUHAN);
        Muhan.Setting();
    }
    public void gotoShoplist()
    {
        ChangeScene(ID.STORE);
    }
    public void gotoStagelist()
    {
        ChangeScene(ID.STAGE_LIST);
    }
    public void gotoGameReady()
    {
        ChangeScene(ID.GAME_READY);
    }
    public void gotoGameEnd()
    {
        ChangeScene(ID.GAME_END);
    }
    public void gotoGuildManagement()
    {
        ChangeScene(ID.GUILD_MANAGEMENT);
        GameManager.SetPartyStatus();
        for(int i=0; i<3; i++)
        {
            GuildManagement.party[i].GetComponent<PartyIconCollider>().SetImage(GameManager.User.party.member[i].char_name); //고치기 힘듬
        }
    }
    public void gotoHeadHunterCenter()
    {
        ChangeScene(ID.HEADHUNTER_CENTER);
    }
    public void gotoLobby()
    {
        ChangeScene(ID.LOBBY);
    }
    public void gotoAccount()
    {
        ChangeScene(ID.ACCOUNT_INFO);
    }
    public void SetQuest(QuestData qd)
    {
        GameReady.SetData(qd);
    }
    public void SetCharacter(CharacterStatus cs, int id)
    {
        if (cs.char_name != "NULL")
        {
            HeadHunterCenter.SetData(cs, id);

            gotoHeadHunterCenter();
        }
    }
    public void Set()
    {
        Account.Name.text = GameManager.User.Name;
        Account.Rank.text = GameManager.User.Level.ToString();
        Account.Coin.text = GameManager.User.Gold.ToString();
        Account.CurrentStam.text = GameManager.User.Ruby.ToString();
        Account.Exp.value = GameManager.User.Exp;
    }
    public IEnumerator updateAccountInfo()
    {
        while(true)
        {
            Set();
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1.0f));
           
        }
    }


    public void ChangeScene(UIManager.ID newWindow)
    {

        Set();
        System.GC.Collect();

        GameManager.main_state = newWindow;

        IWindow prev = currentWindow;
        if (windows.ContainsKey(newWindow))
        {
            currentWindow = windows[newWindow];
        }
		if ( currentWindow == null)
		{
			return;
		}
        currentWindow.Show();

        if (null == prev)
        {
            return;
        }

        if (prev.isActive && SceneType.Popup != currentWindow.type)
            prev.Hide();
    }


}
