using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public static PlayerObj instance;

    public GameObject closestEnemy;
    public GameObject closestEnemyOriginal;

    public float radius;

    public float oldclosestDistance = 50;

    public float attackSpeed;
    public bool autoAttack;
    float timer;
    bool outofsight;

    public bool isDead = false;

    private void Start()
    {
        instance = this;
        PlayerPrefs.SetInt("checkpoint", 0);
        GeneralManager.instance.currentHP = GeneralManager.instance.gameData.moHealth;
        GetComponent<CircleCollider2D>().radius = GetComponent<DrawLRObjs>().radius;
        AttackRangeLRUpdate();
    }

    private void Update()
    {
        CheckClosestEnemy();
        timer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && !outofsight)
        {
            AttackMainObj(transform.position);
        }
        if(isDead)
        {
            transform.localScale = Vector3.Slerp(transform.localScale, Vector3.zero, 0.2f);
        }
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, Vector3.one * 0.5f, 0.2f);
        }
    }

    void CheckClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if(closestEnemy == null)
            {
                closestEnemy = enemies[i];
            }
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - enemies[i].transform.position.x, 2) + Mathf.Pow(transform.position.y - enemies[i].transform.position.y, 2));
            oldclosestDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x - closestEnemy.transform.position.x, 2) + Mathf.Pow(transform.position.y - closestEnemy.transform.position.y, 2));
            if (distance < oldclosestDistance)
            {
                closestEnemy = enemies[i];
                oldclosestDistance = distance;
            }
        }

        if (radius/2 < oldclosestDistance)
        {
            outofsight = true;
        }
        else
        {
            outofsight = false;
        }

        if (timer > GeneralManager.instance.gameData.moBaseAttackSpeed && !outofsight && autoAttack)
        {
            if(oldclosestDistance < radius/2)
            {
                AttackMainObj(transform.position);
            }
            timer = 0;
        }
    }

    void AttackRangeLRUpdate()
    {
        transform.GetChild(0).GetComponent<DrawLRObjs>().DrawObjLooped(16, radius);
    }

    public GameObject AttackMainObj(Vector3 position)
    {
        float angle = Mathf.Atan2(position.y - closestEnemy.transform.position.y, position.x - closestEnemy.transform.position.x) * Mathf.Rad2Deg + 90;
        GameObject cBullet = Instantiate(GeneralManager.instance.circleBullet, position, Quaternion.Euler(0,0,angle));
        cBullet.GetComponent<TriBullet>().movementSpeed = 16;
        cBullet.GetComponent<CircleCollider2D>().radius = cBullet.GetComponent<DrawLRObjs>().radius;
        return cBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            GeneralManager.instance.currentHP -= collision.GetComponent<EnemyMain>().thisBaseParameters.baseCost * Mathf.Pow(collision.GetComponent<EnemyMain>().collisionDamageParameters.growthRate, GeneralManager.instance.gameData.currentWave) * ((100-GeneralManager.instance.gameData.moDefence)/100);
            collision.GetComponent<EnemyMain>().health = 0;
            collision.GetComponent<EnemyMain>().collidedObj = transform.gameObject;
            collision.GetComponent<EnemyMain>().enemyGiveDamage(0f);
            BodyAttack();
            if(GeneralManager.instance.currentHP <= 0)
            {
                GeneralManager.instance.currentHP = GeneralManager.instance.gameData.moHealth;
                EnemyManager.instance.StopAllCoroutines();
                StartCoroutine(Death());
            }
        }
    }

    public void BodyAttack()
    {
        for(int i = 0; i < GeneralManager.instance.gameData.bodySpikeCount; i++)
        {
            Instantiate(GeneralManager.instance.bodyspike, transform.position, Quaternion.identity);
        }
    }

    public IEnumerator Death()
    {
        isDead = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        EnemyManager.instance.StopAllCoroutines();
        EnemyManager.instance.gameObject.SetActive(false);
        foreach(GameObject enemy in enemies)
        {
            for(int i = 0; i < 10; i++)
            {
                enemy.GetComponent<EnemyMain>().CreateParticle();
            }
            Destroy(enemy.gameObject);
        }
        yield return new WaitForSeconds(1f);
        isDead = false;
        yield return new WaitForSeconds(0.3f);
        if (GeneralManager.instance.gameData.currentWave >= 25)
        {
            PlayerPrefs.SetInt("checkpoint", GeneralManager.instance.gameData.currentWave / 25);
        }
        GeneralManager.instance.gameData.currentWave = PlayerPrefs.GetInt("checkpoint") * 25;
        EnemyManager.instance.gameObject.SetActive(true);
        EnemyManager.instance.StartLevel();
    }
}
