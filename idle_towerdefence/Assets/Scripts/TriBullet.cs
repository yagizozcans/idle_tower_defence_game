using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour
{
    public float movementSpeed;
    public LayerMask layer;
    public bool collideWithNew;
    public bool destroyAfterCollide;

    private void Update()
    {
        transform.position += Time.deltaTime * transform.up * movementSpeed;
        if(collideWithNew)
        {
            if(GetComponent<DrawLRObjs>() != null)
            {
                GameObject obj = GeneralManager.instance.PhysicalRaycastCheck(movementSpeed, "enemy", this.transform, GetComponent<DrawLRObjs>().radius + transform.GetComponent<DrawLRObjs>().lineWidth * 2, layer);
                if (obj != null)
                {
                    obj.GetComponent<EnemyMain>().enemyGiveDamage(GeneralManager.instance.gameData.moAttack);
                    if (destroyAfterCollide)
                    {
                        Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
            else
            {
                GameObject obj = GeneralManager.instance.PhysicalRaycastCheck(movementSpeed, "enemy", this.transform, 0.1f, layer);
                if (obj != null)
                {
                    obj.GetComponent<EnemyMain>().enemyGiveDamage(GeneralManager.instance.gameData.moAttack);
                    if (destroyAfterCollide)
                    {
                        Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
        }
    }
}
