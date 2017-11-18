using UnityEngine;
using System.Collections;

public class HeadHunterCenterPanel : MonoBehaviour, IWindow 
{

    public UILabel Hp, Dps, Mana, ActiveSkill, Name, CurrLevel, MaxLevel, SkillCost, LevelUpGold, train;
    public UIButton Gradeup;

    public UIEventTrigger Back, Touch;
    public UIManager UIMRoot;

    public UISprite[] illust = new UISprite[4];
    public UISprite[] border = new UISprite[4];
    public UISprite illBack, attributepattern;
    
    public UISprite minisprite;
    

    public bool isActive { get; set; }
    public GameObject thisObject { get { return gameObject; } }
    public SceneType type { get { return SceneType.Main; } }




    public void Show()
    {
        isActive = true;
        thisObject.SetActive(true);
    }

    public void Hide()
    {
        isActive = false;
        thisObject.SetActive(false);
    }
	void Start()
    {
        UIMRoot = GameObject.Find("UI Manager").GetComponent<UIManager>();
        train.text = "훈련하기";
        EventDelegate.Add(Back.onClick, UIMRoot.gotoGuildManagement);
        EventDelegate.Add(Touch.onClick, UIMRoot.gotoGuildManagement);
        
    }
    public void miniSet(CharacterStatus cs)
    {
        Hp.text = cs.char_HP.ToString();
        Dps.text = (300 + (16 * (cs.My_Level-1))).ToString();
            //cs.char_ATK.ToString();
        CurrLevel.text = cs.My_Level.ToString();
        LevelUpGold.text = cs.My_exp.ToString();
        SkillCost.text = cs.Askill_MP.ToString();
        minisprite.spriteName = cs.char_name + "_idle_01";
        
        if(cs.My_Level == 60)
        {
            train.text = "최대레벨";
        }
        else if (cs.My_Level % 20 == 0)
        {
            train.text = "승급하기";
        }
        else
        {
            train.text = "훈련하기";
        }
    }

    public void SetData(CharacterStatus cs, int id)
    {


        Gradeup.GetComponent<GradeUpButton>().id = id;
        Hp.text = cs.char_HP.ToString();
        Dps.text = (300 + (16 * (cs.My_Level - 1))).ToString();
        Mana.text = cs.char_MP.ToString();
        ActiveSkill.text = cs.Askill_name;
        Name.text = cs.char_hanname;
        CurrLevel.text = cs.My_Level.ToString();
        MaxLevel.text = (((GameManager.charnum[id] / 100) % 100) * 20).ToString();
        LevelUpGold.text = cs.My_exp.ToString();
        SkillCost.text = cs.Askill_MP.ToString();
        minisprite.spriteName = cs.char_name + "_idle_01";
        if (cs.My_Level == 60)
        {
            train.text = "최대레벨";
        }
        else if (cs.My_Level % 20 == 0)
        {
            train.text = "승급하기";
        }
        else
        {
            train.text = "훈련하기";
        }
        

        string bordernum = "";
        for(int i=0; i<4; i++)
        {
            illust[i].spriteName = cs.char_name;
        }

        switch(cs.attribute)
        {
            case Attribute.FIRE:
                bordernum = "F";
                illBack.spriteName = "BgFire";
                attributepattern.spriteName = "fire";
                break;
            case Attribute.AQUA:
                bordernum = "W";
                illBack.spriteName = "BgAqua";
                attributepattern.spriteName = "water";
                break;
            case Attribute.NATURE:
                bordernum = "L";
                illBack.spriteName = "BgNature";
                attributepattern.spriteName = "leaf";
                break;
        }


        border[0].spriteName = bordernum + cs.char_name[cs.char_name.Length-1].ToString();
        border[1].spriteName = bordernum + "RT";
        border[2].spriteName = bordernum + "LB";
        border[3].spriteName = bordernum + "RB";


    }
}
