using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 리소스를 로드해놓습니다.
/// </summary>

public class ResourceLoad : MonoBehaviour
{
    public bool completed = false;
    public float progress = 0.0f;

    static Dictionary<string, GameObject> resource_dic;
    static Dictionary<int, CBulletPooler> pooler_dic;
    static Dictionary<string, Sprite> sprite_dic;

    //player resource
    PartyStatus current_party;
    GameObject[] player;
    GameObject cursor;

    //bullet resource
    CBulletPooler[] player_bullet_pooler;
    CBulletPooler bullet_pooler_enemy_F;
    CBulletPooler bullet_pooler_enemy_A;
    CBulletPooler bullet_pooler_enemy_N;
    CBulletPooler bullet_pooler_ice_witch_mirror;
    CBulletPooler bullet_pooler_ice_witch;

    //map resource
    QuestData questdata;
    MapData mapdata;
    GameObject[] map_ground;
    GameObject[] r_ground;
    GameObject[] map_sky;
    //GameObject[] r_sky;
    CMapPooler map_pooler;
    GameObject map_manager;

    //item resource
    GameObject item_heal;
    GameObject item_mana;
    GameObject item_coin;

    //hud resource
    GameObject matrix_screen;

    //effect resource
    GameObject splash;
    GameObject killed_effect;
    GameObject hit_fire;
    GameObject hit_leaf;
    GameObject hit_water;

    //skill resource
    GameObject[] eskill;

    //enemy resource
    GameObject Eye_F;
    GameObject Eye_A;
    GameObject Eye_N;

    GameObject Bat_F;
    GameObject Bat_A;
    GameObject Bat_N;

    GameObject Wall1_F;
    GameObject Wall2_F;
    GameObject Wall1_A;
    GameObject Wall2_A;
    GameObject Wall1_N;
    GameObject Wall2_N;

    GameObject Shooter_F;
    GameObject Shooter_N;
    GameObject Shooter_A;

    GameObject Cloud1;
    GameObject Cloud2;

    GameObject Gonyak_F;
    GameObject Gonyak_A;

    GameObject Bird_F;
    GameObject BIrd_A;
    GameObject Bird_N;
    GameObject BirdR_F;
    GameObject BirdR_A;
    GameObject BirdR_N;
    GameObject BirdL_F;
    GameObject BirdL_A;
    GameObject BirdL_N;
    GameObject BirdChain_F;
    GameObject BirdChain_A;
    GameObject BirdChain_N;
    GameObject ChampBird_F;
    GameObject ChampBird_A;
    GameObject ChampBird_N;
    GameObject ChampBat_F;
    GameObject ChampBat_A;
    GameObject ChampBat_N;
    GameObject ChampShooter_F;
    GameObject ChampShooter_A;
    GameObject ChampShooter_N;

    //boss resource
    GameObject Ifrit;
    GameObject ice_witch;
    GameObject[] ice_mass = new GameObject[3];
    GameObject deathra;

    // Sprite Resources
    Sprite exclamation;

    Sprite beam_head;

    UISlider me;

    // Use this for initialization
    void Start()
    {

        ////Debug.log("start load");
        ////Debug.log(Time.realtimeSinceStartup);

        me = gameObject.GetComponent<UISlider>();

        current_party = GameManager.User.party;

        DataManager.Get().QuestDatas.TryGetValue(GameManager.quest_num,out questdata);
        if (questdata == null)
        {
            ////Debug.log("quest data missing");
            GameObject.Find("GameManager").SendMessage("GotoMain");
        }
        resource_dic = new Dictionary<string, GameObject>();
        pooler_dic = new Dictionary<int, CBulletPooler>();
        sprite_dic = new Dictionary<string, Sprite>();

        //player
        player = new GameObject[3];
        //bullet
        player_bullet_pooler = new CBulletPooler[3];
        //map
        map_ground = new GameObject[13];
        r_ground = new GameObject[3];
        map_sky = new GameObject[13];
        map_pooler = ScriptableObject.CreateInstance<CMapPooler>();

        //skill
        eskill = new GameObject[3];

        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.0f);

        ////Debug.log("player");
        ////Debug.log(Time.realtimeSinceStartup);
        me.value = 0.0f;
        //player
        for (int i = 0; i < 3; i++)
        {
            if (current_party.member[i].char_name != "NULL")
            {
                //플레이어 프리팹
                player[i] = Resources.Load<GameObject>("Prefabs/Player/" + current_party.member[i].char_name);
                resource_dic.Add("player" + i.ToString(), player[i]);
                //불렛
                player_bullet_pooler[i] = ScriptableObject.CreateInstance<CBulletPooler>();
                player_bullet_pooler[i].PoolBullet(current_party.member[i]);
                pooler_dic.Add(i, player_bullet_pooler[i]);
                //스킬
                int skill = current_party.member[i].Askill_num;
                {
                    eskill[i] = Resources.Load<GameObject>("Prefabs/Skill/eskill_" + skill.ToString());
                    resource_dic.Add("eskill_" + skill.ToString(), eskill[i]);
                }
            }
            else
            {
                //플레이어 프리팹
                player[i] = null;
                //불렛
                player_bullet_pooler[i] = null;
                //스킬
                eskill[i] = null;
            }
        }
        cursor = Resources.Load<GameObject>("Prefabs/Player/hit_range");
        resource_dic.Add("cursor",cursor);

        ////Debug.log("bullet");
        ////Debug.log(Time.realtimeSinceStartup);

        me.value = 0.15f;
        yield return new WaitForSeconds(0.0f);

        //bullet resource
        bullet_pooler_enemy_F = ScriptableObject.CreateInstance<CBulletPooler>();
        bullet_pooler_enemy_F.PoolBullet("bullet_enemy_F", BulletMove.ENEMY_STRAIGHT);
        bullet_pooler_enemy_A = ScriptableObject.CreateInstance<CBulletPooler>();
        bullet_pooler_enemy_A.PoolBullet("bullet_enemy_A", BulletMove.ENEMY_STRAIGHT);
        bullet_pooler_enemy_N = ScriptableObject.CreateInstance<CBulletPooler>();
        bullet_pooler_enemy_N.PoolBullet("bullet_enemy_N", BulletMove.ENEMY_STRAIGHT);
        
        bullet_pooler_ice_witch_mirror = ScriptableObject.CreateInstance<CBulletPooler>();
        bullet_pooler_ice_witch_mirror.PoolBullet("bullet_IceWitch2", BulletMove.ENEMY_STRAIGHT);
		bullet_pooler_ice_witch = ScriptableObject.CreateInstance<CBulletPooler>();
		bullet_pooler_ice_witch.PoolBullet("bullet_IceWitch1", BulletMove.ENEMY_STRAIGHT);

        pooler_dic.Add(666, bullet_pooler_enemy_F);
        pooler_dic.Add(667, bullet_pooler_enemy_A);
        pooler_dic.Add(668, bullet_pooler_enemy_N);
        pooler_dic.Add(700, bullet_pooler_ice_witch_mirror);
        pooler_dic.Add(701, bullet_pooler_ice_witch);

        ////Debug.log("map");
        ////Debug.log(Time.realtimeSinceStartup);

        me.value = 0.3f;
        yield return new WaitForSeconds(0.0f);
        //map
        DataManager.Get().MapDatas.TryGetValue(questdata.MapIndex,out mapdata);
        if (mapdata == null)
        {
            ////Debug.log("map data missing");
            GameObject.Find("GameManager").SendMessage("GotoMain");
        }

        map_pooler.PoolMap(mapdata,"ground",ref map_ground);
        map_pooler.PoolMap(mapdata,"sky",ref map_sky);
        for (int i = 0; i < 13; i++)
        {
            resource_dic.Add("map_ground" + i.ToString(), map_ground[i]);
            resource_dic.Add("map_sky" + i.ToString(), map_sky[i]);
        }

        map_pooler.PoolMap(mapdata,"r_ground",ref r_ground);
        for (int i = 0; i < 3; i++)
        {
            resource_dic.Add("r_ground" + i.ToString(), r_ground[i]);
        }
        map_manager = Resources.Load<GameObject>("Prefabs/MapManager/MapManager" + questdata.MapIndex.ToString());
        map_manager = (GameObject)Instantiate(map_manager);
        map_manager.SetActive(false);
        resource_dic.Add("MapManager", map_manager);

        ////Debug.log("enemy");
        ////Debug.log(Time.realtimeSinceStartup);
        me.value = 0.6f;
        yield return new WaitForSeconds(0.0f);
        //enemy
        Eye_F = Resources.Load<GameObject>("Prefabs/Enemy/Eye_F");
        Eye_A = Resources.Load<GameObject>("Prefabs/Enemy/Eye_A");
        Eye_N = Resources.Load<GameObject>("Prefabs/Enemy/Eye_N");

        Bat_F = Resources.Load<GameObject>("Prefabs/Enemy/Bat_F");
        Bat_N = Resources.Load<GameObject>("Prefabs/Enemy/Bat_N");
        Bat_A = Resources.Load<GameObject>("Prefabs/Enemy/Bat_A");

        Wall1_F = Resources.Load<GameObject>("Prefabs/Enemy/Wall1_F");
        Wall1_A = Resources.Load<GameObject>("Prefabs/Enemy/Wall1_A");
        Wall1_N = Resources.Load<GameObject>("Prefabs/Enemy/Wall1_N");
        Wall2_F = Resources.Load<GameObject>("Prefabs/Enemy/Wall2_F");
        Wall2_A = Resources.Load<GameObject>("Prefabs/Enemy/Wall2_A");
        Wall2_N = Resources.Load<GameObject>("Prefabs/Enemy/Wall2_N");
        Shooter_F = Resources.Load<GameObject>("Prefabs/Enemy/Shooter_F");
        Shooter_N = Resources.Load<GameObject>("Prefabs/Enemy/Shooter_N");
        Shooter_A = Resources.Load<GameObject>("Prefabs/Enemy/Shooter_A");
        Cloud1 = Resources.Load<GameObject>("Prefabs/Enemy/Cloud1");
        Cloud2 = Resources.Load<GameObject>("Prefabs/Enemy/Cloud2");
        Gonyak_F = Resources.Load<GameObject>("Prefabs/Enemy/Gonyak_F");
        Gonyak_A = Resources.Load<GameObject>("Prefabs/Enemy/Gonyak_A");
        Bird_F = Resources.Load<GameObject>("Prefabs/Enemy/Bird_F");
        BIrd_A = Resources.Load<GameObject>("Prefabs/Enemy/BIrd_A");
        Bird_N = Resources.Load<GameObject>("Prefabs/Enemy/Bird_N");
        BirdR_F = Resources.Load<GameObject>("Prefabs/Enemy/BirdR_F");
        BirdR_A = Resources.Load<GameObject>("Prefabs/Enemy/BirdR_A");
        BirdR_N = Resources.Load<GameObject>("Prefabs/Enemy/BirdR_N");
        BirdL_F = Resources.Load<GameObject>("Prefabs/Enemy/BirdL_F");
        BirdL_A = Resources.Load<GameObject>("Prefabs/Enemy/BirdL_A");
        BirdL_N = Resources.Load<GameObject>("Prefabs/Enemy/BirdL_N");
        BirdChain_F = Resources.Load<GameObject>("Prefabs/Enemy/BirdChain_F");
        BirdChain_A = Resources.Load<GameObject>("Prefabs/Enemy/BirdChain_A");
        BirdChain_N = Resources.Load<GameObject>("Prefabs/Enemy/BirdChain_N");
        ChampBird_F = Resources.Load<GameObject>("Prefabs/Enemy/ChampBird_F");
        ChampBird_A = Resources.Load<GameObject>("Prefabs/Enemy/ChampBird_A");
        ChampBird_N = Resources.Load<GameObject>("Prefabs/Enemy/ChampBird_N");
        ChampBat_F = Resources.Load<GameObject>("Prefabs/Enemy/ChampBat_F");
        ChampBat_A = Resources.Load<GameObject>("Prefabs/Enemy/ChampBat_A");
        ChampBat_N = Resources.Load<GameObject>("Prefabs/Enemy/ChampBat_N");
        ChampShooter_F = Resources.Load<GameObject>("Prefabs/Enemy/ChampShooter_F");
        ChampShooter_A = Resources.Load<GameObject>("Prefabs/Enemy/ChampShooter_A");
        ChampShooter_N = Resources.Load<GameObject>("Prefabs/Enemy/ChampShooter_N");

        resource_dic.Add("Eye_F", Eye_F);
        resource_dic.Add("Eye_A", Eye_A);
        resource_dic.Add("Eye_N", Eye_N);
        resource_dic.Add("Bat_F", Bat_F);
        resource_dic.Add("Bat_N", Bat_N);
        resource_dic.Add("Bat_A", Bat_A);
        resource_dic.Add("Wall1_F", Wall1_F);
        resource_dic.Add("Wall1_A", Wall1_A);
        resource_dic.Add("Wall1_N", Wall1_N);
        resource_dic.Add("Wall2_F", Wall2_F);
        resource_dic.Add("Wall2_A", Wall2_A);
        resource_dic.Add("Wall2_N", Wall2_N);
        resource_dic.Add("Shooter_F", Shooter_F);
        resource_dic.Add("Shooter_N", Shooter_N);
        resource_dic.Add("Shooter_A", Shooter_A);
        resource_dic.Add("Cloud1", Cloud1);
        resource_dic.Add("Cloud2", Cloud2);
        resource_dic.Add("Gonyak_F", Gonyak_F);
        resource_dic.Add("Gonyak_A", Gonyak_A);
        resource_dic.Add("Bird_F",Bird_F); 
        resource_dic.Add("Bird_A",BIrd_A);
        resource_dic.Add("Bird_N",Bird_N);
        resource_dic.Add("BirdR_F",BirdR_F);
        resource_dic.Add("BirdR_A",BirdR_A);
        resource_dic.Add("BirdR_N",BirdR_N);
        resource_dic.Add("BirdL_F",BirdL_F);
        resource_dic.Add("BirdL_A",BirdL_A);
        resource_dic.Add("BirdL_N",BirdL_N);
        resource_dic.Add("BirdChain_F",BirdChain_F);
        resource_dic.Add("BirdChain_A",BirdChain_A);
        resource_dic.Add("BirdChain_N",BirdChain_N);
        resource_dic.Add("ChampBird_F",ChampBird_F);
        resource_dic.Add("ChampBird_A",ChampBird_A);
        resource_dic.Add("ChampBird_N",ChampBird_N);
        resource_dic.Add("ChampBat_F",ChampBat_F);
        resource_dic.Add("ChampBat_A",ChampBat_A);
        resource_dic.Add("ChampBat_N",ChampBat_N);
        resource_dic.Add("ChampShooter_F",ChampShooter_F);
        resource_dic.Add("ChampShooter_A",ChampShooter_A);
        resource_dic.Add("ChampShooter_N",ChampShooter_N);

        ////Debug.log("boss");
        ////Debug.log(Time.realtimeSinceStartup);
        //boss
        Ifrit = Resources.Load<GameObject>("Prefabs/Boss/Ifrit/Ifrit");
        resource_dic.Add("Ifrit", Ifrit);
        ice_witch = Resources.Load<GameObject>("Prefabs/Boss/IceWitch/IceWitch");
        resource_dic.Add("ice_witch", ice_witch);
        deathra = Resources.Load<GameObject>("Prefabs/Boss/Deathra/Deathra");
        resource_dic.Add("deathra", deathra);

        for (int i = 0; i < 3; i++)
        {
            ice_mass[i] = Resources.Load<GameObject>("Prefabs/Boss/IceWitch/IceMass" + (i + 1));
            resource_dic.Add("IceMass" + (i + 1), ice_mass[i]);
        }
        me.value = 0.75f;
        yield return new WaitForSeconds(0.0f);

        ////Debug.log("item");
        ////Debug.log(Time.realtimeSinceStartup);
        //item
        item_heal = Resources.Load<GameObject>("Prefabs/Item/item_heal");
        item_mana = Resources.Load<GameObject>("Prefabs/Item/item_mana");
        item_coin = Resources.Load<GameObject>("Prefabs/Item/item_coin");
        resource_dic.Add("item_heal", item_heal);
        resource_dic.Add("item_mana", item_mana);
        resource_dic.Add("item_coin", item_coin);

        ////Debug.log("effect");
        ////Debug.log(Time.realtimeSinceStartup);
        //effect
        splash = Resources.Load<GameObject>("Prefabs/Effect/Splash");
        resource_dic.Add("splash", splash);
        killed_effect = Resources.Load<GameObject>("Prefabs/Effect/killed_player");
        resource_dic.Add("killed_effect", killed_effect);
        hit_fire = Resources.Load<GameObject>("Prefabs/Effect/HIT_fire");
        resource_dic.Add("hit_fire", hit_fire);
        hit_leaf = Resources.Load<GameObject>("Prefabs/Effect/HIT_leaf");
        resource_dic.Add("hit_leaf", hit_leaf);
        hit_water = Resources.Load<GameObject>("Prefabs/Effect/HIT_water");
        resource_dic.Add("hit_water", hit_water);

        ////Debug.log("hud");
        ////Debug.log(Time.realtimeSinceStartup);
        //hud
        matrix_screen = Resources.Load<GameObject>("Prefabs/Hud/matrix_screen");
        resource_dic.Add("matrix_screen", matrix_screen);

        me.value = 0.9f;
        yield return new WaitForSeconds(0.0f);
        ////Debug.log("sprite");
        ////Debug.log(Time.realtimeSinceStartup);
        // Sprites
        exclamation = Resources.Load<Sprite>("Images/Exclamation");
        sprite_dic.Add("Exclamation", exclamation);

        me.value = 1.0f;
        beam_head = Resources.Load<Sprite>("Images/Enemy/Boss/BossBeam/beam2");
        sprite_dic.Add("beam_head", beam_head);

        completed = true;

        Destroy(GameObject.Find("UI Root"));
        Application.LoadLevelAdditive("ingame");
        GameObject.Find("GameManager").SendMessage("IntoStage");
        this.gameObject.SetActive(false);
        
        ////Debug.log("end load");
        ////Debug.log(Time.realtimeSinceStartup);
    }

    public static GameObject PickGameObject(string name)
    {
		if (resource_dic.ContainsKey (name) == false) 
		{
			return null;
		}
        return (GameObject)resource_dic[name];
    }

    public static CBulletPooler PickBulletPuller(int index)
    {
		if (pooler_dic.ContainsKey (index) == false) 
		{
			return null;
		}
        return pooler_dic[index];
    }

    public static Sprite PickSprite(string name)
    {
		if (sprite_dic.ContainsKey (name) == false) 
		{
			return null;
		}
        return (Sprite)sprite_dic[name];
    }

    public static bool ResetDic()
    {
        try
        {
            resource_dic.Clear();
            pooler_dic.Clear();
            sprite_dic.Clear();
        }
        catch
        {
            return false;
        }
        return true;
    }
}