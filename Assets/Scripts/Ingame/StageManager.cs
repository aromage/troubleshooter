using System.Text;
using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    enum StagePhase
    {
        INTRO,
        ENEMY,
        BOSS_INTRO,
        BOSS,
        FINISH,
        PAUSE
    }
    [SerializeField]
    StagePhase stage_phase;
    StagePhase temp_phase;
    float temp_timescale;
    [SerializeField]
    GameObject touch_panel;
    [SerializeField]
    GameObject map_manager;
    [SerializeField]
    GameObject enemy_manager;
    [SerializeField]
    GameObject boss_manager;
    [SerializeField]
    GameObject player_manager;
    [SerializeField]
    GameObject Hud_manager;

    QuestData questdata;
    public static int max_coin;
    public static int currnet_coin;
    public static int get_coin;
    public static int score;

    public static bool matrix_state;
    int forced_matrix_state; // 0 = 아무것도아님 1 = 강제 매트릭스 off 2 = 강제 매트릭스 on
    GameObject matrix_screen;
    [SerializeField]
    Color matrix_screen_color;
    [SerializeField]
    float matrix_timescale;

    public static GameObject DamageCount;
    bool first_check = false;
    public static int InfinityModeCount = 0;

    protected StringBuilder     strBuffer = new StringBuilder(64);
    // Use this for initialization
    void Start()
    {
        DataManager.Get().QuestDatas.TryGetValue(GameManager.quest_num, out questdata);
        if (questdata == null)
        {
            ////Debug.log("quest data missing");
            GameObject.Find("GameManager").SendMessage("GotoMain");
        }

        matrix_state = true;
        stage_phase = StagePhase.INTRO;
        score = 0;
        currnet_coin = 0;
        get_coin = 0;
        max_coin = questdata.MaxGold;
        InitStageManager();
        InitMatrixScreen();
        if (questdata.Mode == 0)
        {
            InfinityModeCount = 0;
        }
        else
        {
            InfinityModeCount = 1;
            ////Debug.log("Start Inifinity mode");

        }
        touch_panel = GameObject.Find("touch_Panel");
        DamageCount = (GameObject)Resources.Load("Prefabs/hud/DamageCount");
    }

    void Update()
    {
        if (stage_phase != StagePhase.PAUSE && stage_phase != StagePhase.FINISH)
        {
            MatrixCheck();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stage_phase != StagePhase.PAUSE && stage_phase != StagePhase.FINISH)
            {
                EnterPause();
            }
            else if (stage_phase == StagePhase.PAUSE)
            {
                ExitPause();
            }
        }
        switch (stage_phase)
        {
            case StagePhase.INTRO:
                forced_matrix_state = 1;
                if (!first_check)
                {
                    GameObject.FindWithTag("player").SendMessage("ForceMove", new Vector3(0, -200, 0));
                    first_check = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    stage_phase += 1;
                    first_check = false;
                }
                break;
            case StagePhase.ENEMY:
                {
                    StagePhaseEnemy();
                }
                break;
            case StagePhase.BOSS_INTRO:
                if (boss_manager.activeSelf == false)
                {
                    touch_panel.SetActive(false);
                    matrix_state = false;
                    forced_matrix_state = 1;
                    Hud_manager.SendMessage("disappear");
                    boss_manager.SetActive(true);
                    player_manager.SendMessage("StopShoot");
                }
                break;
            case StagePhase.BOSS:
                {
                    StagePhaseBoss();
                }
                break;
            case StagePhase.FINISH:
                matrix_state = false;
                if (touch_panel.activeSelf == true)
                {
                    screentouchon();
                    forced_matrix_state = 1;
                    touch_panel.SetActive(false);
                    player_manager.SendMessage("StopShoot");
                    if(GameObject.FindWithTag("player") != null)
                        GameObject.FindWithTag("player").SendMessage("ForceMove", new Vector3(0, 1500, 0));
                    SetMatrixOff();
                    if (InfinityModeCount == 0)
                    {
                        get_coin *= 10;
                    }
                    Hud_manager.SendMessage("SetReward");
                    GameManager.User.Gold += get_coin;
                    GameManager.User.Ruby += (InfinityModeCount-1);
                    Time.timeScale = 0.0f;
                }
                break;
            case StagePhase.PAUSE:
                if (!first_check)
                {
                    temp_timescale = Time.timeScale;
                    Time.timeScale = 0.0f;
                    touch_panel.SetActive(false);
 //                   map_manager.SendMessage("PauseBGM");
                    first_check = true;
                }
                break;
        }
    }

    protected void StagePhaseEnemy()
    {
        if (enemy_manager.activeSelf == false)
        {
            forced_matrix_state = 0;
            enemy_manager.SetActive(true);
            player_manager.SendMessage("StartShoot");
            map_manager.SendMessage("StartMap");
        }
    }

    protected void StagePhaseBoss()
    {
        if (touch_panel.activeSelf == false)
        {
            forced_matrix_state = 0;
            touch_panel.SetActive(true);
            player_manager.SendMessage("StartShoot");
            if (Input.GetMouseButton(0) == false)
            {
            	screentouchoff();
            }
        }
    }

    public void EnterPause()
    {
        Hud_manager.SendMessage("SetPause");
        temp_phase = stage_phase;
        stage_phase = StagePhase.PAUSE;
    }

    public void ExitPause()
    {
        Hud_manager.SendMessage("QuitPause");
        touch_panel.SetActive(true);
//        map_manager.SendMessage("PlayBGM");
        Time.timeScale = temp_timescale;
        stage_phase = temp_phase;
        first_check = false;
        if (Input.GetMouseButton(0) != true)
        {
            screentouchoff();
        }
    }

    public void EscapeFromPause()
    {
        Hud_manager.SendMessage("QuitPause");
        Time.timeScale = 1.0f;
        GameObject.Find("GameManager").SendMessage("EscapeStage");
    }

    void InitStageManager()
    {
        player_manager = new GameObject();
        player_manager.name = "PlayerManager";
        player_manager.AddComponent<PlayerManager>();

        Hud_manager = new GameObject();
        Hud_manager.name = "HudManager";
        Hud_manager.AddComponent<HudEventManager>();

        map_manager = ResourceLoad.PickGameObject("MapManager");
        map_manager.SetActive(true);

        enemy_manager = new GameObject();
        enemy_manager.name = "EnemyManager" + questdata.EnemySpawnType.ToString();
		enemy_manager.SetActive(false);
        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(enemy_manager, "Assets/Scripts/Ingame/StageManager.cs (240,9)", "EnemyManager" + questdata.EnemySpawnType.ToString());

        boss_manager = new GameObject();
        boss_manager.name = "BossManager" + questdata.Boss.ToString();
		boss_manager.SetActive(false);
        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(boss_manager, "Assets/Scripts/Ingame/StageManager.cs (245,9)", "BossManager" + questdata.Boss.ToString());
    }

    void MoveToBossIntro()
    {
        stage_phase = StagePhase.BOSS_INTRO;
    }

    void MoveToBossPhase()
    {
        stage_phase = StagePhase.BOSS;
    }

    void MoveToFinishPhase()
    {
        stage_phase = StagePhase.FINISH;
    }

    // 매트릭스 모드
    public void InitMatrixScreen()
    {
        matrix_timescale = 1.0f;

        //회색화면 초기화
        matrix_screen = (GameObject)Instantiate(ResourceLoad.PickGameObject("matrix_screen"));
        matrix_screen_color = matrix_screen.GetComponent<Renderer>().material.color;
        matrix_screen_color.a = 0.0f;
        matrix_screen.GetComponent<Renderer>().material.color = matrix_screen_color;
    }

    public void SetforcedMatrix(int n, float time)
    {
        forced_matrix_state = n;
        StartCoroutine("wait_forced", time);
    }

    IEnumerator wait_forced(float time)
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(time));
        forced_matrix_state = 0;
        if (Input.GetMouseButton(0) != true)
        {
            screentouchoff();
        }
    }

    void MatrixCheck()
    {
        if (forced_matrix_state == 0)
        {
            if (matrix_state == true)
            {
                if (matrix_timescale > 0.2f)
                {
                    SetMatrixOn();
                }
            }
            else if (matrix_state == false)
            {
                if (matrix_timescale < 1)
                {
                    SetMatrixOff();
                    if (matrix_timescale > 1f)
                    {
                        matrix_timescale = 1f;
                    }
                }
            }
        }
        else if(forced_matrix_state == 1)
        {
            matrix_state = false;
            if (matrix_timescale < 1)
            {
                SetMatrixOff();
                if (matrix_timescale > 1f)
                {
                    matrix_timescale = 1f;
                }
            }
        }
        else if(forced_matrix_state == 2)
        {
            matrix_state = true;
            if (matrix_timescale > 0.2f)
            {
                SetMatrixOn();
            }
        }
    }

    void SetMatrixOff()
    {
        matrix_timescale += 0.1f;
        matrix_screen_color.a -= 0.05f;
        matrix_screen.GetComponent<Renderer>().material.color = matrix_screen_color;
        Time.timeScale = matrix_timescale;
    }

    void SetMatrixOn()
    {
        matrix_timescale -= 0.1f;
        matrix_screen_color.a += 0.05f;
        matrix_screen.GetComponent<Renderer>().material.color = matrix_screen_color;
        Time.timeScale = matrix_timescale;
    }

    public void screentouchon()
    {
        matrix_state = false;
        Hud_manager.SendMessage("disappear");
    }

    public void screentouchoff()
    {
        if (forced_matrix_state != 1)
        {
            matrix_state = true;
            Hud_manager.SendMessage("appear");
        }
    }

    public void CallEnemyManager(int index)
    {
        // infinity mode용.
        stage_phase = StagePhase.ENEMY;

        strBuffer.Remove(0, strBuffer.Length);
        strBuffer.Append("EnemyManager");
        strBuffer.Append(index.ToString());

        DestroyImmediate(enemy_manager);

        enemy_manager = new GameObject();
        enemy_manager.name =  strBuffer.ToString();
        enemy_manager.SetActive(false);

        if (UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(enemy_manager, "Assets/Scripts/Ingame/StageManager.cs (382,13)", "EnemyManager" + index.ToString()) == null)
        {
            MoveToFinishPhase();
        }
        else
        {
            StagePhaseEnemy();
            if (questdata.Mode == 1) // infinity mode
            {
                currnet_coin = 0;
                InfinityModeCount++;    
            }
        }
    }
    public void CallBossManager(int index)
    {
        // infinity mode용.
        
        stage_phase = StagePhase.BOSS_INTRO;
        strBuffer.Remove(0, strBuffer.Length);
        strBuffer.Append("BossManager");
        strBuffer.Append(index.ToString());

        DestroyImmediate(boss_manager);

        boss_manager = new GameObject();
        boss_manager.name = strBuffer.ToString();
        boss_manager.SetActive(false);

        if (UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(boss_manager, "Assets/Scripts/Ingame/StageManager.cs (411,13)", "BossManager" + index.ToString() ) == null)
        {
            MoveToFinishPhase();
        }
        /*if (questdata.Mode == 1) // infinity mode
        {
            currnet_coin = 0;
            InfinityModeCount++;
        }*/
    }

    public void DestroyEnemyManager()
    {
        Destroy(enemy_manager);
    }
    public void DestroyBossManager()
    {
        Destroy(boss_manager);
    }
    public void BossDiverseFinish()
    {
        if (boss_manager != null)
        {
            boss_manager.SendMessage("OnBossDiverseFinish");
        }
        
    }
    public void OnBossDestroy()
    {
        if (boss_manager != null)
        {
            boss_manager.SendMessage("OnBossDestroy");
        }

    }

    public void OnBossAppeared()
    {
        if (boss_manager != null)
        {
            boss_manager.SendMessage("OnBossAppeared");
        }
    }
    //타임 스케일 표시

/*
    float timeleft;
    float accum;
    int frames;
    float fps;
    float updateInterval;
    int result;

    void OnGUI()
    {

        //FPS TEST CODE
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0f)
        {
            fps = accum / frames;
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
            result = (int)fps;
        }
        ////FPS TEST CODE

        float a = Time.timeScale;
        GUI.TextField(new Rect(200,0,40,20),result.ToString());
    }
 */

}