using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public bool isRespawning = false;
    public Color passiveColor;
    public Color activeColorStart;
    public Color activeColorEnd;
    public float respawnTime;
    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = GetComponent<DrawLRObjs>().radius + GetComponent<LineRenderer>().startWidth / 2;
    }

    public IEnumerator Respawn(float time)
    {
        if (!isRespawning)
        {
            isRespawning = true;
            GetComponent<LineRenderer>().startColor = passiveColor;
            GetComponent<LineRenderer>().endColor = passiveColor;
            GetComponent<TrailRenderer>().startColor = passiveColor;
            GetComponent<TrailRenderer>().endColor = passiveColor;
        }
        yield return new WaitForSeconds(time);
        isRespawning = false;
        GetComponent<LineRenderer>().startColor = activeColorStart;
        GetComponent<LineRenderer>().endColor = activeColorStart;
        GetComponent<TrailRenderer>().startColor = activeColorStart;
        GetComponent<TrailRenderer>().endColor = activeColorEnd;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            StartCoroutine(Respawn(respawnTime));
        }
    }
}
