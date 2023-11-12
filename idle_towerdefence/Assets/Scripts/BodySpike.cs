using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpike : MonoBehaviour
{

    public float maxVelocity;

    Vector2 velocity;

    private void Start()
    {
        float angle = Random.Range(0, 180f);
        transform.GetComponent<CircleCollider2D>().radius = GetComponent<DrawLRObjs>().radius + GetComponent<DrawLRObjs>().lineWidth;
        velocity = new Vector2(maxVelocity * Mathf.Cos(angle * Mathf.PI / 180), maxVelocity * Mathf.Sin(angle * Mathf.PI / 180) * 1.5f);
    }

    private void Update()
    {
        velocity = new Vector2(velocity.x, velocity.y - (GeneralManager.instance.gravity * Time.deltaTime));
        transform.position = (Vector2)transform.position + velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            collision.GetComponent<EnemyMain>().enemyGiveDamage(5f);
            Destroy(gameObject);
        }
    }
}
