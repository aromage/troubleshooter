using UnityEngine;
using System.Collections;

public class PlayerMain : PlayerBase
{
    GameObject main;

    bool invincible = false;
    public MoverPhase mover_phase;
    GameObject Manager;
//    GameObject cursor;

    private Animator animator;

    float animating_check = 0;

    Vector3 mouse_position;
    Vector3 joystick_anchor;
    Vector3 direction;
    Vector3 moved_pos = Vector3.zero;
    bool forced_move = false;

    int control_option;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = new Vector3(0,-580,0);
        Manager = GameObject.Find("PlayerManager");
//        cursor = (GameObject)Instantiate(ResourceLoad.PickGameObject("cursor"));
//        NGUITools.AddChild(gameObject,cursor);
//        cursor.SetActive(false);
//        cursor.GetComponent<SpriteRenderer>().sortingOrder = 1;
        mover_phase = MoverPhase.ONSCREEN;
        animator = GetComponent<Animator>();

        shooter = gameObject.GetComponent<myShooter>();
        shooter.SetShooitngInfo(shooting_way, shooting_amount, shooting_repeat, shooting_period, shooting_delay, shooting_angle);
        ChangeATK();

        control_option = (int)GameManager.setting_control;
    }

    public void ChangeATK()
    {
        switch (position)
        {
            case Position.FIRST:
//                cursor.SetActive(true);
                shooter.SetBulletInfo(index, attribute, bullet_hit_type, bullet_SPD, char_ATK, bullet_state, bullet_size);
                break;
            case Position.SECOND:
            case Position.THIRD:
//                cursor.SetActive(false);
                shooter.SetBulletInfo(index, attribute, bullet_hit_type, bullet_SPD, char_ATK/2, bullet_state, bullet_size);
                break;
        }
    }

    void SetMain(string name_)
    {
        main = GameObject.Find(name_);
    }

    public override void StartShooting()
    {
        shooter.StartShooting();
    }

    public override void StopShooting()
    {
        shooter.StopShooting();
    }

    // Update is called once per frame
    void Update()
    {
        switch (mover_phase)
        {
            case MoverPhase.ONSCREEN:
                Move();
                CameraWork();
                Animating();
                break;
            case MoverPhase.DESTROY:
                gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// 포지션에 따른 이동 결정
    /// </summary>
    public void Move()
    {
        switch (position)
        {
            case Position.FIRST:
                if (Input.GetMouseButton(0))
                {
                    if (forced_move == false)
                    {
                        Controller();
                    }
                    this.transform.Translate(this.moved_pos, Space.World);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    direction = Vector3.zero;
                }
                break;
            case Position.SECOND:
                MoveTrail(65);
//                MoveOffSet(new Vector3 (-50f,-80f));
                break;
            case Position.THIRD:
                MoveTrail(130);
//                MoveOffSet(new Vector3(50f, -80f));
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// 컨트롤러 이동
    /// </summary>
    void Controller()
    {
        if (StageManager.matrix_state == false)
        {
            SetMousePosition();
            switch (control_option)
            {
                case 0://Type1 - 손가락 이동량 비례 조작
                    if (Input.GetMouseButtonDown(0))
                    {
                        joystick_anchor = mouse_position;
                    }
                    direction = mouse_position - joystick_anchor;
                    break;

                case 1://Type2 - 플레이어 직접조작
                    direction = mouse_position + new Vector3(0f, Screen.height / 40, 0f) - gameObject.transform.position;
                    break;

                default:
                    break;
            }
        }
        else
            direction = Vector3.zero;

        this.moved_pos = char_SPD * direction.normalized * Time.deltaTime;
        if (moved_pos.sqrMagnitude > direction.sqrMagnitude)
            moved_pos = direction;

        if (control_option == 0)
        {
            joystick_anchor += moved_pos;
        }

        // 화면 밖으로 안나가도록 처리
        if (gameObject.transform.position.x >= 550f)
        {
            gameObject.transform.position = new Vector3(550f, gameObject.transform.position.y, gameObject.transform.position.z);
            if (moved_pos.x > 0) moved_pos.x = 0;
        }
        if (gameObject.transform.position.x <= -550f)
        {
            gameObject.transform.position = new Vector3(-550f, gameObject.transform.position.y, gameObject.transform.position.z);
            if (moved_pos.x < 0) moved_pos.x = 0;
        }
        if (gameObject.transform.position.y > 600f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 600f, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y < -600f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -600f, gameObject.transform.position.z);
        }
    }

    /// <summary>
    /// 뒤따라 이동
    /// </summary>
    /// <param name="offset_">본체로부터 떨어진 거리</param>
    void MoveTrail(float offset_)
    {
        direction = main.transform.position - new Vector3(0, 40, 0) - gameObject.transform.position;
        moved_pos = 0.5f * char_SPD * direction.normalized * Time.deltaTime;
        if (direction.magnitude <= offset_)
        {
            direction = Vector3.zero;
            moved_pos = Vector3.zero;
        }
        gameObject.transform.Translate(moved_pos);
    }

    /// <summary>
    ///  정해진 포메이션으로 이동
    /// </summary>
    /// <param name="offset_">본체로부터 떨어진 벡터</param>
    void MoveOffSet(Vector3 offset_)
    {
        direction = main.transform.position + offset_ - gameObject.transform.position;
        moved_pos = 0.5f * char_SPD * direction.normalized * Time.deltaTime;
        if (direction.sqrMagnitude <= moved_pos.sqrMagnitude)
        {
            moved_pos = direction;
        }
        gameObject.transform.Translate(moved_pos);
    }
    
    void ForceMove(Vector3 targer_pos)
    {
        forced_move = true;
        while (forced_move == true)
        {
            direction = targer_pos - gameObject.transform.position;

            this.moved_pos = char_SPD * direction.normalized * Time.deltaTime;
            if (moved_pos.sqrMagnitude > direction.sqrMagnitude)
                moved_pos = direction;
            this.transform.Translate(this.moved_pos, Space.World);
            if (direction == Vector3.zero)
                forced_move = false;
        }

    }

    /// <summary>
    /// 카메라워크
    /// </summary>
    void CameraWork()
    {
        if (this.tag == "player")
        {
            Camera.main.transform.position = new Vector3(this.gameObject.transform.position.x * 240f / 550f,0,-50);
        }
    }

    /// <summary>
    /// 애니메이팅
    /// </summary>
    void Animating()
    {
        switch (position)
        {
            case Position.FIRST:
                if(gameObject.transform.localScale != new Vector3(1f, 1f))
                    gameObject.transform.localScale = new Vector3(1f, 1f);

                if (direction.sqrMagnitude < Screen.width / 40)
                    direction = Vector3.zero;
                if (direction.x > 0f && (animating_check += direction.x) > 5f)
                {
                    animating_check = 5f;
                }
                if (direction.x < 0f && (animating_check += direction.x) < -5f)
                {
                    animating_check = -5f;
                }
                if (direction.x == 0f) { animating_check = 0; };
                if (animating_check < -4)
                    animator.Play("left");
                else if (animating_check > 4)
                    animator.Play("right");
                else
                    animator.Play("idle");
                break;
            case Position.SECOND:
            case Position.THIRD:
                if (gameObject.transform.localScale != new Vector3(0.6f, 0.6f))
                gameObject.transform.localScale = new Vector3(0.6f,0.6f);
                
                if (direction.sqrMagnitude < Screen.width / 80)
                direction = Vector3.zero;
                if (direction.x > 0f && (animating_check += direction.x) > 5f)
                {
                    animating_check = 5f;
                }
                if (direction.x < 0f && (animating_check += direction.x) < -5f)
                {
                    animating_check = -5f;
                }
                if (direction.x == 0f) { animating_check = 0; };
                if (animating_check < -1)
                    animator.Play("left");
                else if (animating_check > 1)
                    animator.Play("right");
                else
                    animator.Play("idle");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)//충돌체크시 페이즈 전환 및 효과
    {
        if (position == Position.FIRST)
        {
            if (BossManager1.boss_state == Ifrit.BossState.State_6)
                return;

            if (coll.gameObject.tag == "item")//아이템 충돌
            {
                if (coll.gameObject.name == "item_mana(Clone)")
                {
                    Manager.SendMessage("ChangeMP", 0.1f);
                }
                else if (coll.gameObject.name == "item_heal(Clone)")
                {
                    Manager.SendMessage("ChangeHP", 0.1f);
                }
                else if (coll.gameObject.name == "item_coin(Clone)")
                {
                    StageManager.get_coin++;
                    StageManager.score += 50;
                }
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "enemy")
            {
                ApplyDamage(coll.GetComponent<CEnemy>().ATK);
            }
            else if (coll.gameObject.tag == "boss")
            {
                Ifrit boss1 = coll.gameObject.GetComponent<Ifrit>();

                if (boss1 != null)
                {
                    ApplyDamage(0.3f);
                    return;
                }

                IceWitch ice_witch = coll.gameObject.GetComponent<IceWitch>();

                if (ice_witch != null)
                {
                    ApplyDamage(0.3f);
                    return;
                }

                Deathra deathra = coll.gameObject.GetComponent<Deathra>();

                if (deathra != null)
                {
                    ApplyDamage(0.3f);
                    return;
                }
            }
            else if (coll.gameObject.tag == "boss_part")
            {
                ApplyDamage(0.2f);
            }
            else if (coll.gameObject.tag == "laser")
            {
                if (coll.gameObject.GetComponent<IfritBeam>() != null)
                    ApplyDamage(0.5f);
                else if (coll.gameObject.GetComponent<DeathraEyeLaser>() != null)
                    ApplyDamage(0.5f);
                else if (coll.gameObject.GetComponent<DeathraWingLaser>() != null)
                    ApplyDamage(0.5f);
                else
                    ApplyDamage(0.9f);
            }
            else if (coll.gameObject.tag == "energy_ball")
                ApplyDamage(0.9f);
        }
    }

    void ApplyDamage(float damage_) // 전달용 함수
    {
        if (!invincible)
        {
            StartCoroutine(Kiraring());
            Manager.SendMessage("ApplyDamage", damage_);
        }
    }

    // 터치 좌표 입력
    public void SetMousePosition()
    {
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_position.z = 0;
    }

}
