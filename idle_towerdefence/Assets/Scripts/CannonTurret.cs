using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurret : MonoBehaviour
{
    Vector2 firstPos;
    Vector2 backPos;
    bool isAttacking;
    void Start()
    {
        firstPos = transform.position;
    }

    private void Update()
    {
        backPos = transform.parent.GetChild(1).transform.position;
        if (isAttacking)
        {
            transform.position = Vector2.Lerp(transform.position, backPos, GeneralManager.instance.ntAttackTime[GeneralManager.instance.gameData.ntAttackTimeLevel]);
            if((Vector2)transform.position == backPos)
            {
                isAttacking = !isAttacking;
            }
        }
        if(!isAttacking)
        {
            transform.position = Vector2.Lerp(transform.position, firstPos, GeneralManager.instance.ntAttackTime[GeneralManager.instance.gameData.ntAttackTimeLevel]);
            if ((Vector2)transform.position == firstPos)
            {
                if(transform.parent.GetComponent<TurnFaceToObj>().target != null)
                {
                    AttackBullet();
                }
                isAttacking = !isAttacking;
            }
        }
    }

    void AttackBullet()
    {
        GameObject circle = Instantiate(GeneralManager.instance.circleBullet, transform.parent.GetChild(2).transform.position, this.transform.rotation);
        circle.GetComponent<CircleCollider2D>().radius = circle.GetComponent<DrawLRObjs>().radius;
    }
}
