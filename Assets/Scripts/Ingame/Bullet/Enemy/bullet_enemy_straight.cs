using UnityEngine;
using System.Collections;

public class bullet_enemy_straight : CBullet
{
	// Use this for initialization
	void Start ()
    {
        tag = "bullet_enemy";
	}

	public override void Move(){
		moved_pos.y = - bullet_SPD * Time.deltaTime;
		transform.Translate(moved_pos,Space.Self);
		if (transform.position.y < -650)
            bullet_phase = BulletPhase.MISS;
	}
}
