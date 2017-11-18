using UnityEngine;
using System.Collections;

public class CBoss : MonoBehaviour
{
    public string name;
    public float intro_time;
    public float HP;
    public float max_HP;
    public float ATK;
    public float DEF;
    public Attribute attribute;

    public void SetBossInfo(string name_, Attribute attribute_, float max_HP_, float DEF_)
    {
        name = string.Copy(name_);
        attribute = attribute_;
        max_HP = max_HP_;
        DEF = DEF_;
        ApplyStageLevel();
    }

    public void ApplyStageLevel()
    {
        if (StageManager.InfinityModeCount == 0)
        {
            return;
        }
        else
        {
            max_HP *= (1+(0.3f * StageManager.InfinityModeCount));
        }
    }

    public void DropCoin()
    {
        int amount = StageManager.max_coin/20;
        StageManager.currnet_coin += amount;
        for (int i = 0; i < amount; i++)
            Instantiate(ResourceLoad.PickGameObject("item_coin"), gameObject.transform.position, Quaternion.identity);
    }

    public void DropItem()
    {
        for (int i = 0; i < 4; i++)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    Instantiate(ResourceLoad.PickGameObject("item_mana"), gameObject.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(ResourceLoad.PickGameObject("item_heal"), gameObject.transform.position, Quaternion.identity);
                    break;
			case 2 :
				break;

            }
        }
    }

    public IEnumerator Kiraring()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.06f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void BossDeadMotion()
    {
        GameObject effect;
        effect = new GameObject();
        effect.transform.position = gameObject.transform.position;
        effect.AddComponent<Boss_Boom>();
    }
}
