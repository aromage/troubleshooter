using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using System.Collections;

public class MapData
{
    public int   Index;
    public int[] Ground;
    public int[] Sky;
    public int[] RandomSky;
    public int[] RandomGround;

    public static Dictionary<int, MapData> Load(string fileName)

    {
        Dictionary<int, MapData> table = new Dictionary<int, MapData>();

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
                    MapData tableData = new MapData();

                    tableData.Index = Int32.Parse(node.Attributes.GetNamedItem("Index").Value);

                    tableData.Ground = new int[13];
                    tableData.Sky = new int[13];

                    tableData.RandomSky = new int[3];
                    tableData.RandomGround = new int[3];

                    StringBuilder   strbuffer = new StringBuilder(32);
                    
                    for (int i = 0; i < 13; i++)
                    {
                        strbuffer.Remove(0, strbuffer.Length);
                        strbuffer.Append("Ground");
                        strbuffer.Append(i.ToString() );

                        tableData.Ground[i] = Int32.Parse(node.Attributes.GetNamedItem(strbuffer.ToString()).Value);

                        strbuffer.Remove(0, strbuffer.Length);
                        strbuffer.Append("Sky");
                        strbuffer.Append(i.ToString());

                        tableData.Sky[i] = Int32.Parse(node.Attributes.GetNamedItem(strbuffer.ToString()).Value);
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        strbuffer.Remove(0, strbuffer.Length);
                        strbuffer.Append("RandomSky");
                        strbuffer.Append(i.ToString());

                        tableData.RandomSky[i] = Int32.Parse(node.Attributes.GetNamedItem(strbuffer.ToString()).Value);

                        strbuffer.Remove(0, strbuffer.Length);
                        strbuffer.Append("RandomGround");
                        strbuffer.Append(i.ToString());

                        tableData.RandomGround[i] = Int32.Parse(node.Attributes.GetNamedItem(strbuffer.ToString()).Value);
                    }
                    table.Add(tableData.Index, tableData);
                }
            }
        }
        return table;
    }
}
