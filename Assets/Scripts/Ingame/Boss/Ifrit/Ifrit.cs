using UnityEngine;
using System.Collections;

public partial class Ifrit : CBoss
{
	[SerializeField]
	Sprite boss_destroyed;
	[SerializeField]
	Sprite boss_normal;

	[SerializeField]
	IfritFire fire;
	[SerializeField]
	IfritLeftArm left_arm;
	[SerializeField]
	IfritRightArm right_arm;
	[SerializeField]
	IfritLeftHand left_hand;
	[SerializeField]
	IfritRightHand right_hand;
	[SerializeField]
	IfritBottom bottom;
	[SerializeField]
	IfritLeftShoulder left_shoulder;
	[SerializeField]
	IfritRightShoulder right_shoulder;
	[SerializeField]
	GameObject core;
	
	public const int NumberOfStates = 17;
	public bool[] state = new bool[NumberOfStates];
	public float[] state_percentage = new float[NumberOfStates];
	public int[] state_overridden = new int[NumberOfStates]; // It's like a semaphore
	
    // Use this for initialization
	void Awake()
	{
        SetBossInfo("불의 정령 이프리트", Attribute.FIRE, 10000f, 10f);
        intro_time = 4.3f;
		HP = max_HP;

		BossManager1.boss_state = BossState.Intro;
	}

	void Start()
	{
		StartCoroutine(Intro());
	}

	void StartBreathing()
	{
		Hashtable command = iTween.Hash("amount", 20f * Vector3.up, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad, "time", 2.0f);
		iTween.MoveBy(gameObject, command);
	}

	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
		if (BossManager1.boss_state == Ifrit.BossState.Intro ||
		    BossManager1.boss_state == BossState.Diverge ||
		    BossManager1.boss_state == Ifrit.BossState.EnergyBall)
			return;
		
		state_percentage[(int)state_DMG[0]] = state_DMG[1];
		
		if (state[(int)state_DMG[0]])
			state_overridden[(int)state_DMG[0]]++;
		
		StartCoroutine(StateApplier((State)(int)state_DMG[0], state_DMG[2]));
	}
	
	IEnumerator StateApplier(State applying_state, float duration)
	{
		state[(int)applying_state] = true;
		
		yield return new WaitForSeconds(duration);
		
		if (state_overridden[(int)applying_state] > 0)
			state_overridden[(int)applying_state]--;
		else
			state[(int)applying_state] = false;
	}
	
	void ApplyDamage(float[] damage) // {damage, attribute)
	{
		if (BossManager1.boss_state == Ifrit.BossState.Intro ||
		    BossManager1.boss_state == BossState.Diverge ||
		    BossManager1.boss_state == Ifrit.BossState.EnergyBall ||
		    BossManager1.boss_state == BossState.Destroyed ||
		    HP <= 0f)
			return;
		
		float bullet_damage = damage[0];
		Attribute bullet_attribute = (Attribute)damage[1];
		
		if (state[(int)State.Amplification])
			bullet_damage *= 1f + state_percentage[(int)State.Amplification];
		if (state[(int)State.Shock])
			ApplyShock(damage[0]);
		
		if (attribute == Attribute.FIRE && bullet_attribute == Attribute.NATURE ||
		    attribute == Attribute.AQUA && bullet_attribute == Attribute.FIRE ||
		    attribute == Attribute.NATURE && bullet_attribute == Attribute.AQUA)
			bullet_damage *= 0.5f;
		else if (attribute == Attribute.FIRE && bullet_attribute == Attribute.AQUA ||
		         attribute == Attribute.AQUA && bullet_attribute == Attribute.NATURE ||
		         attribute == Attribute.NATURE && bullet_attribute == Attribute.FIRE)
			bullet_damage *= 2f;
		
		Hit(bullet_damage - CalculateEffectiveDefense());
	}
	
	void ApplyShock(float damage)
	{
		damage *= state_percentage[(int)State.Shock];
		
		Hit(damage - CalculateEffectiveDefense());
	}
	
	float CalculateEffectiveDefense()
	{
		float effective_defense = DEF;
		
		float defense_percentage = 0f;
		if (state[(int)State.ShieldUp])
			defense_percentage += state_percentage[(int)State.ShieldUp];
		if (state[(int)State.ArmorBreak])
			defense_percentage -= state_percentage[(int)State.ArmorBreak];
		
		effective_defense *= 1f + defense_percentage;
		
		return effective_defense;
	}

	void Hit(float damage)
	{
		if (damage < 0)
			damage = 1f;

		HP -= damage;
		
		if (HP <= 0)
			DestroyBoss();
		else
			StartKiraring();
	}

	public void StartKiraring() 
	{
		StartCoroutine(Kiraring());
		
		bottom.StartKiraring();
	}
	
	public void DestroyBoss()
	{
		StartCoroutine(DestroyScene());
	}

	IEnumerator DestroyScene()
	{
		StopCoroutine("FSM");
		BossManager1.boss_state = BossState.Destroyed;
		GameObject.Find("HudManager").SendMessage("Boss_Hp_Delete");
		GameObject.Find("StageManager").SendMessage("OnBossDestroy");

        BossDeadMotion();

		yield return new WaitForSeconds(0.5f);

        DropItem();
        DropCoin();
        gameObject.SetActive(false);
		StageManager.score += 5000;

        yield return new WaitForSeconds(4.0f);

		Destroy(gameObject);
	}

	void BossDeadMotion()
	{
		GameObject ggong = new GameObject();
		ggong.transform.position = gameObject.transform.position;
		ggong.AddComponent<Boss_Boom>();
	}
}