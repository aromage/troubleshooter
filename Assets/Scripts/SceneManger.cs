using UnityEngine;
using System.Collections;


public class SceneManger : MonoBehaviour {

    private static SceneManger s_instance;

    static SceneManger()
    {
        GameObject newGameObject = new GameObject();
        newGameObject.name = "_SceneManager";
        s_instance = newGameObject.AddComponent<SceneManger>();
    }

    public static SceneManger instance { get{return s_instance;} }

    private int next_scene_idx;
    private Texture2D fade_color_texture;
    private float fade_factor = 0.0f;
    private float fade_timepersec = 0.0f;
    private Color fade_color;

    //Delegates
    private delegate void SceneUpdate();
    private delegate void SceneGUI();
    private SceneUpdate scene_update;
    private SceneGUI scene_gui;

    private int loading_next_scene = 0;

    private string loading_scene = null;

    void Awake()
    {
        //씬이 변경되어도 파괴되지 않도록 함
        DontDestroyOnLoad(this.gameObject);

        //Color Fade Texture 생성
        this.fade_color_texture = new Texture2D(
        1,//pixel X
        1,//pixel Y
        TextureFormat.RGB24,//format
        false,//밉맵체인 사용여부
        false//필터 여부
        );

        //생성된 텍스쳐의 0,0 pixel의 색상을 white로
        this.fade_color_texture.SetPixel(0,0,Color.white);
    }
	
	// Update is called once per frame
	void Update () {
	    if(this.scene_update != null)
        this.scene_update();
	}

    void OnGUI()
    {
        if(this.scene_gui != null)
        this.scene_gui();
    }

    //효과 없이 씬 변경
    public void ChangeScene(int scene_idx)
    {
        Application.LoadLevel(scene_idx);
    }

    //로딩씬이 있는 씬 변경
    public void ChangeScene(string loading_scene, int scene_idx)
    {
        Application.LoadLevel(loading_scene);
        this.loading_next_scene = scene_idx;
    }

    //fade를 이용하여 씬 변경
    public void ChangeSceneOnFadeColor(int scene_idx, Color fade_color, float time)
    {
        this.next_scene_idx = scene_idx;
        this.fade_color = fade_color;
        this.fade_timepersec = 1.0f/time;
        this.scene_update = new SceneUpdate(ColorFadeIn);
        this.scene_gui = new SceneGUI(ColorFadeGUI);
    }

    public void ChangeSceneOnFadeColor(int loading_scene, int scene_idx, Color fade_color, float time)
    {
        ChangeSceneOnFadeColor(loading_scene,fade_color,time);
        this.loading_next_scene = scene_idx;
    }

    private void ColorFadeIn()
    {
        this.fade_factor += Time.unscaledDeltaTime * this.fade_timepersec;

        if(this.fade_factor >= 1.0f)
        {
            if(this.loading_scene != null)
            {
                this.ChangeScene(loading_scene,this.next_scene_idx);
                this.loading_scene = null;
            }
            else { this.ChangeScene(this.next_scene_idx);}
            this.scene_update = new SceneUpdate(ColorFadeOut);
            this.fade_factor = 1.0f;
        }
    }

    private void ColorFadeOut() 
    { 
        this.fade_factor -= Time.unscaledDeltaTime * this.fade_timepersec;
        if(this.fade_factor<=0.0f)
        {
            this.scene_update = null;
            this.scene_gui = null;
            this.fade_factor = 0.0f;
        }
    }

    private void ColorFadeGUI() 
    { 
        GUI.color = new Color(this.fade_color.r,this.fade_color.g,this.fade_color.b,this.fade_factor);

        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),this.fade_color_texture);
    }

    public int LoadAfterScene { get { return this.loading_next_scene;} }

    public float FadeFactor { get { return this.fade_factor;} }
}