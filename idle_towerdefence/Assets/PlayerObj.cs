using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj instance;

    public GameObject closestEnemy;

    public float radius;

    float oldclosestDistance = 50;

    private void Start()
    {
        instance = this;

        AttackRangeLRUpdate();
    }

    private void Update()
    {
        CheckClosestEnemy();
    }

    void CheckClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - enemies[i].transform.position.x,2) + Mathf.Pow(transform.position.y - enemies[i].transform.position.y,2));
            oldclosestDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x - closestEnemy.transform.position.x, 2) + Mathf.Pow(transform.position.y - closestEnemy.transform.position.y, 2));
            if (distance < radius / 2 && distance < oldclosestDistance)
            {
                closestEnemy = enemies[i];
                oldclosestDistance = distance;
                Debug.Log(oldclosestDistance);
                Debug.Log(closestEnemy);
            }
        }

        if(transform.GetChild(1).childCount != 0 && closestEnemy != null)
        {
            TurnFaceToObj[] turrets = transform.GetChild(1).GetComponentsInChildren<TurnFaceToObj>();

            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].target = closestEnemy.transform;
            }
        }
    }

    void AttackRangeLRUpdate()
    {
        transform.GetChild(0).GetComponent<DrawLRObjs>().DrawObjLooped(16, radius);
    }
}
