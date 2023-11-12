using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public float scaleSize;

    public float lifetime;

    public float scaler;

    float alpha;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = GetComponent<DrawLRObjs>().radius;
        Destroy(gameObject, lifetime);
        alpha = GetComponent<LineRenderer>().startColor.a;
        scaler = GetComponent<LineRenderer>().startColor.a / lifetime;
    }

    public void Update()
    {
        transform.localScale += scaleSize * Time.deltaTime * Vector3.one;
        alpha -= scaler * Time.deltaTime;
        GetComponent<LineRenderer>().startColor = new Color(GetComponent<LineRenderer>().startColor.r, GetComponent<LineRenderer>().startColor.g, GetComponent<LineRenderer>().startColor.b,alpha);
        GetComponent<LineRenderer>().endColor = new Color(GetComponent<LineRenderer>().startColor.r, GetComponent<LineRenderer>().startColor.g, GetComponent<LineRenderer>().startColor.b,alpha);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            collision.GetComponent<Enemy1>().movSpeed = -2f;
        }
    }
}
