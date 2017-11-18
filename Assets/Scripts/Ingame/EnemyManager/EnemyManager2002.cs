using UnityEngine;
using System.Collections;

public class EnemyManager2002 : MonoBehaviour
{
	EnemyStatus Eye_A = new EnemyStatus(Enemy.Eye_A, 30f, 80f, 0f, 600f, 1, 100);
	EnemyStatus BirdL_A = new EnemyStatus(Enemy.BirdL_A, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus BirdChain_A = new EnemyStatus(Enemy.BirdChain_A, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus ChampBird_A = new EnemyStatus(Enemy.ChampBird_A, 60f, 4000f, 10f, 400f, 5, 2000);
	EnemyStatus BirdR_A = new EnemyStatus(Enemy.BirdR_A, 300f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus Bird_A = new EnemyStatus(Enemy.Bird_A, 30f, 15f, 10000f, 400f, 3, 500);
	EnemyStatus Shooter_A = new EnemyStatus(Enemy.Shooter_A, 15f, 400f, 0f, 350f, 1, 300);
	EnemyStatus ChampShooter_A = new EnemyStatus(Enemy.ChampShooter_A, 60f, 4000f, 10f, 300f, 5, 2000);
	EnemyStatus Bat_A = new EnemyStatus(Enemy.Bat_A, 15f, 350f, 0f, 800f, 2, 200);
	EnemyStatus ChampBat_A = new EnemyStatus(Enemy.ChampBat_A, 50f, 3000f, 10f, 800f, 5, 2000);
	EnemyStatus Gonyak_A = new EnemyStatus(Enemy.Gonyak_A, 300f, 15f, 10000f, 300f, 3, 500);

    // Use this for initialization
    void Start()
    {
        Debug.Log("Enter EnemyManager 2002-");
        ManageStage();
    }

    void ManageStage()
    {
//Nomal
		StartCoroutine (SummonEnemy (2f, 3, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));		
		StartCoroutine (SummonEnemy (3f, 3, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine (SummonEnemy (5f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine (SummonEnemy (5f, 3, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine (SummonEnemy (6f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine (SummonEnemy (6f, 3, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine (SummonEnemy (6f, 3, Eye_A, CEnemy.AI.No_2_R, CEnemy.StartPosition.R2, 0.2f,7));
		StartCoroutine (SummonEnemy (7f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine (SummonEnemy (7f, 3, Eye_A, CEnemy.AI.No_2_L, CEnemy.StartPosition.L2, 0.2f,7));
		StartCoroutine (SummonEnemy (8f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine (SummonEnemy (8f, 3, Eye_A, CEnemy.AI.No_2_R, CEnemy.StartPosition.R2, 0.2f,7));
		StartCoroutine (SummonEnemy (9f, 3, Eye_A, CEnemy.AI.No_2_L, CEnemy.StartPosition.L2, 0.2f,7));
		StartCoroutine (SummonEnemy (9f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f,7));

//Section3

		StartCoroutine (SummonEnemy (12f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f, 2));		
		StartCoroutine (SummonEnemy (12f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T4, 0.2f, 1));
		StartCoroutine (SummonEnemy (12f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f, 2));
		StartCoroutine (SummonEnemy (13f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (13f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (13f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (13f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (13f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (17f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (17f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (17f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (17f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (17f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
		StartCoroutine (SummonEnemy (19f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (19f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (19f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (19f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (19f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
	
				
		StartCoroutine (SummonEnemy (22f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.5f));
		StartCoroutine (SummonEnemy (22f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (22f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));
		StartCoroutine (SummonEnemy (22f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (23f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.5f));
		StartCoroutine (SummonEnemy (23f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (23f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));
		StartCoroutine (SummonEnemy (23f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (24f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));
		StartCoroutine (SummonEnemy (24f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (25f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.5f));
		StartCoroutine (SummonEnemy (25f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.5f));
		StartCoroutine (SummonEnemy (25f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (25f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));
		StartCoroutine (SummonEnemy (25f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (26f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.5f));
		StartCoroutine (SummonEnemy (26f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (27f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.5f));
		StartCoroutine (SummonEnemy (27f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (27f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.5f));
		StartCoroutine (SummonEnemy (27f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.5f));

		

		StartCoroutine (SummonEnemy (28f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.5f));
		StartCoroutine (SummonEnemy (28f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));

		

		StartCoroutine (SummonEnemy (29f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.5f));
		StartCoroutine (SummonEnemy (29f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.5f));
		StartCoroutine (SummonEnemy (29f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.5f));


//Champ Start
		StartCoroutine (SummonEnemy (30f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (30f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));	
		StartCoroutine (SummonEnemy (30f, 1, ChampBird_A, CEnemy.AI.C_BRD, CEnemy.StartPosition.T4, 0.2f,8));	//Champ
		StartCoroutine (SummonEnemy (30f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));	
		StartCoroutine (SummonEnemy (30f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));

		StartCoroutine (SummonEnemy (32f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (32f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));	
		StartCoroutine (SummonEnemy (32f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));	
		StartCoroutine (SummonEnemy (32f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));

		StartCoroutine (SummonEnemy (34f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (34f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));	
		StartCoroutine (SummonEnemy (34f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));	
		StartCoroutine (SummonEnemy (34f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));

		StartCoroutine (SummonEnemy (36f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (36f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));	
		StartCoroutine (SummonEnemy (36f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));	
		StartCoroutine (SummonEnemy (36f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
 //Champ End

//Section1
		StartCoroutine (SummonEnemy (38f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (39f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (15f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
		StartCoroutine (SummonEnemy (41f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f));
		StartCoroutine (SummonEnemy (42f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));
		StartCoroutine (SummonEnemy (43f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f));
		StartCoroutine (SummonEnemy (44f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (45f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (39f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (15f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (41f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine (SummonEnemy (42f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine (SummonEnemy (43f, 1, Gonyak_A, CEnemy.AI.Do, CEnemy.StartPosition.T7, 0.2f));
		StartCoroutine (SummonEnemy (44f, 1, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f));

//Section2
		StartCoroutine (SummonEnemy (48f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));		
		StartCoroutine (SummonEnemy (48f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (48f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (49f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (49f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (49f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (49f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
		StartCoroutine (SummonEnemy (50f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (52f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 0.2f));
		StartCoroutine (SummonEnemy (52f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 0.2f));
		StartCoroutine (SummonEnemy (52f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 0.2f));
		StartCoroutine (SummonEnemy (53f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (53f, 1, BirdL_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 0.2f));
		StartCoroutine (SummonEnemy (53f, 1, BirdChain_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 0.2f));
		StartCoroutine (SummonEnemy (53f, 1, BirdR_A, CEnemy.AI.Do, CEnemy.StartPosition.Br7, 0.2f));
		StartCoroutine (SummonEnemy (54f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));

 //Champ Start
		StartCoroutine (SummonEnemy (60f, 1, Bat_A, CEnemy.AI.RE_CL, CEnemy.StartPosition.T2, 0.2f));	
		StartCoroutine (SummonEnemy (60f, 1, ChampBat_A, CEnemy.AI.C_RE, CEnemy.StartPosition.T4, 0.2f,8)); // Champ	
		StartCoroutine (SummonEnemy (60f, 1, Bat_A, CEnemy.AI.RE_CR, CEnemy.StartPosition.T6, 0.2f));	
 //Champ End
		StartCoroutine (SummonEnemy (68f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.L1, 0.2f,6));
		StartCoroutine (SummonEnemy (68f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.R1, 0.2f,6));
		StartCoroutine (SummonEnemy (68f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 0.2f,4));
		StartCoroutine (SummonEnemy (68f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 0.2f,6));
		
		StartCoroutine (SummonEnemy (70f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.TL, 0.2f,6));
		StartCoroutine (SummonEnemy (70f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.TR, 0.2f,6));
		
		StartCoroutine (SummonEnemy (72f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.L2, 0.2f,4));
		StartCoroutine (SummonEnemy (72f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.R2, 0.2f,4));
//Section4
		StartCoroutine (SummonEnemy (78f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (78f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (79f, 3, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine (SummonEnemy (79f, 3, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine (SummonEnemy (80f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.TR, 0.2f,4));
		StartCoroutine (SummonEnemy (81f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.TL, 0.2f,4));
		StartCoroutine (SummonEnemy (82f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.R1, 0.2f,4));
		StartCoroutine (SummonEnemy (83f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.L1, 0.2f,4));
		StartCoroutine (SummonEnemy (84f, 3, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine (SummonEnemy (84f, 3, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine (SummonEnemy (85f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));


//Champ Start
		StartCoroutine (SummonEnemy (90f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.TL, 0.2f,3));	
		StartCoroutine (SummonEnemy (90f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.2f,2));	
		StartCoroutine (SummonEnemy (90f, 1, ChampShooter_A, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 0.2f,9));	//Champ
		StartCoroutine (SummonEnemy (90f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.2f,2));	
		StartCoroutine (SummonEnemy (90f, 1, Shooter_A, CEnemy.AI.Wat, CEnemy.StartPosition.TR, 0.2f,3));	
 //Champ End
//Section7
		StartCoroutine (SummonEnemy (99f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (99f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (99f, 1, Gonyak_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine (SummonEnemy (99f, 1, Gonyak_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 0.2f));
		StartCoroutine (SummonEnemy (100f, 1, Gonyak_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine (SummonEnemy (101f, 1, Gonyak_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 0.2f));
		StartCoroutine (SummonEnemy (100f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine (SummonEnemy (101f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.L1, 0.2f,4));
		StartCoroutine (SummonEnemy (102f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.R1, 0.2f,4));
		StartCoroutine (SummonEnemy (103f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine (SummonEnemy (103f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));

//Section8
		StartCoroutine (SummonEnemy (107f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2, 0.2f));		
		StartCoroutine (SummonEnemy (107f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6, 0.2f));
		StartCoroutine (SummonEnemy (108f, 3, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine (SummonEnemy (108f, 3, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine (SummonEnemy (109f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 0.2f,4));
		StartCoroutine (SummonEnemy (110f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 0.2f,4));
		StartCoroutine (SummonEnemy (111f, 1, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 0.2f,6));
		StartCoroutine (SummonEnemy (112f, 1, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 0.2f,6));
		StartCoroutine (SummonEnemy (113f, 3, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine (SummonEnemy (113f, 3, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine (SummonEnemy (114f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));

        StartCoroutine(CallBossManager(120.0f, 2000));

    }

    IEnumerator CallEnemyManager(float time, int index)
    {
        yield return new WaitForSeconds(time);
        ////Debug.log("Destroy EnemyManager 1000-");

        GameObject.Find("StageManager").SendMessage("CallEnemyManager", index);
    }
    IEnumerator CallBossManager(float time, int index)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("StageManager").SendMessage("CallBossManager", index);
    }
    IEnumerator DestroyBossManager(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("StageManager").SendMessage("DestroyBossManager");
    }

    IEnumerator SummonEnemy(float summon_time,
                            int number_of_summon,
                            EnemyStatus enemy_,
                            CEnemy.AI AI_type,
                            CEnemy.StartPosition start_position,
                            float delay = 0.5f,
                            int shooter_num = 0)
    {
        GameObject enemy;

        enemy = ResourceLoad.PickGameObject(enemy_.name.ToString());

        yield return new WaitForSeconds(summon_time);

        int InfinityCount = StageManager.InfinityModeCount;
        if (InfinityCount < 0)
        {
            InfinityCount = 1;
        }

        for (int formation = 0; formation < number_of_summon; formation++)
        {
            GameObject temp = (GameObject)Instantiate(enemy, CEnemy.GetStartPosition(start_position), Quaternion.identity);
            CEnemy temp_enemy = temp.GetComponent<CEnemy>();
            temp_enemy.Initialize(
				AI_type,
				enemy_.ATK + ((InfinityCount - 1) * enemy_.ATK * 0.18f),
				enemy_.HP + ((InfinityCount - 1) * enemy_.HP * 0.18f),
				enemy_.SPD,
				enemy_.DEF,
				shooter_num,
				enemy_.coin_amount,
				enemy_.score + ((InfinityCount - 1) / 2 * 100)
				);

            yield return new WaitForSeconds(delay);
        }
    }
}
