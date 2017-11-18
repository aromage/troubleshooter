using UnityEngine;
using System.Collections;

public class bullet_straingt_2 : CBullet {

    float boost;

    // Use this for initialization
    void Start()
    {
        tag = "bullet";
    }

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Speed());
    }

    public override void Move()
    {
        moved_pos.y = boost * bullet_SPD * Time.deltaTime;
        transform.Translate(moved_pos, Space.Self);
        if (transform.position.y > 650)
            bullet_phase = BulletPhase.MISS;
    }

    IEnumerator Speed()
    {
        boost = 0.1f;
        yield return new WaitForSeconds(0.5f);
        boost = 1f;
    }
}
