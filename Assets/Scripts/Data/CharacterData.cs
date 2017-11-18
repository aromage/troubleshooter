using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public class CharacterData
{
    public int      Index;
    public string   Name;
    public string   ResourceName;
    public int      Attribute;
    public int      HealthPoint;
    public int      ManaPoint;
    public int      DefensePoint;
    public int      AttackPoint;
    public int      Speed;
    public int      BulletIndex;
    public int      SkillIndex;
    public string   SkillName;
    public string   SkillDesc;
    public int      SkillManaCost;
    

    public static Dictionary<int, CharacterData> Load(string fileName)
    {
        Dictionary<int, CharacterData> table = new Dictionary<int, CharacterData>();

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
                    CharacterData tableData = new CharacterData();

                    tableData.Index = Int32.Parse(node.Attributes.GetNamedItem("Index").Value);
                    tableData.Name = String.Copy(node.Attributes.GetNamedItem("Name").Value);
                    tableData.ResourceName = String.Copy(node.Attributes.GetNamedItem("ResourceName").Value);

                    tableData.Attribute = Int32.Parse(node.Attributes.GetNamedItem("Attribute").Value);
                    tableData.HealthPoint = Int32.Parse(node.Attributes.GetNamedItem("HealthPoint").Value);
                    tableData.ManaPoint = Int32.Parse(node.Attributes.GetNamedItem("ManaPoint").Value);
                    tableData.DefensePoint = Int32.Parse(node.Attributes.GetNamedItem("DefensePoint").Value);
                    tableData.AttackPoint = Int32.Parse(node.Attributes.GetNamedItem("AttackPoint").Value);
                    tableData.Speed = Int32.Parse(node.Attributes.GetNamedItem("Speed").Value);

                    tableData.BulletIndex = Int32.Parse(node.Attributes.GetNamedItem("BulletIndex").Value);

                    tableData.SkillIndex = Int32.Parse(node.Attributes.GetNamedItem("SkillIndex").Value);
                    tableData.SkillName = String.Copy(node.Attributes.GetNamedItem("SkillName").Value);
                    tableData.SkillDesc = String.Copy(node.Attributes.GetNamedItem("SkillDesc").Value);
                    tableData.SkillManaCost = Int32.Parse(node.Attributes.GetNamedItem("SkillManaCost").Value);

                    table.Add(tableData.Index, tableData);
                }
            }
        }
        return table;
    }
}
