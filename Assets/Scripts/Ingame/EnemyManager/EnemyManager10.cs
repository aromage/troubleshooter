using UnityEngine;
using System.Collections;

public class EnemyManager10 : CEnemyManager
{
    EnemyStatus Eye_A = new EnemyStatus(Enemy.Eye_A, 10f, 600f, 10f, 800f, 2, 500);
    EnemyStatus Wall2_A = new EnemyStatus(Enemy.Wall2_A, 100f, 40f, 10000f, 400f, 2, 1000);
    EnemyStatus Wall1_A = new EnemyStatus(Enemy.Wall1_A, 100f, 40f, 10000f, 400f, 2, 1000);
    EnemyStatus Shooter_A = new EnemyStatus(Enemy.Shooter_A, 10f, 2000f, 0f, 300f, 2, 2000);
    EnemyStatus Bat_A = new EnemyStatus(Enemy.Bat_A, 500f, 30f, 20f, 2000f, 2, 3000);

    public override void ManageStage()
    {
            StartCoroutine(SummonEnemy(2f, 5, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(3f, 5, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(5f, 5, Eye_A, CEnemy.AI.No_2_L, CEnemy.StartPosition.L4, 0.3f));
        StartCoroutine(SummonEnemy(5f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f));
        StartCoroutine(SummonEnemy(7f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f));
        StartCoroutine(SummonEnemy(8f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(9f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(12f, 5, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(13f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(15f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.2f));
        StartCoroutine(SummonEnemy(15f, 5, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(16f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T3, 0.2f));
        StartCoroutine(SummonEnemy(16f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(16f, 5, Eye_A, CEnemy.AI.No_2_R, CEnemy.StartPosition.R2, 0.3f));
        StartCoroutine(SummonEnemy(17f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(17f, 5, Eye_A, CEnemy.AI.No_2_L, CEnemy.StartPosition.L2, 0.3f));
        StartCoroutine(SummonEnemy(18f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(18f, 5, Eye_A, CEnemy.AI.No_2_R, CEnemy.StartPosition.R2, 0.3f));
        StartCoroutine(SummonEnemy(19f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(19f, 5, Eye_A, CEnemy.AI.No_2_L, CEnemy.StartPosition.L2, 0.3f));
        StartCoroutine(SummonEnemy(23f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(23f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(25f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(26f, 5, Eye_A, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.3f));
        StartCoroutine(SummonEnemy(26f, 5, Eye_A, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.3f));
        StartCoroutine(SummonEnemy(27f, 5, Eye_A, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.3f));
        StartCoroutine(SummonEnemy(27f, 5, Eye_A, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.3f));
        StartCoroutine(SummonEnemy(28f, 5, Eye_A, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.3f));
        StartCoroutine(SummonEnemy(28f, 5, Eye_A, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.3f));
        StartCoroutine(SummonEnemy(29f, 5, Eye_A, CEnemy.AI.SlL, CEnemy.StartPosition.L1, 0.3f));
        StartCoroutine(SummonEnemy(29f, 5, Eye_A, CEnemy.AI.SlR, CEnemy.StartPosition.R1, 0.3f));
        StartCoroutine(SummonEnemy(32f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1));
        StartCoroutine(SummonEnemy(32f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); 
        StartCoroutine(SummonEnemy(32f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3));
        StartCoroutine(SummonEnemy(32f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); 
        StartCoroutine(SummonEnemy(32f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5));
        StartCoroutine(SummonEnemy(32f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); 
        StartCoroutine(SummonEnemy(33f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1));
        StartCoroutine(SummonEnemy(33f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); 
        StartCoroutine(SummonEnemy(33f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3));
        StartCoroutine(SummonEnemy(33f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); 
        StartCoroutine(SummonEnemy(33f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5));
        StartCoroutine(SummonEnemy(33f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); 
        StartCoroutine(SummonEnemy(34f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1));
        StartCoroutine(SummonEnemy(34f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); 
        StartCoroutine(SummonEnemy(34f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3));
        StartCoroutine(SummonEnemy(34f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); 
        StartCoroutine(SummonEnemy(34f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5));
        StartCoroutine(SummonEnemy(34f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); 
        StartCoroutine(SummonEnemy(35f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); 
        StartCoroutine(SummonEnemy(35f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2));
        StartCoroutine(SummonEnemy(35f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa3)); 
        StartCoroutine(SummonEnemy(35f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa4));
        StartCoroutine(SummonEnemy(35f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa5)); 
        StartCoroutine(SummonEnemy(35f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa6));
        StartCoroutine(SummonEnemy(36f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1));
        StartCoroutine(SummonEnemy(36f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); 
        StartCoroutine(SummonEnemy(36f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3));
        StartCoroutine(SummonEnemy(36f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); 
        StartCoroutine(SummonEnemy(36f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5));
        StartCoroutine(SummonEnemy(36f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); 
        StartCoroutine(SummonEnemy(37f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); 
        StartCoroutine(SummonEnemy(37f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2));
        StartCoroutine(SummonEnemy(37f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5));
        StartCoroutine(SummonEnemy(37f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); 
        StartCoroutine(SummonEnemy(42f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(42f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(42f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(42f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(43f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5)); //wal
        StartCoroutine(SummonEnemy(43f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); //wal
        StartCoroutine(SummonEnemy(43f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa4)); //wal
        StartCoroutine(SummonEnemy(43f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(43f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(44f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(46f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(46f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(46f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(46f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(47f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5)); //wal
        StartCoroutine(SummonEnemy(47f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); //wal
        StartCoroutine(SummonEnemy(47f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa4)); //wal
        StartCoroutine(SummonEnemy(47f, 3, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T5, 0.2f));
        StartCoroutine(SummonEnemy(47f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(48f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(52f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(52f, 1, Bat_A, CEnemy.AI.RE_C, CEnemy.StartPosition.T4));
        StartCoroutine(SummonEnemy(52f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6));
        StartCoroutine(SummonEnemy(53f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T3, 0.2f));
        StartCoroutine(SummonEnemy(53f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T5, 0.2f)); 
        StartCoroutine(SummonEnemy(54f, 1, Wall1_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(54f, 1, Wall2_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(55f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(55f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(56f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(56f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(57f, 1, Wall2_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(57f, 1, Wall1_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(58f, 5, Eye_A, CEnemy.AI.No_1_L_Tu, CEnemy.StartPosition.T1, 0.2f));
        StartCoroutine(SummonEnemy(58f, 5, Eye_A, CEnemy.AI.No_1_R_Tu, CEnemy.StartPosition.T7, 0.2f));
        StartCoroutine(SummonEnemy(59f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f));
        StartCoroutine(SummonEnemy(62f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(62f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(62f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(63f, 3, Shooter_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.5f, 1));
        StartCoroutine(SummonEnemy(65f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa4)); //wal
        StartCoroutine(SummonEnemy(65f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa5)); //wal
        StartCoroutine(SummonEnemy(65f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa6)); //wal
        StartCoroutine(SummonEnemy(66f, 3, Shooter_A, CEnemy.AI.Do, CEnemy.StartPosition.T6, 0.5f, 1));
        StartCoroutine(SummonEnemy(67f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(67f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(67f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(69f, 3, Shooter_A, CEnemy.AI.Do, CEnemy.StartPosition.T2, 0.5f, 1)); //sho
        StartCoroutine(SummonEnemy(73f, 1, Wall1_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(73f, 1, Bat_A, CEnemy.AI.RE_R, CEnemy.StartPosition.T6));
        StartCoroutine(SummonEnemy(73f, 1, Bat_A, CEnemy.AI.RE_L, CEnemy.StartPosition.T2));
        StartCoroutine(SummonEnemy(74f, 1, Wall2_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL)); //wal
        StartCoroutine(SummonEnemy(74f, 1, Wall2_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(74f, 5, Eye_A, CEnemy.AI.Do, CEnemy.StartPosition.T4, 0.2f));
        StartCoroutine(SummonEnemy(75f, 3, Shooter_A, CEnemy.AI.SlL, CEnemy.StartPosition.TL, 0.5f, 1)); //sho
        StartCoroutine(SummonEnemy(75f, 1, Wall2_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR)); //wal
        StartCoroutine(SummonEnemy(76f, 3, Shooter_A, CEnemy.AI.SlR, CEnemy.StartPosition.TR, 0.5f, 1)); //sho
        StartCoroutine(SummonEnemy(77f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(77f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(77f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(78f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa5)); //wal
        StartCoroutine(SummonEnemy(78f, 1, Wall1_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa6)); //wal
        StartCoroutine(SummonEnemy(78f, 1, Wall2_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); //wal
        StartCoroutine(SummonEnemy(82f, 3, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.TL, 0.2f));
        StartCoroutine(SummonEnemy(82f, 3, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.TR, 0.2f));
        StartCoroutine(SummonEnemy(83f, 3, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.TL, 0.2f));
        StartCoroutine(SummonEnemy(83f, 3, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.TR, 0.2f));
        StartCoroutine(SummonEnemy(84f, 3, Eye_A, CEnemy.AI.No_1_L_St, CEnemy.StartPosition.TL, 0.2f));
        StartCoroutine(SummonEnemy(84f, 3, Eye_A, CEnemy.AI.No_1_R_St, CEnemy.StartPosition.TR, 0.2f));
        StartCoroutine(SummonEnemy(85f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa1)); //wal
        StartCoroutine(SummonEnemy(85f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa2)); //wal
        StartCoroutine(SummonEnemy(85f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa3)); //wal
        StartCoroutine(SummonEnemy(85f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa4)); //wal
        StartCoroutine(SummonEnemy(85f, 1, Wall2_A, CEnemy.AI.Do2, CEnemy.StartPosition.Wa5)); //wal
        StartCoroutine(SummonEnemy(85f, 1, Wall1_A, CEnemy.AI.Do, CEnemy.StartPosition.Wa6)); //wal

        StartCoroutine(ClearEnemy(93f));
	}
}