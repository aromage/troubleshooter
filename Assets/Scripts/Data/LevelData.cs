using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public class LevelData
{
    public int      Index;
    public int      Gold;
    public int      HealthPoint;
    public int      AttackPoint;


    public static Dictionary<int, LevelData> Load(string fileName)
    {
        Dictionary<int, LevelData> table = new Dictionary<int, LevelData>();

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
                    LevelData tableData = new LevelData();


                    tableData.Index = Int32.Parse(node.Attributes.GetNamedItem("Index").Value);
                    tableData.Gold = Int32.Parse(node.Attributes.GetNamedItem("Gold").Value);

                    tableData.HealthPoint = Int32.Parse(node.Attributes.GetNamedItem("HealthPoint").Value);
                    tableData.AttackPoint = Int32.Parse(node.Attributes.GetNamedItem("AttackPoint").Value);

                    table.Add(tableData.Index, tableData);
                }
            }
        }
        return table;
    }
}
