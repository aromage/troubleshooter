using UnityEngine;
using System.Collections;

public class EnemyManager4 : CEnemyManager
{
	EnemyStatus Eye_N = new EnemyStatus(Enemy.Eye_N, 30f, 160f, 0f, 600f,0, 100);
	EnemyStatus BirdL_N = new EnemyStatus(Enemy.BirdL_N, 300f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus BirdChain_N = new EnemyStatus(Enemy.BirdChain_N, 300f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus ChampBird_N = new EnemyStatus(Enemy.ChampBird_N, 60f, 4000f, 10f, 400f, 0, 2000);
	EnemyStatus BirdR_N = new EnemyStatus(Enemy.BirdR_N, 300f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Bird_N = new EnemyStatus(Enemy.Bird_N, 30f, 40f, 10000f, 400f, 0, 500);
	EnemyStatus Shooter_N = new EnemyStatus(Enemy.Shooter_N, 40f, 500f, 0f, 350f, 0, 300);
	EnemyStatus ChampShooter_N = new EnemyStatus(Enemy.ChampShooter_N, 60f, 4000f, 10f, 300f, 5, 2000);
	EnemyStatus Bat_N = new EnemyStatus(Enemy.Bat_N, 40f, 350f, 0f, 800f, 0, 200);
	EnemyStatus ChampBat_N = new EnemyStatus(Enemy.ChampBat_N, 50f, 3000f, 10f, 800f, 0, 2000);
	EnemyStatus Gonyak_N = new EnemyStatus(Enemy.Gonyak_A, 300f, 40f, 10000f, 300f, 0, 500);

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
        StartCoroutine(SummonEnemy(12f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.TL, 0.2f,7));
        StartCoroutine(SummonEnemy(12f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(12f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
        StartCoroutine(SummonEnemy(14f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));
        StartCoroutine(SummonEnemy(14f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f,7));
        StartCoroutine(SummonEnemy(14f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(16f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T2, 0.2f,7));
        StartCoroutine(SummonEnemy(16f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f,7));
        StartCoroutine(SummonEnemy(16f, 2, Eye_N, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(18f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.TR, 0.2f,7));
        StartCoroutine(SummonEnemy(18f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f,7));
        StartCoroutine(SummonEnemy(18f, 2, Eye_N, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T6, 0.2f,7));


		StartCoroutine(SummonEnemy(2f, 1, Gonyak_N, CEnemy.AI.SlL, CEnemy.StartPosition.L2)); //wal
		StartCoroutine(SummonEnemy(22f, 1, Shooter_N, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(24f, 1, Gonyak_N, CEnemy.AI.SlR, CEnemy.StartPosition.R1)); //wal
		StartCoroutine(SummonEnemy(24f, 1, Shooter_N, CEnemy.AI.SlR, CEnemy.StartPosition.R2, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(26f, 1, Gonyak_N, CEnemy.AI.SlL, CEnemy.StartPosition.L2)); //wal
		StartCoroutine(SummonEnemy(26f, 1, Shooter_N, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(28f, 1, Gonyak_N, CEnemy.AI.SlR, CEnemy.StartPosition.R1)); //wal
		StartCoroutine(SummonEnemy(28f, 1, Shooter_N, CEnemy.AI.SlR, CEnemy.StartPosition.R2, 0.5f, 1)); //sho

		StartCoroutine(SummonEnemy(30f, 1, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T2, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(30f, 1, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 0.5f, 1)); //sho
		StartCoroutine(SummonEnemy(30f, 1, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T6, 0.5f, 1)); //sho


        StartCoroutine(SummonEnemy(32f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.TL)); //wal
		StartCoroutine(SummonEnemy(32f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br1)); //wal
		StartCoroutine(SummonEnemy(32f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br7)); //wal
		StartCoroutine(SummonEnemy(32f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.TR)); //wal

		StartCoroutine(SummonEnemy(34f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br2)); //wal
		StartCoroutine(SummonEnemy(34f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br3)); //wal
		StartCoroutine(SummonEnemy(34f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br5)); //wal
		StartCoroutine(SummonEnemy(34f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br6)); //wal

		StartCoroutine(SummonEnemy(36f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.TL)); //wal
		StartCoroutine(SummonEnemy(36f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br1)); //wal
		StartCoroutine(SummonEnemy(36f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br5)); //wal
		StartCoroutine(SummonEnemy(36f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br6)); //wal

		StartCoroutine(SummonEnemy(38f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br2)); //wal
		StartCoroutine(SummonEnemy(38f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br3)); //wal
		StartCoroutine(SummonEnemy(38f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br7)); //wal
		StartCoroutine(SummonEnemy(38f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.TR)); //wal

		StartCoroutine(SummonEnemy(40f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br2)); //wal
		StartCoroutine(SummonEnemy(40f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br3)); //wal
		StartCoroutine(SummonEnemy(40f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br5)); //wal
		StartCoroutine(SummonEnemy(40f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br6)); //wal

        StartCoroutine(SummonEnemy(41f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(42f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
        StartCoroutine(SummonEnemy(43f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
        StartCoroutine(SummonEnemy(44f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(45f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));


        StartCoroutine(SummonEnemy(47f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
        StartCoroutine(SummonEnemy(48f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f,7));
        StartCoroutine(SummonEnemy(49f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
        StartCoroutine(SummonEnemy(50f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
        StartCoroutine(SummonEnemy(51f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		
		StartCoroutine(SummonEnemy(52f, 1, Gonyak_N, CEnemy.AI.Fo, CEnemy.StartPosition.T2)); //wal
		StartCoroutine(SummonEnemy(52f, 1, Gonyak_N, CEnemy.AI.Fo, CEnemy.StartPosition.T6)); //wal
		StartCoroutine(SummonEnemy(53f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T1, 0.5f, 6)); //sho
		StartCoroutine(SummonEnemy(53f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T3, 0.5f, 6)); //sho
		StartCoroutine(SummonEnemy(53f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T5, 0.5f, 6)); //sho
		StartCoroutine(SummonEnemy(53f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T7, 0.5f, 6)); //sho
		StartCoroutine(SummonEnemy(54f, 1, Gonyak_N, CEnemy.AI.Fo, CEnemy.StartPosition.T2)); //wal
		StartCoroutine(SummonEnemy(54f, 1, Gonyak_N, CEnemy.AI.Fo, CEnemy.StartPosition.T6)); //wal

        StartCoroutine(SummonEnemy(61f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
        StartCoroutine(SummonEnemy(62f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
        StartCoroutine(SummonEnemy(63f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
        StartCoroutine(SummonEnemy(64f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
        StartCoroutine(SummonEnemy(65f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));

        StartCoroutine(SummonEnemy(67f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
        StartCoroutine(SummonEnemy(68f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
        StartCoroutine(SummonEnemy(69f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(70f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(71f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));

        StartCoroutine(SummonEnemy(73f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T2, 0.5f, 2)); //sho
        StartCoroutine(SummonEnemy(73f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T4, 0.5f, 2)); //sho
        StartCoroutine(SummonEnemy(73f, 1, Shooter_N, CEnemy.AI.Wat, CEnemy.StartPosition.T6, 0.5f, 2)); //sho


		StartCoroutine(SummonEnemy(74f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br2)); //wal
		StartCoroutine(SummonEnemy(74f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br3)); //wal
		StartCoroutine(SummonEnemy(74f, 1, BirdChain_N, CEnemy.AI.Do, CEnemy.StartPosition.Br5)); //wal
		StartCoroutine(SummonEnemy(74f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br6)); //wal
	
		StartCoroutine(SummonEnemy(76f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.TL)); //wal
		StartCoroutine(SummonEnemy(76f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br1)); //wal
		StartCoroutine(SummonEnemy(76f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br5)); //wal
		StartCoroutine(SummonEnemy(76f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br6)); //wal


		StartCoroutine(SummonEnemy(78f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.TL)); //wal
		StartCoroutine(SummonEnemy(78f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br1)); //wal
		StartCoroutine(SummonEnemy(78f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br7)); //wal
		StartCoroutine(SummonEnemy(78f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.TR)); //wal

		StartCoroutine(SummonEnemy(80f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br2)); //wal
		StartCoroutine(SummonEnemy(80f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.Br3)); //wal
		StartCoroutine(SummonEnemy(80f, 1, BirdL_N, CEnemy.AI.Do, CEnemy.StartPosition.Br7)); //wal
		StartCoroutine(SummonEnemy(80f, 1, BirdR_N, CEnemy.AI.Do, CEnemy.StartPosition.TR)); //wal

		//Accel
		StartCoroutine(SummonEnemy(92f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.2f,7));
        StartCoroutine(SummonEnemy(94f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.2f,7));
        StartCoroutine(SummonEnemy(96f, 3, Eye_N, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.2f,7));
        StartCoroutine(SummonEnemy(98f, 3, Eye_N, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.2f,7));
		
		StartCoroutine(SummonEnemy(101f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(102f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(103f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));
		StartCoroutine(SummonEnemy(104f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T1, 0.2f,7));
		StartCoroutine(SummonEnemy(105f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T2, 0.2f,7));

		StartCoroutine(SummonEnemy(107f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T3, 0.2f,7));
		StartCoroutine(SummonEnemy(108f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T4, 0.2f,7));
		StartCoroutine(SummonEnemy(109f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T5, 0.2f,7));
		StartCoroutine(SummonEnemy(110f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T6, 0.2f,7));
		StartCoroutine(SummonEnemy(111f, 5, Eye_N, CEnemy.AI.Go, CEnemy.StartPosition.T7, 0.2f,7));

		StartCoroutine(SummonEnemy(110f, 1, ChampShooter_N, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 0.5f, 1)); //sho
		StartCoroutine(AsClearBoss(110.1f));
    }
}
