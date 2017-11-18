using UnityEngine;
using System.Collections;

public class Code_DamageCount : MonoBehaviour {

	
	public float FrameTime = 0.0f;
	public int FrameCount = 0;
	public float plusScaleByFrameCount= 8.0f;
	public float tScale = 1.0f;
	
	
	public float[] tPosX = { -0.2f,-0.1f,0,0.1f,0.2f };
	public float[] tPosY = { 0.2f,-0.1f,-0.2f,0,0.1f };
	
	public int kind;
	public static int KIND_DAMAGE= 0;
	public static int KIND_CRITICAL= 1;
	public static int KIND_SKILL= 2;
	
	public void Start ()
	{
	  
	}

    
	public void Update ()
	{
	    if (Time.frameCount%3 != 0)
	        return;

       
		if(FrameTime < 0.15f)
		{
		    tScale = 1.0f+FrameTime*plusScaleByFrameCount;
			transform.localScale = new Vector3(tScale,tScale,tScale);
        }
		else if(FrameTime < 0.3f)
		{
		    tScale = 2.5f-FrameTime*plusScaleByFrameCount;
			transform.localScale = new Vector3(tScale,tScale,tScale);
        }
		else if (FrameTime < 0.45f)
		{
		    transform.localScale = new Vector3(1, 1, 1);
		    transform.Translate(new Vector3(tPosX[FrameCount], tPosY[FrameCount], 0));
		}
		else
		{
		    transform.Translate(new Vector3(0, Time.deltaTime*2.0f, 0));
		}


	    FrameTime += Time.deltaTime;

		if(FrameCount < 4)
			FrameCount++;
		else
			FrameCount = 0;
	}
}
