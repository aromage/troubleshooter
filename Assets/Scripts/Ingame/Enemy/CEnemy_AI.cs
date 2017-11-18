using UnityEngine;
using System.Collections;

public partial class CEnemy : MonoBehaviour
{
    // enums
    public enum AI
    {
        No_1_L_St,
        No_1_L_Tu,
        No_1_R_St,
        No_1_R_Tu,
        No_2_L,
        No_2_R,
        RE_L,
        RE_R,
        RE_C,
        RE_CL,
        RE_CR,
        RE_T,
        Do,
        Do2,
        SlR,
        SlL,
        Wat,
		Wat_Long,
        Fo,
		Fo_Long,
        Sho_L,
        Sho_R,
		Sho_L_Long,
		Sho_R_Long,
        Go,
        C_RE,
		C_SHO,
		C_BRD

    }
    void SetAI(AI AI_type)
    {
        switch (AI_type)
        {
            case AI.No_1_L_St:
                StartCoroutine(AI_No_1_L_St_FSM());
                break;
            case AI.No_1_L_Tu:
                StartCoroutine(AI_No_1_L_Tu_FSM());
                break;
            case AI.No_1_R_St:
                StartCoroutine(AI_No_1_R_St_FSM());
                break;
            case AI.No_1_R_Tu:
                StartCoroutine(AI_No_1_R_Tu_FSM());
                break;
            case AI.No_2_L:
                StartCoroutine(AI_No_2_L_FSM());
                break;
            case AI.No_2_R:
                StartCoroutine(AI_No_2_R_FSM());
                break;
            case AI.RE_L:
                StartCoroutine(AI_RE_L_FSM());
                break;
            case AI.RE_R:
                StartCoroutine(AI_RE_R_FSM());
                break;
            case AI.RE_C:
                StartCoroutine(AI_RE_C_FSM());
                break;
            case AI.RE_CR:
                StartCoroutine(AI_RE_CR_FSM());
                break;
            case AI.RE_CL:
                StartCoroutine(AI_RE_CL_FSM());
                break;
            case AI.RE_T:
                StartCoroutine(AI_RE_T_FSM());
                break;
            case AI.Do:
                StartCoroutine(AI_Do_FSM());
                break;
            case AI.Do2:
                StartCoroutine(AI_Do2_FSM());
                break;
            case AI.SlL:
                StartCoroutine(AI_SlL_FSM());
                break;
            case AI.SlR:
                StartCoroutine(AI_SlR_FSM());
                break;
            case AI.Fo:
                StartCoroutine(AI_Fo_FSM());
                break;
		case AI.Fo_Long:
			StartCoroutine(AI_Fo_FSM());
			break;
            case AI.Wat:
                StartCoroutine(AI_Wat_FSM());
                break;
			case AI.Wat_Long:
			StartCoroutine(AI_Wat_FSM());
			break;
            case AI.Sho_L:
                StartCoroutine(AI_Sho_L_FSM());
                break;
            case AI.Sho_R:
                StartCoroutine(AI_Sho_R_FSM());
                break;
		case AI.Sho_L_Long:
			StartCoroutine(AI_Sho_L_FSM());
			break;
		case AI.Sho_R_Long:
			StartCoroutine(AI_Sho_R_FSM());
			break;
            case AI.Go:
                StartCoroutine(AI_Go_FSM());
                break;
            case AI.C_RE:
                StartCoroutine(AI_C_RE_FSM());
                break;
		case AI.C_SHO:
			StartCoroutine(AI_C_SHO_FSM());
			break;
		case AI.C_BRD:
			StartCoroutine(AI_C_BRD_FSM());
			break;
        }
    }

    IEnumerator AI_No_1_L_St_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_1_L);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }
    }
    IEnumerator AI_No_1_L_Tu_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[3];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_1_L);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionMoveByTowards(gameObject, speed, 1000f, 45f);
        pattern_actions[2] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_No_1_R_St_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_1_R);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }


    }
    IEnumerator AI_No_1_R_Tu_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[3];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_1_R);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionMoveByTowards(gameObject, speed, 1000f, 135f);
        pattern_actions[2] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }
    }
    IEnumerator AI_No_2_L_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_2_L);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_No_2_R_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_NO_2_R);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed);


        while (true)
        {
            ExecuteAction();

            yield return null;
        }


    }
    IEnumerator AI_RE_L_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[7];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 800f, new Vector3(400f, 500f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[5] = Action.ActionMoveTowards(gameObject, 1600, "player"); //재 돌진
        pattern_actions[6] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }



    }
    IEnumerator AI_RE_R_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[7];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 800f, new Vector3(-400f, 500f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[5] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //재 돌진
        pattern_actions[6] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_RE_C_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[7];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 800f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[5] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //재 돌진
        pattern_actions[6] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_RE_CR_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[7];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 800f, new Vector3(200f, 500f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[5] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //재 돌진
        pattern_actions[6] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_RE_CL_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[7];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 800f, new Vector3(-200f, 500f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionStop(gameObject, 1f); // 대기 시간
        pattern_actions[5] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //재 돌진
        pattern_actions[6] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_RE_T_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[9];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByPath(gameObject, speed, path_RE);
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionStop(gameObject, 2f); // 대기 시간
        pattern_actions[2] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[3] = Action.ActionStop(gameObject, 0.5f); // 대기 시간
        pattern_actions[4] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[5] = Action.ActionStop(gameObject, 0.5f); // 대기 시간
        pattern_actions[6] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[7] = Action.ActionMoveByTowards(gameObject, speed, 10f, -90f);
        pattern_actions[8] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_Do_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 2000f, -90f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_Do2_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[3];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionStop(gameObject, 0.5f);
        pattern_actions[1] = Action.ActionMoveByTowards(gameObject, speed, 2000f, -90f);  //각도만 조절하면 됨
        pattern_actions[2] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_SlL_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 2000f, -20f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_SlR_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 2000f, -160f);  //각도만 조절하면 됨
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed);

        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_Fo_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[4];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 300f, -90f);  //각도만 조절하면 됨
        // KeepGoing (Default)
        pattern_actions[1] = Action.ActionKeepFollowing(gameObject, 3f);
        pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 10f, -90f);
        pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);

        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
	IEnumerator AI_Fo_Long_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[4];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 300f, -90f);  //각도만 조절하면 됨
		// KeepGoing (Default)
		pattern_actions[1] = Action.ActionKeepFollowing(gameObject, 10f);
		pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 10f, -90f);
		pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
    IEnumerator AI_Wat_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[4];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 150f, -90f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionStop(gameObject, 8f);
        pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 90f);
        // KeepGoing (Default)
        pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);

        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
	IEnumerator AI_Wat_Long_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[4];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 150f, -90f);  //각도만 조절하면 됨
		pattern_actions[1] = Action.ActionStop(gameObject, 10f);
		pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 90f);
		// KeepGoing (Default)
		pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
    IEnumerator AI_Sho_L_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[4];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 150f, 0f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionStop(gameObject, 2f);
        pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 180f);
        // KeepGoing (Default)
        pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);

        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_Sho_R_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[4];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 100f, 180f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionStop(gameObject, 2f);
        pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 0f);
        // KeepGoing (Default)
        pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);

        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
	IEnumerator AI_Sho_L_Long_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[4];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 150f, 0f);  //각도만 조절하면 됨
		pattern_actions[1] = Action.ActionStop(gameObject, 10f);
		pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 180f);
		// KeepGoing (Default)
		pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
	IEnumerator AI_Sho_R_Long_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[4];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 100f, 180f);  //각도만 조절하면 됨
		pattern_actions[1] = Action.ActionStop(gameObject, 10f);
		pattern_actions[2] = Action.ActionMoveByTowards(gameObject, speed, 200f, 0f);
		// KeepGoing (Default)
		pattern_actions[3] = Action.ActionKeepGoing(gameObject, speed);
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
    IEnumerator AI_Go_FSM()
    {
        // Memory Allocation
        pattern_actions = new Action[2];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveTowards(gameObject, 1200f, "player"); //돌진
        pattern_actions[1] = Action.ActionKeepGoing(gameObject, speed); //퇴장


        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
    IEnumerator AI_C_RE_FSM()
    {
        // Memory Allocation
		pattern_actions = new Action[237];

        condition_actions = new Action[1][];
        condition_actions[0] = new Action[2];

        // Pattern Actions
        // MoveByPath
        pattern_actions[0] = Action.ActionMoveByTowards(gameObject, speed, 180f, -90f);  //각도만 조절하면 됨
        pattern_actions[1] = Action.ActionStop(gameObject, 5f);
        pattern_actions[2] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
        pattern_actions[3] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
        pattern_actions[4] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
        pattern_actions[5] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[6] = Action.ActionStop(gameObject, 2f);
        pattern_actions[7] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[8] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[9] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[10] = Action.ActionStop(gameObject, 2f);
        pattern_actions[11] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
        pattern_actions[12] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[13] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[14] = Action.ActionStop(gameObject, 2f);
        pattern_actions[15] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[16] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
        pattern_actions[17] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
        pattern_actions[18] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[19] = Action.ActionStop(gameObject, 2f);
        pattern_actions[20] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[21] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[22] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[23] = Action.ActionStop(gameObject, 2f);
        pattern_actions[24] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
        pattern_actions[25] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[26] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[27] = Action.ActionStop(gameObject, 2f);
        pattern_actions[28] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
        pattern_actions[29] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
        pattern_actions[30] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
        pattern_actions[31] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[32] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[33] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
        pattern_actions[34] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
        pattern_actions[35] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
        pattern_actions[36] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[37] = Action.ActionStop(gameObject, 2f);
        pattern_actions[38] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[39] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[40] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[41] = Action.ActionStop(gameObject, 2f);
        pattern_actions[42] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
        pattern_actions[43] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[44] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[45] = Action.ActionStop(gameObject, 2f);
        pattern_actions[46] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[47] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
        pattern_actions[48] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
        pattern_actions[49] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[50] = Action.ActionStop(gameObject, 2f);
        pattern_actions[51] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
        pattern_actions[52] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[53] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[54] = Action.ActionStop(gameObject, 2f);
        pattern_actions[55] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
        pattern_actions[56] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
        pattern_actions[57] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
        pattern_actions[58] = Action.ActionStop(gameObject, 2f);
		pattern_actions[59] = Action.ActionMoveByTowards(gameObject, speed, 180f, -90f);  //각도만 조절하면 됨
		pattern_actions[60] = Action.ActionStop(gameObject, 5f);
		pattern_actions[61] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[62]= Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[63] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[64] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[65] = Action.ActionStop(gameObject, 2f);
		pattern_actions[66] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[67] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[68] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[69] = Action.ActionStop(gameObject, 2f);
		pattern_actions[70] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[71] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[72] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[73] = Action.ActionStop(gameObject, 2f);
		pattern_actions[74] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[75] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[76] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[77] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[78] = Action.ActionStop(gameObject, 2f);
		pattern_actions[79] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[80] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[81] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[82] = Action.ActionStop(gameObject, 2f);
		pattern_actions[83] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[84] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[85] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[86] = Action.ActionStop(gameObject, 2f);
		pattern_actions[87] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[88] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[89] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[90] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[91] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[92] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[93] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[94] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[95] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[96] = Action.ActionStop(gameObject, 2f);
		pattern_actions[97] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[98] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[99] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[100] = Action.ActionStop(gameObject, 2f);
		pattern_actions[101] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[102] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[103] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[104] = Action.ActionStop(gameObject, 2f);
		pattern_actions[105] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[106] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[107] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[108] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[109] = Action.ActionStop(gameObject, 2f);
		pattern_actions[110] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[111] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[112] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[113] = Action.ActionStop(gameObject, 2f);
		pattern_actions[114] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[115] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[116] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[117] = Action.ActionStop(gameObject, 2f);
		pattern_actions[118] = Action.ActionMoveByTowards(gameObject, speed, 180f, -90f);  //각도만 조절하면 됨
		pattern_actions[119] = Action.ActionStop(gameObject, 5f);
		pattern_actions[120] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[121] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[122] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[123] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[124] = Action.ActionStop(gameObject, 2f);
		pattern_actions[125] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[126] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[127] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[128] = Action.ActionStop(gameObject, 2f);
		pattern_actions[129] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[130] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[131] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[132] = Action.ActionStop(gameObject, 2f);
		pattern_actions[133] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[134] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[135] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[136] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[137] = Action.ActionStop(gameObject, 2f);
		pattern_actions[138] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[139] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[140] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[141] = Action.ActionStop(gameObject, 2f);
		pattern_actions[142] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[143] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[144] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[145] = Action.ActionStop(gameObject, 2f);
		pattern_actions[146] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[147] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[148] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[149] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[150] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[151] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[152] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[153] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[154] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[155] = Action.ActionStop(gameObject, 2f);
		pattern_actions[156] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[157] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[158] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[159] = Action.ActionStop(gameObject, 2f);
		pattern_actions[160] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[161] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[162] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[163] = Action.ActionStop(gameObject, 2f);
		pattern_actions[164] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[165] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[166] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[167] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[168] = Action.ActionStop(gameObject, 2f);
		pattern_actions[169] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[170] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[171] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[172] = Action.ActionStop(gameObject, 2f);
		pattern_actions[173] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[174] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[175] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[176] = Action.ActionStop(gameObject, 2f);
		pattern_actions[177] = Action.ActionMoveByTowards(gameObject, speed, 180f, -90f);  //각도만 조절하면 됨
		pattern_actions[178] = Action.ActionStop(gameObject, 5f);
		pattern_actions[179] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[180] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[181] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[182] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[183] = Action.ActionStop(gameObject, 2f);
		pattern_actions[184] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[185] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[186] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[187] = Action.ActionStop(gameObject, 2f);
		pattern_actions[188] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[189] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[190] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[191] = Action.ActionStop(gameObject, 2f);
		pattern_actions[192] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[193] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[194] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[195] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[196] = Action.ActionStop(gameObject, 2f);
		pattern_actions[197] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[198] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[199] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[200] = Action.ActionStop(gameObject, 2f);
		pattern_actions[201] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[202] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[203] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[204] = Action.ActionStop(gameObject, 2f);
		pattern_actions[205] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[206] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[207] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[208] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[209] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[210] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[211] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -240f, 0f)); // 돌아가기
		pattern_actions[212] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -480f, 0f)); // 돌아가기
		pattern_actions[213] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[214] = Action.ActionStop(gameObject, 2f);
		pattern_actions[215] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[216] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[217] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[218] = Action.ActionStop(gameObject, 2f);
		pattern_actions[219] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, 240f, 0f)); // 돌아가기
		pattern_actions[220] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[221] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[222] = Action.ActionStop(gameObject, 2f);
		pattern_actions[223] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[224] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[225] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, -480f, 0f)); // 돌아가기
		pattern_actions[226] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[227] = Action.ActionStop(gameObject, 2f);
		pattern_actions[228] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(200f, 240f, 0f)); // 돌아가기
		pattern_actions[229] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[230] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[231] = Action.ActionStop(gameObject, 2f);
		pattern_actions[232] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(-200f, -240f, 0f)); // 돌아가기
		pattern_actions[233] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[234] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[235] = Action.ActionStop(gameObject, 2f);
        pattern_actions[236] = Action.ActionKeepGoing(gameObject, speed); //퇴장
	
        while (true)
        {
            ExecuteAction();

            yield return null;
        }

    }
	IEnumerator AI_C_BRD_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[130];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions[0] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 0f, 0f)); // 돌아가기
		pattern_actions[1] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[2] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[3] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[4] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[5] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[6] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[7] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[8] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[9] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[10] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[11] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[12] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[13] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[14] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[15] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[16] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[17] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[18] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[19] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[20] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[21] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[22] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[23] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[24] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[25] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[26] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[27] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[28] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[29] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[30] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[31] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[32] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[33] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[34] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[35] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[36] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[37] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[38] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[39] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[40] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[41] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[42] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[43] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[44] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[45] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[46] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[47] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[48] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[49] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[50] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[51] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[52] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[53] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[54] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[55] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[56] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[57] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[58] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[59] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[60] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[61] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[62] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[63] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[64] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[65] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[66] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[67] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[68] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[69] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[70] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[71] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[72] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[73] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[74] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[75] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[76] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[77] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[78] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[79] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[80] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[81] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[82] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[83] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[84] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[85] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[86] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[87] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[88] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[89] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[90] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[91] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[92] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[93] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[94] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[95] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[96] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[97] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[98] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[99] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[100] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[101] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[102] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[103] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[104] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[105] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[106] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[107] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[108] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[109] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[110] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[111] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[112] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[113] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[114] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[115] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[116] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[117] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[118] = Action.ActionMoveTowards(gameObject, 1500f, "player"); //돌진
		pattern_actions[119] = Action.ActionMoveTo(gameObject, 1500f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[120] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[121] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[122] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[123] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[124] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[125] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[126] = Action.ActionKeepFollowing (gameObject, 3f);
		pattern_actions[127] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 270f);  //각도만 조절하면 됨
		pattern_actions[128] = Action.ActionMoveTo(gameObject, 1200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions[129] = Action.ActionKeepGoing(gameObject, speed); //퇴장
		
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
	IEnumerator AI_C_SHO_FSM()
	{
		// Memory Allocation
		pattern_actions = new Action[183];
		
		condition_actions = new Action[1][];
		condition_actions[0] = new Action[2];
		
		// Pattern Actions
		// MoveByPath
		pattern_actions [0] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [1] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [2] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [3] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [4] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [5] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [6] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [7] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [8] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [9] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [10] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [11] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [12] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [13] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [14] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [15] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [16] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [17] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [18] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [19] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [20] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [21] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [22] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [23] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [24] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [25] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [26] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [27] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [28] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [29] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [30] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [31] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [32] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [33] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [34] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [35] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [36] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [37] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [38] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [39] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [40] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [41] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [42] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [43] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [44] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [45] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [46] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [47] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [48] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [49] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [50] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [51] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [52] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [53] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [54] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [55] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [56] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [57] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [58] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [59] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [60] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [61] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [62] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [63] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [64] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [65] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [66] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [67] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [68] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [69] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [70] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [71] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [72] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [73] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [74] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [75] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [76] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [77] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [78] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [79] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [80] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [81] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [82] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [83] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [84] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [85] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [86] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [87] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [88] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [89] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [90] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [91] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [92] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [93] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [94] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [95] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [96] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [97] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [98] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [99] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [100] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [101] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [102] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [103] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [104] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [105] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [106] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [107] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [108] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [109] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [110] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [111] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [112] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [113] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [114] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [115] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [116] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [117] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [118] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [119] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [120] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [121] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [122] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [123] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [124] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [125] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [126] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [127] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [128] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [129] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [130] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [131] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [132] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [133] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [134] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [135] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [136] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [137] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [138] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [139] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [140] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [141] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [142] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [143] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [144] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [145] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [146] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [147] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [148] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [149] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [150] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [151] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [152] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [153] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [154] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [155] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [156] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [157] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [158] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [159] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [160] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [161] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [162] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [163] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [164] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [165] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [166] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [167] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [168] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [169] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [170] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [171] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [172] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [173] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [174] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		pattern_actions [175] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 500f, 0f)); // 돌아가기
		pattern_actions [176] = Action.ActionMoveTo(gameObject, 200f, new Vector3(-250f, 350f, 0f)); // 돌아가기
		pattern_actions [177] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 350f, 0f)); // 돌아가기
		pattern_actions [178] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 350f, 0f)); // 돌아가기
		pattern_actions [179] = Action.ActionMoveTo(gameObject, 200f, new Vector3(250f, 500f, 0f)); // 돌아가기
		pattern_actions [180] = Action.ActionMoveTo(gameObject, 200f, new Vector3(0f, 500f, 0f)); // 돌아가기
		// KeepGoing (Default)
		pattern_actions[181] = Action.ActionMoveByTowards(gameObject, 1300f, 1000f, 90f);  //각도만 조절하면 됨
		pattern_actions[182] = Action.ActionKeepGoing(gameObject, speed);
		
		
		while (true)
		{
			ExecuteAction();
			
			yield return null;
		}
		
	}
}