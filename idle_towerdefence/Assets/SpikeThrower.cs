using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeThrower : MonoBehaviour
{
    float timer;
    public float throwTime;
    int counter = 1;
    public int graphParamater;
    public Color color;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > throwTime)
        {
            CreateSpike(counter * (360 / graphParamater));
            counter++;
            timer = 0;
        }
    }

    public void CreateSpike(int zRotation)
    {
        GameObject spike = Instantiate(GeneralManager.instance.triBullet, transform.position, Quaternion.Euler(0, 0, zRotation));
        spike.GetComponent<LineRenderer>().startColor = color;
        spike.GetComponent<LineRenderer>().endColor = color;
    }
}
