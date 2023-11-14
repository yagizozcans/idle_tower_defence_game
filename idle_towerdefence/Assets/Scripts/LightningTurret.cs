using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTurret : MonoBehaviour
{
    public float radius;

    bool attacked;

    private void Update()
    {
        if(PlayerObj.instance.closestEnemy != null && PlayerObj.instance.oldclosestDistance < radius/2)
        {
            attack();
        }
        else
        {
            GetComponent<LineRenderer>().positionCount = 0;
        }
    }

    void attack()
    {
        GetComponent<LineRenderer>().positionCount = 0;
        int pointCount = 5;
        GetComponent<LineRenderer>().positionCount = pointCount;
        float[] randomLengths = new float[pointCount];
        randomLengths[0] = 0;
        float totalLength = 0;
        for(int i = 1; i < randomLengths.Length; i++)
        {
            randomLengths[i] = Random.Range(0f, 0.05f);
            totalLength += randomLengths[i];
            randomLengths[i] += randomLengths[i - 1];
        }
        string s = "";
        for (int i = 1; i < randomLengths.Length; i++)
        {
            randomLengths[i] /= totalLength;
            s += $" {randomLengths[i]}";
        }

        Vector2 direction = PlayerObj.instance.closestEnemy.transform.position - transform.position;
        Vector2 directionInverse = new Vector2(-direction.y,direction.x);
        Debug.Log(directionInverse);
        Debug.Log(direction);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        for(int i = 1; i < randomLengths.Length; i++)
        {
            float randomValue = Random.Range(-0.05f, 0.05f);
            Vector2 mid = new Vector2(transform.position.x + direction.x * (randomLengths[i]) + directionInverse.x * randomValue, transform.position.y + direction.y * (randomLengths[i]) + directionInverse.y * randomValue);
            GetComponent<LineRenderer>().SetPosition(i, mid);
        }

        PlayerObj.instance.closestEnemy.GetComponent<EnemyMain>().enemyGiveDamage(5f * Time.deltaTime);
    }
}
