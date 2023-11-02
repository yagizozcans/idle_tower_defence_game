using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public float radius;
    public float turretAttackTime;
    public float turretAttackTimeErrorPercentage;
    public float turretRotateSpeed;
    public int turretCount;
    public GameObject turret;

    // Update is called once per frame

    private void Start()
    {
        SpawnTurrets(turretCount);
    }

    private void FixedUpdate()
    {
        TurretFacing();
    }
    void SpawnTurrets(int turretsc)
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<CannonTurret>() != null)
            {
                Destroy(child.gameObject);
            }
        }

        for(int i = 0; i < Mathf.Clamp(turretsc,0, transform.GetChild(0).transform.childCount); i++)
        {
            GameObject nturret = Instantiate(turret, transform.GetChild(0).transform.GetChild(i).transform.position, Quaternion.identity,gameObject.transform);
            nturret.GetComponent<TurnFaceToObj>().rotateSpeed = turretRotateSpeed;
            nturret.GetComponentInChildren<CannonTurret>().recoilSpeed = 1/Random.Range(turretAttackTime - turretAttackTime / turretAttackTimeErrorPercentage, turretAttackTime + turretAttackTime / turretAttackTimeErrorPercentage);
        }
    }
    void TurretFacing()
    {
        if(radius / 2 > PlayerObj.instance.oldclosestDistance)
        {
            if (transform.childCount != 0 && PlayerObj.instance.closestEnemy != null)
            {
                TurnFaceToObj[] turrets = transform.GetComponentsInChildren<TurnFaceToObj>();

                for (int i = 0; i < turrets.Length; i++)
                {
                    turrets[i].target = PlayerObj.instance.closestEnemy.transform;
                }
            }
        }
        else
        {
            TurnFaceToObj[] turrets = transform.GetComponentsInChildren<TurnFaceToObj>();

            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].target = null;
            }
        }
    }
}
