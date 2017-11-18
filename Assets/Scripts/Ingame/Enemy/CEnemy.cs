using UnityEngine;
using System.Collections;

public partial class CEnemy : MonoBehaviour
{
	// enum
	public enum Phase
	{
		INTRO, //인트로
		ONSCREEN
	}

    delegate void DirectionSetter(Vector3 vector3);

	public float HP; // 현재 체력
	public float max_HP; // 최대 체력
	public Attribute attribute; // 속성
	public float speed;
	public float DEF;
    public float ATK;

    public int coin_amount;
    public int heal_amount;
    public int mana_amount;
    public int score;

    Animator animator;

	Phase mover_phase;

	public const int NumberOfStates = 17;
	bool[] state = new bool[NumberOfStates];
	float[] state_percentage = new float[NumberOfStates];
	int[] state_overridden = new int[NumberOfStates]; // It's like a semaphore
    
    // 적 패턴과 관련된 멤버 변수들
    int AI_phase;
    bool action_complete;

    bool condition_taken;
    int condition_index;

    Action[] pattern_actions;
    Action[][] condition_actions;

	// Initialization Methods

    // Use this for initialization
    void Awake()
    {
    	// Add Component iTween to avoid hiccup
    	iTween.Init(gameObject);
        mover_phase = Phase.INTRO;
        animator = gameObject.GetComponent<Animator>();
    }

    public void Initialize(AI AI_type_,
                           float ATK_,
                           float HP_,
                           float speed_,
                           float defense_,
                           int shooter_num_,
                           int coin_amount_,
                           int score_)
    {
        HP = HP_;
        max_HP = HP_;
        ATK = ATK_;
        speed = speed_;
        DEF = defense_;
        coin_amount = coin_amount_;
        score = score_;

        SetMonsterType();
        SetItemDropRate();
        if (SetShooter())
        {
            int bullet_num = 0;
            switch (attribute)
            {
                case Attribute.FIRE:
                    bullet_num = 666;
                    break;
                case Attribute.AQUA:
                    bullet_num = 667;
                    break;
                case Attribute.NATURE:
                    bullet_num = 668;
                    break;
            }

            SelectShooter(shooter_num_,bullet_num);
            StartShooting();
        }

        
        StartCoroutine(StateFSM());
        action_complete = true;

        SetAI(AI_type_);

        // TODO: HP HUD
    }

    public virtual void SetItemDropRate()
    {
        mana_amount = 0;
        heal_amount = 0;
    }

    public virtual void SetMonsterType() { }

    public virtual bool SetShooter() { return false; }

    public virtual void SetBulletInfo(int num_, Attribute attribute_, HitType hit_type_, float SPD_, float ATK_, State state_, float size_) { }

    public virtual void SetShooitngInfo(int way_, int amount_, int reapeat_, float period_, float delay_, float angle_) { }

    protected void PlayAnimation(string name_)
    {
        if (animator != null)
        {
            animator.Play(name_);
        }
    }

	// 상태 변화 코루틴
	IEnumerator StateFSM()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.2f);
			
			switch(mover_phase)
			{
			case Phase.INTRO:
				if(!IsOutOfScreen())//객체가 화면 안에 있는지 체크
					mover_phase = Phase.ONSCREEN;
				break;

			case Phase.ONSCREEN:
				if (IsOutOfScreen())
					DestroyImmediate(gameObject);
				break;
			} 
		}
	}

    public void ApplyState(float[] state_DMG) // {applying_state, percent, duration}
	{
		state_percentage[(int)state_DMG[0]] = state_DMG[1];

        if (state[(int)state_DMG[0]])
            state_overridden[(int)state_DMG[0]]++;

        StartCoroutine(StateApplier((State)(int)state_DMG[0], state_DMG[2]));
	}

	IEnumerator StateApplier(State applying_state, float duration)
	{
		state[(int)applying_state] = true;

		if (applying_state == State.Frozen)
			Frozen();

		yield return new WaitForSeconds(duration);

		if (applying_state == State.Frozen)
			Melted();

		if (state_overridden[(int)applying_state] > 0)
			state_overridden[(int)applying_state]--;
		else
			state[(int)applying_state] = false;
	}

	void Frozen()
	{
        if (!gameObject.name.Contains("Champ"))
        {
            iTween.Pause(gameObject);
            PlayAnimation("Froze");
        }
	}

	void Melted()
	{
        if (!gameObject.name.Contains("Champ"))
        {
            iTween.Pause(gameObject);
            PlayAnimation("normal");
        }
	}

    public void ApplyDamage(float[] damage) // {damage, attribute}
    {
		float bullet_damage = damage[0];
		Attribute bullet_attribute = (Attribute)damage[1];

		if (state[(int)State.Amplification])
			bullet_damage *= 1f + state_percentage[(int)State.Amplification];
		if (state[(int)State.Shock])
			ApplyShock(damage[0]);

		if (attribute == Attribute.FIRE && bullet_attribute == Attribute.NATURE ||
		    attribute == Attribute.AQUA && bullet_attribute == Attribute.FIRE ||
		    attribute == Attribute.NATURE && bullet_attribute == Attribute.AQUA)
			bullet_damage *= 0.8f;
		else if (attribute == Attribute.FIRE && bullet_attribute == Attribute.AQUA ||
		         attribute == Attribute.AQUA && bullet_attribute == Attribute.NATURE ||
		         attribute == Attribute.NATURE && bullet_attribute == Attribute.FIRE)
			bullet_damage *= 2f;

		Hit(bullet_damage - CalculateEffectiveDefense());

        //damage_text
        float ddamage = bullet_damage - CalculateEffectiveDefense();
        if (ddamage <= 0)
            ddamage = 1.0f;
        if (StageManager.DamageCount != null)
        {
            GameObject tDamageCountObj = (GameObject)Instantiate(StageManager.DamageCount, gameObject.transform.position, Quaternion.identity);
            if (tDamageCountObj != null)
            {
                tDamageCountObj.GetComponent<FontManager>().SetDamageNum
                    (FontManager.ColorIndex.YELLOW, (int)ddamage, 40.0f);        
                    //(FontManager.ColorIndex.RED, (int)ddamage, 100.0f);        
            }
        }
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
        {
            StartCoroutine(Dead());
        }
        else
            StartCoroutine(Kiraring());
    }

	IEnumerator Kiraring()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		yield return new WaitForSeconds(0.06f);
		gameObject.GetComponent<Renderer>().material.color = Color.white;
	}

	void InitDirectionUpdater(DirectionSetter callback)
	{
		StartCoroutine(DirectionUpdater(callback));
	}

	IEnumerator DirectionUpdater(DirectionSetter callback)
	{
		Vector3 past_position = gameObject.transform.position;
		Vector3 direction;
		while (true)
		{
			yield return null;
			
			direction = (gameObject.transform.position - past_position).normalized;
			callback(direction);

			past_position = gameObject.transform.position;
		}
	}

	void StopDirectionUpdater()
	{
		StopCoroutine("DirectionUpdater");
	}

	void ExecuteAction()
	{
		if (action_complete)
		{
			if (!condition_taken)
				pattern_actions[AI_phase].Execute();
			else
				condition_actions[condition_index][AI_phase].Execute();
			
			action_complete = false;
		}
	}

	void OnAIActionComplete()
	{
		AI_phase++;
		
		action_complete = true;
	}

	// getters and setters

	bool IsOutOfScreen()
	{
        return (gameObject.transform.position.x < -640f || gameObject.transform.position.x > 640f || gameObject.transform.position.y > 700f || gameObject.transform.position.y < -700f); // 1280 * 720
	}

	// Method which would be called on destroy
    IEnumerator Dead()
    {
        Action.ActionStop(gameObject, 1.0f).Execute();
        PlayAnimation("Dead");
        StageManager.score += score;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.7f);
        DropItem();
        if (StageManager.currnet_coin <= StageManager.max_coin)
        {
            DropCoin();
        }
        yield return new WaitForSeconds(0.1f);
        DestroyImmediate(gameObject);
    }

	void DropItem()
	{
		int amount = (int)Random.Range(0f, mana_amount+0.5f);

        for (int i = 0; i < amount; i++)
        {
            Instantiate(ResourceLoad.PickGameObject("item_mana"), gameObject.transform.position, Quaternion.identity);
        }

        amount = (int)Random.Range(0f, heal_amount+0.5f);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(ResourceLoad.PickGameObject("item_heal"), gameObject.transform.position, Quaternion.identity);
        }
	}

    void DropCoin()
    {
        int amount = (int)Random.Range(0f, coin_amount+0.5f);
        for (int i = 0; i < amount; i++)
        {
            StageManager.currnet_coin++;
            if (StageManager.currnet_coin >= StageManager.max_coin * 0.95)
            {
                return;
            }
            Instantiate(ResourceLoad.PickGameObject("item_coin"), gameObject.transform.position, Quaternion.identity);
        }
    }

}