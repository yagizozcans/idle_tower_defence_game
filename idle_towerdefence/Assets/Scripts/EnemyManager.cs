using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public float spawnRate;

    public int howManyEnemiesGonnaSpawn;
    public int currentSpawnedEnemies;
    public int currentEnemyKills;

    bool levelOnGoing;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(!levelOnGoing && enemies.Length == 0)
        {
            StartLevel();
        }

        if(Input.GetKeyDown(0))
        {
            SpawnEnemy(GeneralManager.instance.enemy1);
        }
    }

    //enemy rain
    IEnumerator InstantiateEnemy()
    {
        if(howManyEnemiesGonnaSpawn > currentSpawnedEnemies)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy(GeneralManager.instance.enemy1);
            currentSpawnedEnemies++;
            StartCoroutine(InstantiateEnemy());
            if (howManyEnemiesGonnaSpawn == currentSpawnedEnemies)
            {
                levelOnGoing = false;
            }
            yield return null;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        int i = Random.Range(0, 2);
        float xAxis = 0;
        float yAxis = 0;
        switch (i % 2)
        {
            case 0:
                i = Random.Range(0, 2);
                switch (i % 2)
                {
                    //left of screen
                    case 0:
                        xAxis = Random.Range(-10f, -7f);
                        yAxis = Random.Range(-9f, 9f);
                        break;
                    //down of screen
                    case 1:
                        xAxis = Random.Range(-9f, 0f);
                        yAxis = Random.Range(-6f, -5f);
                        break;
                }
                break;
            case 1:
                i = Random.Range(0, 2);
                switch (i % 2)
                {
                    //right of screen
                    case 0:
                        xAxis = Random.Range(0f, 1f);
                        yAxis = Random.Range(-9f, 9f);
                        break;
                    case 1:
                        //up of screen
                        xAxis = Random.Range(-9f, 0f);
                        yAxis = Random.Range(5f, 6f);
                        break;
                }
                break;
        }

        float angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
    }
    void EnemyRain(GameObject enemy)
    {
        float xAxis = Random.Range(2f, 5f);
        float yAxis = Random.Range(3f, 5f);
        float angle = Mathf.Atan2(yAxis - PlayerObj.instance.transform.position.y, xAxis - PlayerObj.instance.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Instantiate(enemy, new Vector2(xAxis, yAxis), targetRotation);
    }

    public void StartLevel()
    {
        levelOnGoing = true;
        currentSpawnedEnemies = 0;
        currentEnemyKills = 0;
        GeneralManager.instance.gameData.currentWave++;
        howManyEnemiesGonnaSpawn = GeneralManager.instance.gameData.currentWave;
        StartCoroutine(InstantiateEnemy());
    }
}
