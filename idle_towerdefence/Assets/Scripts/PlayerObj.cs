using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj instance;

    public GameObject closestEnemy;
    public GameObject closestEnemyOriginal;

    public float radius;

    public float oldclosestDistance = 50;

    public float attackSpeed;
    float timer;
    bool outofsight;

    private void Start()
    {
        instance = this;

        AttackRangeLRUpdate();
    }

    private void Update()
    {
        CheckClosestEnemy();
        timer += Time.deltaTime;
    }

    void CheckClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - enemies[i].transform.position.x, 2) + Mathf.Pow(transform.position.y - enemies[i].transform.position.y, 2));
            oldclosestDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x - closestEnemy.transform.position.x, 2) + Mathf.Pow(transform.position.y - closestEnemy.transform.position.y, 2));
            if (distance < oldclosestDistance)
            {
                closestEnemy = enemies[i];
                oldclosestDistance = distance;
            }
        }

        if (radius/2 < oldclosestDistance)
        {
            outofsight = true;
        }
        else
        {
            outofsight = false;
        }

        if (timer > attackSpeed && !outofsight)
        {
            if(oldclosestDistance < radius/2)
            {
                AttackMainObj();
            }
            timer = 0;
        }
    }

    void AttackRangeLRUpdate()
    {
        transform.GetChild(0).GetComponent<DrawLRObjs>().DrawObjLooped(16, radius);
    }

    void AttackMainObj()
    {
        float angle = Mathf.Atan2(transform.position.y - closestEnemy.transform.position.y, transform.position.x - closestEnemy.transform.position.x) * Mathf.Rad2Deg + 90;
        GameObject cBullet = Instantiate(GeneralManager.instance.circleBullet, transform.position, Quaternion.Euler(0,0,angle));
        cBullet.GetComponent<TriBullet>().movementSpeed = 16;
        cBullet.GetComponent<CircleCollider2D>().radius = cBullet.GetComponent<DrawLRObjs>().radius;
    }
}
