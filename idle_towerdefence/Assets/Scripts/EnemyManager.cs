using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawnRate;
    void Update()
    {
        EnemyRain(GeneralManager.instance.enemy1);

    }
    private void Start()
    {
        //StartCoroutine(InstantiateEnemy(GeneralManager.instance.enemy1));
    }

    //enemy rain
    IEnumerator InstantiateEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(spawnRate);
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
        StartCoroutine(InstantiateEnemy(GeneralManager.instance.enemy1));
    }
    void EnemyRain(GameObject enemy)
    {
        float xAxis = Random.Range(2f, 5f);
        float yAxis = Random.Range(3f, 5f);
        float angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
    }
}
