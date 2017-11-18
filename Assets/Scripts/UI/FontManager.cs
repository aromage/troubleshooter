using System.Text;
using UnityEngine;
using System.Collections;

public class FontManager : MonoBehaviour {

    public enum ColorIndex : int
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        MAX = 3,
    }
    public static Texture[] Texture_Num_Damage = new Texture[10];
	public static StringBuilder strBuffer = new StringBuilder(64);
	//static Texture Texture_CriticalDamage;
	
	public GameObject[] child= new GameObject[7];
	
	public Code_DamageCount Script_DamageCount;
	
	public int num;
	public int length;
	public int[] numArray= new int[7];
	public int size;
	
	public void Start () 
	{
	}

    public void SetDamageNum(ColorIndex color, int tValue, float tSize)
	{
		//////Debug.log("SetDamageNum(tValue:"+tValue+", tSize:"+tSize+", tKind:"+tKind+")");
        Destroy(gameObject, 0.3f);
		int i;
		float startPos;
		
		
		if(Texture_Num_Damage[0] == null)
		{
		    strBuffer.Remove(0, strBuffer.Length);
		    switch (color)
		    {
                case ColorIndex.RED:
		        {
                    strBuffer.Append("Images/Number/num_red_");
		        }
                break;
                case ColorIndex.BLUE:
		        {
                    strBuffer.Append("Images/Number/num_blue_");
		        }
		        break;
                case ColorIndex.YELLOW:
		        {
                    strBuffer.Append("Images/Number/num_yellow_");
		        }
		        break;
		    }
		    if (string.IsNullOrEmpty(strBuffer.ToString()) == true)
		    {
		        return;
		    }

			for(i=0;i<Texture_Num_Damage.Length;i++)
			{
			    strBuffer.Append(i.ToString());
                Texture_Num_Damage[i] = Resources.Load(strBuffer.ToString()) as Texture;
			    strBuffer.Remove(strBuffer.Length - 1, 1);
			}
		}
		
		if(Script_DamageCount == null)
		{
			Script_DamageCount = transform.GetComponent<Code_DamageCount>();
		}
			
		length = 0;
		for(i=0;i<numArray.Length;i++)
		{
			numArray[i] = tValue%10;
			length++;
			
			tValue/=10;
			if(tValue == 0)
				break;
		}
	
		startPos = -(tSize*0.8f*length)/2f;
		for(i=0;i<child.Length;i++)
		{
			child[i] = transform.Find(""+i).gameObject;
			child[i].transform.localScale = new Vector3(tSize,tSize,tSize);
            child[i].transform.localPosition = new Vector3(startPos + (i * (tSize * 0.8f)), child[i].transform.localPosition.y + 1.1f, child[i].transform.localPosition.z - 0.1f);
			
			if(i < length)
			{
				child[i].SetActive(true);
                child[i].GetComponent<Renderer>().material.mainTexture = Texture_Num_Damage[numArray[length - 1 - i]];
                child[i].GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
			    /*
				if(tKind == 0)
					child[i].renderer.material.mainTexture = Texture_Num_Damage[numArray[length-1-i]];
				else if(tKind == 1)
					child[i].renderer.material.mainTexture = Texture_Num_CriticalDamage[numArray[length-1-i]];
				else //if(tKind == 2)
					child[i].renderer.material.mainTexture = Texture_Num_SkillDamage[numArray[length-1-i]];*/
			}
			else
			{
				child[i].SetActive(false);
			}
		}
	}
	
}
