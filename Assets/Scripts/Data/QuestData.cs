using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public class QuestData
{
    public int      Index;
    public string   Name;
    public int      MapIndex;
    public int      Mode;               // 0 normal 1 infinity
    public string   Description;
    

    public int      StaminaCost;
    public int      EnemySpawnType;
    public int      Boss;
    public int      MaxGold;
    public int      GoodScore;
    public int      GreatScore;


    public static Dictionary<int, QuestData> Load(string fileName)
    {
        Dictionary<int, QuestData> table = new Dictionary<int, QuestData>();

        // 텍스트 테이블 읽어 들임
        XmlDocument xmlFile = new XmlDocument();
        xmlFile.PreserveWhitespace = false;
        try
        {
            TextAsset textAsset = (TextAsset)Resources.Load("XML/" + fileName, typeof(TextAsset));
            xmlFile.LoadXml(textAsset.text);
        }
        catch (Exception e)
        {
            return null;
        }

        XmlNodeList allData = xmlFile.ChildNodes;
        foreach (XmlNode mainNode in allData)
        {
            if (mainNode.Name.Equals("Data") == true)
            {
                XmlNodeList childNodeList = mainNode.ChildNodes;
                foreach (XmlNode node in childNodeList)
                {
                    QuestData tableData = new QuestData();

                    tableData.Index = Int32.Parse(node.Attributes.GetNamedItem("Index").Value);
                    tableData.Name = String.Copy(node.Attributes.GetNamedItem("Name").Value);
                    tableData.MapIndex = Int32.Parse(node.Attributes.GetNamedItem("MapIndex").Value);
                    tableData.Mode  = Int32.Parse(node.Attributes.GetNamedItem("Mode").Value);

                    tableData.StaminaCost = Int32.Parse(node.Attributes.GetNamedItem("StaminaCost").Value);
                    tableData.EnemySpawnType = Int32.Parse(node.Attributes.GetNamedItem("EnemySpawnType").Value);
                    tableData.Boss = Int32.Parse(node.Attributes.GetNamedItem("Boss").Value);
                    tableData.MaxGold = Int32.Parse(node.Attributes.GetNamedItem("MaxGold").Value);
                    tableData.GoodScore = Int32.Parse(node.Attributes.GetNamedItem("GoodScore").Value);
                    tableData.GreatScore = Int32.Parse(node.Attributes.GetNamedItem("GreatScore").Value);

                    tableData.Description = String.Copy(node.Attributes.GetNamedItem("Description").Value);

                    table.Add(tableData.Index, tableData);
                }
            }
        }
        return table;
    }
}
