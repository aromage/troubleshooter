using UnityEngine;
using System.Collections;

public class EnemyManager7 : CEnemyManager
{
	EnemyStatus Eye_F = new EnemyStatus(Enemy.Eye_F, 241f, 1283f, 0f, 600f, 0, 100);
	EnemyStatus BirdL_F = new EnemyStatus(Enemy.BirdL_F, 2406f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus BirdChain_F = new EnemyStatus(Enemy.BirdChain_F, 2406f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus ChampBird_F = new EnemyStatus(Enemy.ChampBird_F, 481f, 32080f, 10f, 400f, 0, 2000);
	EnemyStatus BirdR_F = new EnemyStatus(Enemy.BirdR_F, 2406f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Bird_F = new EnemyStatus(Enemy.Bird_F, 2406f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Shooter_F = new EnemyStatus(Enemy.Shooter_F, 321f, 4010f, 0f, 350f, 0, 300);
	EnemyStatus ChampShooter_F = new EnemyStatus(Enemy.ChampShooter_F, 481f, 32080f, 10f, 300f, 0, 2000);
	EnemyStatus Bat_F = new EnemyStatus(Enemy.Bat_F, 321f, 2807f, 0f, 800f, 0, 200);
	EnemyStatus ChampBat_F = new EnemyStatus(Enemy.ChampBat_F, 401f, 24060f, 10f, 800f, 0, 2000);
	EnemyStatus Gonyak_F = new EnemyStatus(Enemy.Gonyak_F, 2406f, 40f, 10000f, 300f, 0, 500);
    public override void ManageStage()
	{
		
		StartCoroutine(SummonEnemy(2f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.TL, 0.2f,7));
		StartCoroutine(SummonEnemy(3f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(4f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(5f, 5, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(6f, 5, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.TR, 0.2f,7));
		StartCoroutine(SummonEnemy(7f, 5, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(8f, 5, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(9f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(10f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		
		StartCoroutine(SummonEnemy(12f, 5, Eye_F, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(13f, 5, Eye_F, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(14f, 5, Eye_F, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(15f, 5, Eye_F, CEnemy.AI.No_2_L, CEnemy.StartPosition.L4, 0.3f,7));
		StartCoroutine(SummonEnemy(16f, 5, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(17f, 5, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(18f, 5, Eye_F, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(19f, 5, Eye_F, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));

		StartCoroutine(SummonEnemy(20f, 1, ChampBat_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,8));
		
		
		StartCoroutine(SummonEnemy(20.5f, 9, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T1,1f));
		StartCoroutine(SummonEnemy(20.5f, 9, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T2,1f));
		StartCoroutine(SummonEnemy(20.5f, 9, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T3,1f));
		
		StartCoroutine(SummonEnemy(21f, 8, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T5,1f));
		StartCoroutine(SummonEnemy(21f, 8, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T6,1f));
		StartCoroutine(SummonEnemy(21f, 8, Bat_F, CEnemy.AI.Go, CEnemy.StartPosition.T7,1f));

		
		StartCoroutine(SummonEnemy(31f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(32f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(33f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(34f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(35f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(36f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(37f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));

		
		StartCoroutine(SummonEnemy(40f, 1, ChampBird_F, CEnemy.AI.Fo_Long, CEnemy.StartPosition.T4, 0.2f,8));
		
		StartCoroutine(SummonEnemy(41f, 3, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 2.5f,4));
		StartCoroutine(SummonEnemy(41f, 3, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 2.5f,4));
		StartCoroutine(SummonEnemy(41.5f, 3, Shooter_F, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 2.5f,4));
		StartCoroutine(SummonEnemy(41.5f, 3, Shooter_F, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 2.5f,4));

		StartCoroutine(SummonEnemy(51f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(52f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(53f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(54f, 5, Eye_F, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f,7));

		StartCoroutine(SummonEnemy(60f, 1, ChampShooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,9));
	
		StartCoroutine(SummonEnemy(60f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(60f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));
		
		StartCoroutine(SummonEnemy(61.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(61.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
		
		StartCoroutine(SummonEnemy(63f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(63f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));
		
		StartCoroutine(SummonEnemy(64.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T7, 0.2f));
		StartCoroutine(SummonEnemy(64.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.TR, 0.2f));
		
		StartCoroutine(SummonEnemy(66f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(66f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));
		
		StartCoroutine(SummonEnemy(67.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(67.5f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
		
		StartCoroutine(SummonEnemy(69f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(69f, 1, Bird_F, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));
						
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T1, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T2, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T3, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T4, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T5, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T6, 1.2f,7));
		StartCoroutine(SummonEnemy(70f, 8, Eye_F, CEnemy.AI.Do, CEnemy.StartPosition.T7, 1.2f,7));
		
		StartCoroutine(SummonEnemy(72f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L3, 0.1f,7));
		StartCoroutine(SummonEnemy(72f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L4, 0.1f,7));
		StartCoroutine(SummonEnemy(72f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L5, 0.1f,7));
		StartCoroutine(SummonEnemy(74f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.1f,7));
		StartCoroutine(SummonEnemy(74f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R2, 0.1f,7));
		StartCoroutine(SummonEnemy(74f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R3, 0.1f,7));
		
		StartCoroutine(SummonEnemy(76f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L3, 0.1f,7));
		StartCoroutine(SummonEnemy(76f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L4, 0.1f,7));
		StartCoroutine(SummonEnemy(76f, 3, Eye_F, CEnemy.AI.SlL, CEnemy.StartPosition.L5, 0.1f,7));
		StartCoroutine(SummonEnemy(78f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R3, 0.1f,7));
		StartCoroutine(SummonEnemy(78f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R4, 0.1f,7));
		StartCoroutine(SummonEnemy(78f, 3, Eye_F, CEnemy.AI.SlR, CEnemy.StartPosition.R5, 0.1f,7));
		

        StartCoroutine(ClearEnemy(85f));
    }
}

