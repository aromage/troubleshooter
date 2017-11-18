using UnityEngine;
using System.Collections;

public partial class Deathra : CBoss {

	[SerializeField]
	enemyShooter[] shooter = new enemyShooter[4];

	[SerializeField]
	Sprite[] normal_body = new Sprite[3];
	[SerializeField]
	Sprite[] broken_body = new Sprite[3];
	[SerializeField]
	Sprite[] normal_chin = new Sprite[3];
	[SerializeField]
	Sprite[] broken_chin = new Sprite[3];
	
	[SerializeField]
	DeathraChin chin;
	[SerializeField]
	GameObject mouth;

	[SerializeField]
	GameObject left_eye;
	[SerializeField]
	GameObject right_eye;
	[SerializeField]
	GameObject left_wing;
	[SerializeField]
	GameObject right_wing;

	[SerializeField]
	GameObject left_eye_laser;
	[SerializeField]
	GameObject right_eye_laser;

	[SerializeField]
	GameObject left_wing_laser;
	[SerializeField]
	GameObject right_wing_laser;

	int attribute_index;
	
	public const int NumberOfStates = 17; // TODO : move to game manager
	public bool[] state = new bool[NumberOfStates];
	public float[] state_percentage = new float[NumberOfStates];
	public int[] state_overridden = new int[NumberOfStates]; // It's like a semaphore

	void Awake()
	{   
        SetBossInfo("탐욕의 석상 데스라", Attribute.FIRE, 100000f, 10f);
        intro_time = 1.0f;
		HP = max_HP;
		SetAttributeIndex();

//		StartCoroutine("Animator");
		
		BossManager3.boss_state = DeathraState.Intro;
		BossManager3.wing_state = WingState.Intro;

		AddShooter();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(Intro());
	}

	void AddShooter()
	{
		GameObject[] shooter_object = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			shooter[i].SetBulletInfo(666, Attribute.FIRE, (HitType)0, 1200f, 0.05f, State.NONE, 15f);
			shooter[i].SetShooitngInfo(3, 3, 3, 1f, 0.1f, 0f);
			shooter[i].StartAiming();

			i++;

			shooter[i].SetBulletInfo(666, Attribute.FIRE, (HitType)0, 300f, 0.05f, State.NONE, 15f);
			shooter[i].SetShooitngInfo(10, 10, 5, 2f, 0.1f, 70f); // TODO: correct
			shooter[i].StartAiming();
		}
	}
	
	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
//		if (BossManager2.boss_state == IceWitchState.Overwhelming ||
//		    BossManager2.boss_state == IceWitchState.Overwhelming_ready)
//			return;
		
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
//		if (BossManager2.boss_state == IceWitchState.Overwhelming_ready)
//			return;
		
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
		
		StartKiraring();
	}
	
	public void StartKiraring() 
	{
		StartCoroutine(Kiraring());
		chin.StartKiraring();
	}

	public void DestroyBoss()
	{
		StartCoroutine(DestroyScene());
	}
	
	IEnumerator DestroyScene()
	{
		// TODO: Boss Destroy event
		StopCoroutine("FSM");
		StopCoroutine("WingFSM");
        GameObject.Find("StageManager").SendMessage("OnBossDestroy"); // TODO: Correct
        GameObject.Find("HudManager").SendMessage("Boss_Hp_Delete");

        BossDeadMotion();

        yield return new WaitForSeconds(0.5f);

        DropItem();
        DropCoin();
        gameObject.SetActive(false);
        StageManager.score += 5000;

        yield return new WaitForSeconds(4.0f);

        Destroy(gameObject);
	}
	
	void SetAttributeIndex()
	{
		switch(attribute)
		{
		case Attribute.FIRE:
			attribute_index = 0;
			break;
		case Attribute.AQUA:
			attribute_index = 1;
			break;
		case Attribute.NATURE:
			attribute_index = 2;
			break;
		default:
			break;
		}
	}
}
