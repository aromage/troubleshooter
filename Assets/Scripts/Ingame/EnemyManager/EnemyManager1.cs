using UnityEngine;
using System.Collections;

public class EnemyManager1 : CEnemyManager
{
	EnemyStatus Shooter_F = new EnemyStatus(Enemy.Shooter_F, 100f, 400000f, 10000f, 350f, 0, 300);
	EnemyStatus ChampShooter_F = new EnemyStatus(Enemy.ChampShooter_F, 60f, 4000f, 100f, 300f, 10, 200000);
	EnemyStatus Shooter_A = new EnemyStatus(Enemy.Shooter_A, 100f, 400000f, 10000f, 350f, 0, 300);
	EnemyStatus ChampShooter_A = new EnemyStatus(Enemy.ChampShooter_A, 60f, 4000f, 100f, 300f, 10, 200000);
	EnemyStatus Shooter_N = new EnemyStatus(Enemy.Shooter_N, 100f, 400000f, 10000f, 350f, 0, 300);
	EnemyStatus ChampShooter_N = new EnemyStatus(Enemy.ChampShooter_N, 60f, 4000f, 100f, 300f, 10, 200000);

    public override void ManageStage()
    {
        StartCoroutine(SummonEnemy(2f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T1, 11f,10));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T3, 11f,10));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T5, 11f,10));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T7, 11f,10));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 11f,10));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_N, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.L1, 11f,11));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_F, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.L2, 11f,11));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_A, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.R1, 11f,11));
		StartCoroutine(SummonEnemy(2f, 2, Shooter_N, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.R2, 11f,11));

		StartCoroutine(SummonEnemy(24f, 1, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T1, 11f,11));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T3, 11f,11));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T5, 11f,11));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T7, 11f,11));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 11f,11));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_N, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.L1, 11f,12));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_F, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.L2, 11f,12));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_A, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.R1, 11f,12));
		StartCoroutine(SummonEnemy(24f, 1, Shooter_N, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.R2, 11f,12));

		StartCoroutine(SummonEnemy(35f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T1, 11f,12));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T3, 11f,12));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T5, 11f,12));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T7, 11f,12));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 11f,12));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_N, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L1, 11f,10));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_F, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L2, 11f,10));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_A, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R1, 11f,10));
		StartCoroutine(SummonEnemy(35f, 2, Shooter_N, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R2, 11f,10));

		StartCoroutine(SummonEnemy(57f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T1, 11f,12));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T3, 11f,12));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T5, 11f,12));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T7, 11f,12));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 11f,11));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_N, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L1, 11f,10));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_F, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L2, 11f,10));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_A, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R1, 11f,10));
		StartCoroutine(SummonEnemy(57f, 2, Shooter_N, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R2, 11f,10));

		StartCoroutine(SummonEnemy(92f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T1, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T3, 11f,12));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_N, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T5, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_F, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T7, 11f,12));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_A, CEnemy.AI.Wat_Long, CEnemy.StartPosition.T4, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_N, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L1, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_F, CEnemy.AI.Sho_R_Long, CEnemy.StartPosition.L2, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_A, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R1, 11f,10));
		StartCoroutine(SummonEnemy(92f, 2, Shooter_N, CEnemy.AI.Sho_L_Long, CEnemy.StartPosition.R2, 11f,10));

		StartCoroutine(SummonEnemy(112f, 1, ChampShooter_F, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 11f,8));
		StartCoroutine(SummonEnemy(114f, 1, ChampShooter_A, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 11f,8));
		StartCoroutine(SummonEnemy(116f, 1, ChampShooter_N, CEnemy.AI.C_SHO, CEnemy.StartPosition.T4, 11f,8));

        StartCoroutine(AsClearBoss(116.1f));
    }
}
