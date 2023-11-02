using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurret : MonoBehaviour
{
    Vector2 firstPos;
    Vector2 backPos;

    public float recoilSpeed;

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
            transform.position = Vector2.Lerp(transform.position, backPos, recoilSpeed);
            if((Vector2)transform.position == backPos)
            {
                isAttacking = !isAttacking;
            }
        }
        if(!isAttacking)
        {
            transform.position = Vector2.Lerp(transform.position, firstPos, recoilSpeed);
            if ((Vector2)transform.position == firstPos)
            {
                AttackBullet();
                isAttacking = !isAttacking;
            }
        }
    }

    void AttackBullet()
    {
        Instantiate(GeneralManager.instance.circleBullet, transform.parent.GetChild(2).transform.position, this.transform.rotation);
    }
}
