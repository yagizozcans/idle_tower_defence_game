using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeExplosion : MonoBehaviour
{
    LineRenderer lr;

    public float explosionTime;

    float timer;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        SetSpikes(2);
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

    public void SetSpikes(float size)
    {
        LineRenderer parentLR = gameObject.transform.parent.GetComponent<LineRenderer>();

        lr.positionCount = parentLR.positionCount * 2;

        for(int i = 0; i < parentLR.positionCount * 2; i++)
        {
            if(i % 2 == 0)
            {
                lr.SetPosition(i, new Vector3(parentLR.GetPosition(i/2).x / size, parentLR.GetPosition(i/2).y / size, 0));
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
