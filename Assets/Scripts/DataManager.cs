using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class DataManager : Singleton<DataManager>
{
    public DataManager()
    {
        CharDatas = CharacterData.Load("CharData");
        BulletDatas = BulletData.Load("BulletData");
        LevelDatas = LevelData.Load("LevelData");
        MapDatas = MapData.Load("MapData");
        QuestDatas = QuestData.Load("QuestData");
    }

    
    public UserData MyAccountUserData = new UserData();

    /////////////////////////////////// ////////////////////
    protected Dictionary<int, CharacterData> charDatas;

    public Dictionary<int, CharacterData> CharDatas
    {
        get { return charDatas; }
        protected set { charDatas = value; }
    }
    /////////////////////////////////// ////////////////////
    protected Dictionary<int, BulletData> bulletDatas;

    public Dictionary<int, BulletData> BulletDatas
    {
        get { return bulletDatas; }
        protected set { bulletDatas = value; }
    }
    /////////////////////////////////// ////////////////////
    protected Dictionary<int, LevelData> levelDatas;

    public Dictionary<int, LevelData> LevelDatas
    {
        get { return levelDatas; }
        protected set { levelDatas = value; }
    }
    /////////////////////////////////// ////////////////////
    protected Dictionary<int, MapData> mapDatas;

    public Dictionary<int, MapData> MapDatas
    {
        get { return mapDatas; }
        protected set { mapDatas = value; }
    }

    protected Dictionary<int, QuestData> questDatas;

    public Dictionary<int, QuestData> QuestDatas
    {
        get { return questDatas; }
        protected set { questDatas = value; }
    }

    public void DebugPrint()
    {
        var enumeratorChar = CharDatas.GetEnumerator();
        while (enumeratorChar.MoveNext())
        {
            var pair = enumeratorChar.Current;
            ////Debug.log("Key = " + pair.Key + " Datas = " + pair.Value);
        }

        var enumeratorBullet = BulletDatas.GetEnumerator();
        while (enumeratorBullet.MoveNext())
        {
            var pair = enumeratorBullet.Current;
            ////Debug.log("Key = " + pair.Key + " Datas = " + pair.Value);
        }

        var enumeratorLevel = LevelDatas.GetEnumerator();
        while (enumeratorLevel.MoveNext())
        {
            var pair = enumeratorLevel.Current;
            ////Debug.log("Key = " + pair.Key + " Datas = " + pair.Value);
        }

        var enumeratorMap = MapDatas.GetEnumerator();
        while (enumeratorMap.MoveNext())
        {
            var pair = enumeratorMap.Current;
            ////Debug.log("Key = " + pair.Key + " Datas = " + pair.Value);
        }

        var enumeratorQuest = QuestDatas.GetEnumerator();
        while (enumeratorQuest.MoveNext())
        {
            var pair = enumeratorQuest.Current;
            ////Debug.log("Key = " + pair.Key + " Datas = " + pair.Value);
        }

    }
}
