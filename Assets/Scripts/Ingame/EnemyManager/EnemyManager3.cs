using UnityEngine;
using System.Collections;

public class EnemyManager3 : CEnemyManager
{
	EnemyStatus Bird_A = new EnemyStatus(Enemy.Bird_A, 3000f, 10f, 10000f, 400f, 2, 1);
	EnemyStatus ChampBird_A = new EnemyStatus(Enemy.ChampBird_A, 30f, 8000f, 100f, 400f, 20, 500);
	
	public override void ManageStage()
	{
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TL, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TR, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TL, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br1, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br2, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br3, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br5, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.Br6, 1f));
		StartCoroutine(SummonEnemy(2f, 1, Bird_A, CEnemy.AI.Do, CEnemy.StartPosition.TR, 1f));

		StartCoroutine(ClearEnemy(105f));
	}
}
