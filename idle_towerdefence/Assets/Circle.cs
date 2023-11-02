using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public bool isRespawning = false;
    public Color passiveColor;
    public Color activeColor;
    public float respawnTime;
    private void Start()
    {
        StartCoroutine(Respawn(respawnTime));
    }

    public IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        if(!isRespawning)
        {
            isRespawning = true;
            GetComponent<LineRenderer>().startColor = passiveColor;
            GetComponent<LineRenderer>().endColor = passiveColor;
            GetComponent<TrailRenderer>().startColor = passiveColor;
            GetComponent<TrailRenderer>().endColor = passiveColor;
        }
        else
        {
            isRespawning = false;
            GetComponent<LineRenderer>().startColor = activeColor;
            GetComponent<LineRenderer>().endColor = activeColor;
            GetComponent<TrailRenderer>().startColor = activeColor;
            GetComponent<TrailRenderer>().endColor = activeColor;
        }
        StartCoroutine(Respawn(respawnTime));
        yield return null;
    }
}
