using UnityEngine;
using System.Collections;

public class BossManager3 : MonoBehaviour {
	
	public static Deathra.DeathraState boss_state = Deathra.DeathraState.Intro;
	public static Deathra.WingState wing_state = Deathra.WingState.Intro;
	
	void OnEnable()
	{
		boss_state = Deathra.DeathraState.Intro;
		wing_state = Deathra.WingState.Intro;
		
		SummonDeathra();
	}
	
	void OnBossAppeared()
	{
        GameObject.Find("StageManager").SendMessage("MoveToBossPhase");
	}
	
	void SummonDeathra()
	{
		Instantiate(ResourceLoad.PickGameObject("deathra"), new Vector3(0f, 400f, 0f), Quaternion.identity);
	}
	
	void OnBossDestroy()
	{
        GameObject.Find("StageManager").SendMessage("MoveToFinishPhase");
	}
}
