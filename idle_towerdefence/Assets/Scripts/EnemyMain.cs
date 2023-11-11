using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public float health;

    public void enemyDeath()
    {
        if(health <= 0)
        {
            EnemyManager.instance.currentEnemyKills++;
            Destroy(transform.gameObject);
        }
    }
}
