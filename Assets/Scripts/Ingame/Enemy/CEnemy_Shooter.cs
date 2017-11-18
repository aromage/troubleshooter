using UnityEngine;
using System.Collections;

public partial class CEnemy : MonoBehaviour
{
    void SelectShooter(int shooter_num, int bullet_num)
    {
        switch (shooter_num)
        {
            case 0:
                    break;
                case 1:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 200f, this.ATK + 10f, State.NONE, 15f);
                    SetShooitngInfo(10, 10, 1, 4.5f, 4.5f, 50f);
                    break;
                case 2:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 200f, this.ATK + 20f, State.NONE, 15f);
                    SetShooitngInfo(8, 8, 1, 4f, 4f, 50f);
                    break;
                case 3:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 200f, this.ATK + 30f, State.NONE, 15f);
                    SetShooitngInfo(6, 6, 1, 3.5f, 3.5f, 50f);
                    break;
                case 4:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 200f, this.ATK + 0f, State.NONE, 15f);
                    SetShooitngInfo(4, 4, 1, 3f, 3f, 50f);
					StartAiming();
                    break;
                case 5:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 200f, this.ATK + 40f, State.NONE, 15f);
                    SetShooitngInfo(16, 4, 4, 4f, 1f, 70f);
                    break;
                case 6:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 800f, this.ATK + 20f, State.NONE, 15f);
                    SetShooitngInfo(3, 3, 1, 1f, 0.2f, 0f);
                    StartAiming();
                    break;
                case 7:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 400f, this.ATK + 0f, State.NONE, 15f);
                    SetShooitngInfo(1, 1, 1, 10f, 0.1f, 0f);
                    StartAiming();
                    break;
                case 8:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 500f, this.ATK + 10f, State.NONE, 15f);
                    SetShooitngInfo(8, 8, 3, 3f, 0.8f, 50f);
                    break;
				case 9:
                    SetBulletInfo(bullet_num, attribute, (HitType)0, 250f, this.ATK + 10f, State.NONE, 15f);
                    SetShooitngInfo(8, 8, 3, 3f, 0.8f, 50f);
                    break;		
				case 10:
					SetBulletInfo(bullet_num, attribute, (HitType)0, 250f, this.ATK + 10f, State.NONE, 15f);
					SetShooitngInfo(10, 1, 10, 2.5f, 0.15f, 50f);
					StartAiming();
					break;
				case 11:
					SetBulletInfo(bullet_num, attribute, (HitType)0, 300f, this.ATK + 10f, State.NONE, 15f);
					SetShooitngInfo(8, 8, 3, 3f, 0.8f, 50f);
					StartAiming();
			break;
				case 12:
					SetBulletInfo(bullet_num, attribute, (HitType)0, 800f, this.ATK + 20f, State.NONE, 15f);
					SetShooitngInfo(3, 3, 1, 1f, 0.2f, 0f);
					StartAiming();
			break;
        }
    }
}
