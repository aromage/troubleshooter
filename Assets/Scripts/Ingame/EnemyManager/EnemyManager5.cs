using UnityEngine;
using System.Collections;

public class EnemyManager5 : CEnemyManager
{
	EnemyStatus Eye_N = new EnemyStatus(Enemy.Eye_N, 133f, 707f, 0f, 600f, 0, 100);
	EnemyStatus BirdL_N = new EnemyStatus(Enemy.BirdL_N, 300f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus BirdChain_N = new EnemyStatus(Enemy.BirdChain_N, 1325f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus ChampBird_N = new EnemyStatus(Enemy.ChampBird_N, 265f, 17680f, 10f, 400f, 0, 2000);
	EnemyStatus BirdR_N = new EnemyStatus(Enemy.BirdR_N, 1325f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Bird_N = new EnemyStatus(Enemy.Bird_N, 1325f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Shooter_N = new EnemyStatus(Enemy.Shooter_N, 177f, 2210f, 0f, 350f, 0, 300);
	EnemyStatus ChampShooter_N = new EnemyStatus(Enemy.ChampShooter_N, 265f, 17680f, 10f, 300f, 0, 2000);
	EnemyStatus Bat_N = new EnemyStatus(Enemy.Bat_N, 177f, 1547f, 0f, 800f, 0, 200);
	EnemyStatus ChampBat_N = new EnemyStatus(Enemy.ChampBat_N, 221f, 17680f, 10f, 800f, 0, 2000);
	EnemyStatus Gonyak_N = new EnemyStatus(Enemy.Gonyak_A, 1325f, 40f, 10000f, 300f, 0, 500);

    public override void ManageStage()
    {
        StartCoroutine(SummonEnemy(1f, 5, Eye_N, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(2f, 5, Eye_N, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(3f, 5, Eye_N, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f,7));
        StartCoroutine(SummonEnemy(5f, 5, Eye_N, CEnemy.AI.No_2_L, CEnemy.StartPosition.L4, 0.3f,7));
        StartCoroutine(SummonEnemy(5f, 5, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(7f, 5, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(8f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(9f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));

        StartCoroutine(SummonEnemy(10f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(11f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T3, 0.2f,7));
        StartCoroutine(SummonEnemy(12f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T5, 0.2f,7));
        StartCoroutine(SummonEnemy(13f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T7, 0.2f,7));
        StartCoroutine(SummonEnemy(14f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.TR, 0.2f,7));
		StartCoroutine(SummonEnemy(15f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(16f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(17f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(18f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.TL, 0.2f,7));

		StartCoroutine(SummonEnemy(20f, 1, ChampShooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,9));


		StartCoroutine(SummonEnemy(20f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(20f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));

		StartCoroutine(SummonEnemy(21.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(21.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));

		StartCoroutine(SummonEnemy(23f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(23f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));

		StartCoroutine(SummonEnemy(24.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T7, 0.2f));
		StartCoroutine(SummonEnemy(24.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.TR, 0.2f));
       
		StartCoroutine(SummonEnemy(26f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
		StartCoroutine(SummonEnemy(26f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.2f));

		StartCoroutine(SummonEnemy(27.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
		StartCoroutine(SummonEnemy(27.5f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));

		StartCoroutine(SummonEnemy(29f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.TL, 0.2f));
		StartCoroutine(SummonEnemy(29f, 1, Bird_N, CEnemy.AI.Do, CEnemy.StartPosition.T1, 0.2f));

		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T1, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T2, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T3, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T4, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T5, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T6, 1.2f,7));
		StartCoroutine(SummonEnemy(30f, 8, Eye_N, CEnemy.AI.Do, CEnemy.StartPosition.T7, 1.2f,7));

		StartCoroutine(SummonEnemy(31f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(32f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(33f, 5, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));


		StartCoroutine(SummonEnemy(35f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(36f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(37f, 5, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));

		StartCoroutine(SummonEnemy(40f, 1, ChampBat_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.2f,8));


        StartCoroutine(SummonEnemy(40.5f, 9, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T1,1f));
		StartCoroutine(SummonEnemy(40.5f, 9, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T2,1f));
		StartCoroutine(SummonEnemy(40.5f, 9, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T3,1f));

		StartCoroutine(SummonEnemy(41f, 8, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T5,1f));
		StartCoroutine(SummonEnemy(41f, 8, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T6,1f));
		StartCoroutine(SummonEnemy(41f, 8, Bat_N, CEnemy.AI.Go, CEnemy.StartPosition.T7,1f));

		StartCoroutine(SummonEnemy(51f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(52f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(53f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(54f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(55f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(56f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(57f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));

		StartCoroutine(SummonEnemy(60f, 1, ChampBird_N, CEnemy.AI.Fo_Long, CEnemy.StartPosition.T4, 0.2f,8));

		StartCoroutine(SummonEnemy(61f, 3, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 2.5f,4));
		StartCoroutine(SummonEnemy(61f, 3, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 2.5f,4));
		StartCoroutine(SummonEnemy(61.5f, 3, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 2.5f,4));
		StartCoroutine(SummonEnemy(61.5f, 3, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 2.5f,4));

		StartCoroutine(SummonEnemy(71f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(72f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(73f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(74f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f,7));
		StartCoroutine(SummonEnemy(75f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(76f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(77f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));

        StartCoroutine(SummonEnemy(92f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.1f,7));
        StartCoroutine(SummonEnemy(92f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L2, 0.1f,7));
        StartCoroutine(SummonEnemy(92f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L3, 0.1f,7));
        StartCoroutine(SummonEnemy(94f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R3, 0.1f,7));
        StartCoroutine(SummonEnemy(94f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R4, 0.1f,7));
        StartCoroutine(SummonEnemy(94f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R5, 0.1f,7));

		StartCoroutine(SummonEnemy(96f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L3, 0.1f,7));
		StartCoroutine(SummonEnemy(96f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L4, 0.1f,7));
		StartCoroutine(SummonEnemy(96f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L5, 0.1f,7));
		StartCoroutine(SummonEnemy(98f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.1f,7));
		StartCoroutine(SummonEnemy(98f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R2, 0.1f,7));
		StartCoroutine(SummonEnemy(98f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R3, 0.1f,7));

		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L3, 0.1f,7));
		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L4, 0.1f,7));
		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L5, 0.1f,7));
		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R3, 0.1f,7));
		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R4, 0.1f,7));
		StartCoroutine(SummonEnemy(100f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R5, 0.1f,7));


        StartCoroutine(SummonEnemy(103f, 1, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L1, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(103f, 1, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L3, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(103f, 1, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R1, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(103f, 1, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R3, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(105f, 1, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L2, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(105f, 1, Shooter_N, CEnemy.AI.Sho_R, CEnemy.StartPosition.L4, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(105f, 1, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R2, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(105f, 1, Shooter_N, CEnemy.AI.Sho_L, CEnemy.StartPosition.R4, 0.5f, 1)); //sho

        StartCoroutine(ClearEnemy(110f));
    }
}
