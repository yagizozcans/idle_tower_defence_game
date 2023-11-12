using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyMain>().enemyGiveDamage(GeneralManager.instance.gameData.moAttack);
        }
    }
}
