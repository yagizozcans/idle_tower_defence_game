using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public float health;
    public BaseParameters thisBaseParameters;
    public BaseParameters collisionDamageParameters;
    public float enemyCollisionDamage;
    public void enemyGiveDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            EnemyManager.instance.currentEnemyKills++;
            GeneralManager.instance.gameData.money += (int)(thisBaseParameters.baseCost * Mathf.Pow(thisBaseParameters.growthRate, GeneralManager.instance.gameData.currentWave * thisBaseParameters.growthRateForItself));
            Destroy(transform.gameObject);
        }
    }
}
