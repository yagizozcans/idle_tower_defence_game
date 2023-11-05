using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeExplosion : MonoBehaviour
{
    LineRenderer lr;

    public float explosionTime;
    public int spikeCount;

    float timer;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        SetSpikes();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > explosionTime)
        {
            CreateSpikeExplosion();
            timer = 0;
        }
    }

    public void SetSpikes()
    {
        LineRenderer parentLR = gameObject.transform.parent.GetComponent<LineRenderer>();

        float size = parentLR.GetPosition(0).x;

        lr.positionCount = spikeCount * 2;

        for(int i = 0; i < spikeCount * 2; i++)
        {
            if(i % 2 == 0)
            {
                float degree = (360 / spikeCount) * (i/2+1);
                Debug.Log(degree);
                lr.SetPosition(i, new Vector3(size * Mathf.Sin(degree * Mathf.PI / 180) / 2, Mathf.Cos(degree * Mathf.PI / 180) / 2, 0));
            }
            else
            {
                lr.SetPosition(i, Vector3.zero);
            }
        }
    }

    public void CreateSpikeExplosion()
    {
        for(int i = 0; i < lr.positionCount/2; i++)
        {
            Instantiate(GeneralManager.instance.triBullet, transform.position, Quaternion.Euler(0, 0, (360 / lr.positionCount * 2) * i));
        }
    }
}
