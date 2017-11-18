using UnityEngine;
using System.Collections;

public class bullet_enemy_homing : CBullet
{
    float max_rotate; // 최대 회전각
    GameObject closest; // 선택된 타겟
    float sensitivity;
    bool targeting_count;

    // Use this for initialization
    void Start()
    {
        tag = "bullet_enemy";
        max_rotate = 60f;
        sensitivity = 2f;
        closest = null;
        targeting_count = false;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        closest = null;
        targeting_count = false;
    }

    public override void Move()
    {
        if (!targeting_count && closest == null)
        {
            closest = GameObject.Find("player");
            if (closest != null)
                targeting_count = true;
        }

        float angle_to_rotate; //degree
        float angle_in_world; //degree, 불렛을 기준으로 타겟의 각도 , x축 0도
        float my_rotation; //degree, 불렛의 회전 정도, x축 0도
        Vector3 pos_diff; //타겟과 불렛의 벡터 차

        if (closest != null)
        {
            pos_diff = closest.transform.position - gameObject.transform.position;
            my_rotation = transform.localEulerAngles.z;

            angle_in_world = Mathf.Atan(Mathf.Abs(pos_diff.y) / Mathf.Abs(pos_diff.x)) * Mathf.Rad2Deg;
            if (pos_diff.y >= 0)
            {
                if (pos_diff.x <= 0)
                    angle_in_world = 180f - angle_in_world;
            }
            else
            {
                if (pos_diff.x >= 0)
                    angle_in_world = 360f - angle_in_world;
                else
                    angle_in_world += 180f;
            }

            angle_to_rotate = angle_in_world - my_rotation - 90f;
            if (angle_to_rotate > 180f)
                angle_to_rotate -= 360f;
            if (angle_to_rotate < -180f)
                angle_to_rotate += 360f;

            if (max_rotate <= angle_to_rotate)
                gameObject.transform.Rotate(0, 0, max_rotate * Time.deltaTime * sensitivity, Space.Self);
            else if (-max_rotate >= angle_to_rotate)
                gameObject.transform.Rotate(0, 0, -max_rotate * Time.deltaTime * sensitivity, Space.Self);
            else
                gameObject.transform.Rotate(0, 0, angle_to_rotate * Time.deltaTime * sensitivity, Space.Self);
        }

        this.moved_pos.y = bullet_SPD * Time.deltaTime;
        this.transform.Translate(this.moved_pos, Space.Self);

        if (transform.position.y > 800f || transform.position.x > 800f || transform.position.y < -800f || transform.position.x < -800f)
        {
            bullet_phase = BulletPhase.MISS;
        }
    }
}
