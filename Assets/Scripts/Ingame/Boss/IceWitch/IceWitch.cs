using UnityEngine;
using System.Collections;

public partial class IceWitch : CBoss {

	[SerializeField]
	IceWitchState icewitch_state; // TODO: temporary
	
	public const int NumberOfStates = 17; // TODO : move to game manager
	public bool[] state = new bool[NumberOfStates];
	public float[] state_percentage = new float[NumberOfStates];
	public int[] state_overridden = new int[NumberOfStates]; // It's like a semaphore

	enemyShooter[] shooter = new enemyShooter[4];

	[SerializeField]
	SpriteRenderer sprite_renderer;
	[SerializeField]
	Sprite[] sprites = new Sprite[4];
	[SerializeField]
	Sprite witch_in_mirror;

	[SerializeField]
	Mirror mirror;

	void Awake()
	{
        SetBossInfo("얼음의 마녀 아이시", Attribute.AQUA, 10000f, 10f);
        intro_time = 1.0f;
		HP = max_HP;

		AddShooter();
		StartCoroutine("Animator");
		
		BossManager2.boss_state = IceWitch.IceWitchState.Intro;
	}

	void AddShooter()
	{
		GameObject[] shooter_object = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			shooter_object[i] = new GameObject();
			shooter_object[i].AddComponent<enemyShooter>();
			shooter_object[i].name = "EnemyShooter";
			shooter[i] = shooter_object[i].GetComponent<enemyShooter>();
			shooter[i].Init(gameObject);
		}
		shooter[0].SetBulletInfo(667, Attribute.AQUA, (HitType)0, 600f, 0.07f, State.NONE, 15f);
		shooter[0].SetShooitngInfo(1, 1, 1, 2f, 0.6f, 0f);
		
		shooter[1].SetBulletInfo(667, Attribute.AQUA, (HitType)0, 600f, 0.07f, State.NONE, 15f);
		shooter[1].SetShooitngInfo(3, 3, 1, 1.5f, 0f, 45f);
		shooter[1].StartAiming();

		shooter[2].SetBulletInfo(701, Attribute.AQUA, (HitType)0, 150f, 0.07f, State.NONE, 15f);
		shooter[2].SetShooitngInfo(6, 1, 6, 2f, 0.15f, 60f);

		shooter[3].SetBulletInfo(701, Attribute.AQUA, (HitType)0, 200f, 0.07f, State.NONE, 15f);
		shooter[3].SetShooitngInfo(10, 1, 10, 2f, 0.15f, 70f);
	}

	IEnumerator Animator()
	{
		for (int i = 1; true; i++)
		{
			yield return new WaitForSeconds(0.1f);

			sprite_renderer.sprite = sprites[i];

			if (i == 3)
				i = -1;
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(Intro());
	}
	
	// Update is called once per frame
	void Update () {
		icewitch_state = BossManager2.boss_state;
	}

	void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
		if (BossManager2.boss_state == IceWitchState.Overwhelming ||
		    BossManager2.boss_state == IceWitchState.Overwhelming_ready)
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
		if (BossManager2.boss_state == IceWitchState.Overwhelming)
		{
			hit_counter++;
			StartKiraring();
			return;
		}
		else if (BossManager2.boss_state == IceWitchState.Overwhelming_ready)
		{
			return;
		}

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
		
		if (BossManager2.boss_state != IceWitchState.Destroying)
			StartKiraring();
	}
	
	public void StartKiraring() 
	{
		if (BossManager2.boss_state != IceWitchState.Overwhelming)
			mirror.StartKiraring();
		StartCoroutine(Kiraring());
	}

	public void DestroyBoss()
	{
		StartCoroutine(DestroyScene());
	}
	
	IEnumerator DestroyScene()
	{
		// TODO: Boss Destroy event
		StopCoroutine("FSM");
        GameObject.Find("StageManager").SendMessage("OnBossDestroy");
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
}
