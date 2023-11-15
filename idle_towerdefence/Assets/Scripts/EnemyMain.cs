using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public float health;
    public BaseParameters thisBaseParameters;
    public BaseParameters collisionDamageParameters;
    public float enemyCollisionDamage;
    public GameObject particle;
    public GameObject collidedObj;
    public void enemyGiveDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                CreateParticle();
            }
            EnemyManager.instance.currentEnemyKills++;
            if(collidedObj != PlayerObj.instance.gameObject)
            {
                GeneralManager.instance.gameData.money += (int)(thisBaseParameters.baseCost * Mathf.Pow(thisBaseParameters.growthRate, GeneralManager.instance.gameData.currentWave * thisBaseParameters.growthRateForItself));
            }
            Destroy(transform.gameObject);
        }
    }

    public void CreateParticle()
    {
        Instantiate(particle, transform.position, Quaternion.Euler(particle.transform.eulerAngles.x, particle.transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-45f,45f)));
    }
}
