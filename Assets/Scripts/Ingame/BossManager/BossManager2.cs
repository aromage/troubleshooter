using UnityEngine;
using System.Collections;

public class BossManager2 : MonoBehaviour {

	public static IceWitch.IceWitchState boss_state = IceWitch.IceWitchState.Intro;
	public static Mirror.MirrorState mirror_state = Mirror.MirrorState.Intro;

	void OnEnable()
	{
		boss_state = IceWitch.IceWitchState.Intro;
		mirror_state = Mirror.MirrorState.Intro;

		SummonIceWitch();
	}

	void OnBossAppeared()
	{
        GameObject.Find("StageManager").SendMessage("MoveToBossPhase");
	}

	void SummonIceWitch()
	{
        Instantiate(ResourceLoad.PickGameObject("ice_witch"), new Vector3(0f, 200f, 0f), Quaternion.identity);
	}

	void OnBossDestroy()
	{
        GameObject.Find("StageManager").SendMessage("MoveToFinishPhase");
	}
}
