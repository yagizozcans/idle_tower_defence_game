using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float lifeTime;
    public float maxSpeed;
    float speed;
    Color color;
    void Start()
    {
        speed = Random.Range(1f, maxSpeed);
        color = GetComponent<LineRenderer>().startColor;
        Destroy(gameObject, lifeTime+Time.deltaTime);
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        color.a -= (1/lifeTime) * Time.deltaTime;
        GetComponent<LineRenderer>().startColor = color;
        GetComponent<LineRenderer>().endColor = color;
    }
}
