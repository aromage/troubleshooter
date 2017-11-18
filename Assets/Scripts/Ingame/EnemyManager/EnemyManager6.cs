using UnityEngine;
using System.Collections;

public class EnemyManager6 : CEnemyManager
{
	EnemyStatus Eye_A = new EnemyStatus(Enemy.Eye_A, 187f, 995f, 0f, 600f, 0, 100);
	EnemyStatus BirdL_A = new EnemyStatus(Enemy.BirdL_A, 1866f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus BirdChain_A = new EnemyStatus(Enemy.BirdChain_A, 1866f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus ChampBird_A = new EnemyStatus(Enemy.ChampBird_A, 373f, 24880f, 10f, 400f, 0, 2000);
	EnemyStatus BirdR_A = new EnemyStatus(Enemy.BirdR_A, 1866f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Bird_A = new EnemyStatus(Enemy.Bird_A, 1866f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Shooter_A = new EnemyStatus(Enemy.Shooter_A, 249f, 3110f, 0f, 350f, 0, 300);
	EnemyStatus ChampShooter_A = new EnemyStatus(Enemy.ChampShooter_A, 373f, 24880f, 10f, 300f, 0, 2000);
	EnemyStatus Bat_A = new EnemyStatus(Enemy.Bat_A, 249f, 2177f, 0f, 800f, 0, 200);
	EnemyStatus ChampBat_A = new EnemyStatus(Enemy.ChampBat_A, 311f, 19200f, 10f, 800f, 0, 2000);
	EnemyStatus Gonyak_A = new EnemyStatus(Enemy.Gonyak_A, 1866f, 40f, 10000f, 300f, 0, 500);

    public override void ManageStage()
    {
		StartCoroutine(SummonEnemy(1f, 5, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(2f, 5, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(3f, 5, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(5f, 5, Eye_A, CEnemy.AI.No_2_R, CEnemy.StartPosition.R4, 0.3f,7));
		StartCoroutine(SummonEnemy(5f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(7f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(8f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(9f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));

		StartCoroutine(SummonEnemy(10f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.TL, 0.2f,7));
		StartCoroutine(SummonEnemy(11f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(12f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(13f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(14f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.TR, 0.2f,7));
		StartCoroutine(SummonEnemy(15f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(16f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(17f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(18f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));

		StartCoroutine(SummonEnemy(20f, 1, ChampBird_A, CEnemy.AI.Fo_Long, CEnemy.StartPosition.T4, 0.2f,8));
		
		StartCoroutine(SummonEnemy(21f, 3, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 2.5f,4));
		StartCoroutine(SummonEnemy(21f, 3, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 2.5f,4));
		StartCoroutine(SummonEnemy(21.5f, 3, Shooter_A, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 2.5f,4));
		StartCoroutine(SummonEnemy(21.5f, 3, Shooter_A, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 2.5f,4));

	
		StartCoroutine(SummonEnemy(31f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(32f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(33f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(34f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(35f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(36f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(37f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));

		StartCoroutine(SummonEnemy(40f, 1, ChampShooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,9));
		
		StartCoroutine(SummonEnemy(40f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(40f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));
		
		StartCoroutine(SummonEnemy(41.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(41.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
		
		StartCoroutine(SummonEnemy(43f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(43f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));
		
		StartCoroutine(SummonEnemy(44.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T7, 0.2f));
		StartCoroutine(SummonEnemy(44.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TR, 0.2f));
		
		StartCoroutine(SummonEnemy(46f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(46f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));
		
		StartCoroutine(SummonEnemy(47.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(47.5f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
		
		StartCoroutine(SummonEnemy(49f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(49f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));
		
		StartCoroutine(SummonEnemy(51f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(52f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(53f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(54f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(55f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(56f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(57f, 5, Eye_A, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));

				
 		StartCoroutine(SummonEnemy(60f, 1, ChampBat_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,8));
		
		
		StartCoroutine(SummonEnemy(60.5f, 9, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T1,1f));
		StartCoroutine(SummonEnemy(60.5f, 9, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T2,1f));
		StartCoroutine(SummonEnemy(60.5f, 9, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T3,1f));
		
		StartCoroutine(SummonEnemy(61f, 8, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T5,1f));
		StartCoroutine(SummonEnemy(61f, 8, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T6,1f));
		StartCoroutine(SummonEnemy(61f, 8, Bat_A, CEnemy.AI.Go, CEnemy.StartPosition.T7,1f));

		
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T1, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T7, 1.2f,7));
		
		StartCoroutine(SummonEnemy(71f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(72f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(73f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
		
		
		StartCoroutine(SummonEnemy(75f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(76f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(77f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));

        StartCoroutine(ClearEnemy(93f));
    }
}
