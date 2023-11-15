using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRay : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("hey");
        if (collision.tag == "enemy")
        {
            collision.GetComponent<EnemyMain>().enemyGiveDamage(GeneralManager.instance.gameData.moAttack * Time.deltaTime * 10);
        }
    }
}
