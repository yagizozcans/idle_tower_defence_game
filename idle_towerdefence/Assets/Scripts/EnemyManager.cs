using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    void Update()
    {
        //InstantiateEnemy(GeneralManager.instance.enemy1);
        EnemyRain(GeneralManager.instance.enemy1);
    }

    //enemy rain
    void EnemyRain(GameObject enemy)
    {
        float xAxis = Random.Range(1f, 5f);
        float yAxis = Random.Range(1f, 5f);
        float angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
        xAxis = Random.Range(-5f, -1f);
        yAxis = Random.Range(-1f, 5f);
        angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
    }
    void InstantiateEnemy(GameObject enemy)
    {
        float xAxis = Random.Range(1f, 5f);
        float yAxis = Random.Range(1f, 5f);
        float angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
    }
}
