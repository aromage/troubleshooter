using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public class BulletData
{
    public int Index;
    public int MoveType;
    public int HitType;
    public int Speed;
    public int MuzzleCount;
    public float MuzzleAngle;
    public int Amount;
    public int Repeat;
    public float Delay;
    public float Period;
    public float Size;

    public static Dictionary<int, BulletData> Load(string fileName)
    {
        Dictionary<int, BulletData> table = new Dictionary<int, BulletData>();

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
                    BulletData tableData = new BulletData();

                    tableData.Index = Int32.Parse(node.Attributes.GetNamedItem("Index").Value);
                    tableData.MoveType = Int32.Parse(node.Attributes.GetNamedItem("MoveType").Value);
                    tableData.HitType = Int32.Parse(node.Attributes.GetNamedItem("HitType").Value);
                    tableData.Speed= Int32.Parse(node.Attributes.GetNamedItem("Speed").Value);
                    tableData.MuzzleCount= Int32.Parse(node.Attributes.GetNamedItem("MuzzleCount").Value);
                    tableData.MuzzleAngle= float.Parse(node.Attributes.GetNamedItem("MuzzleAngle").Value);
                    tableData.Amount= Int32.Parse(node.Attributes.GetNamedItem("Amount").Value);
                    tableData.Repeat= Int32.Parse(node.Attributes.GetNamedItem("Repeat").Value);
                    tableData.Delay= float.Parse(node.Attributes.GetNamedItem("Delay").Value);
                    tableData.Period= float.Parse(node.Attributes.GetNamedItem("Period").Value);
                    tableData.Size = float.Parse(node.Attributes.GetNamedItem("Size").Value);
                    
                    table.Add(tableData.Index, tableData);
                }
            }
        }
        return table;
    }
}
