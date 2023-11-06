using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeExplosion : MonoBehaviour
{
    LineRenderer lr;
    private void Start()
    {
        if(GeneralManager.instance.gameData.seActive)
        {
            lr = GetComponent<LineRenderer>();
            SetSpikes();
            CreateSpikeExplosion(GeneralManager.instance.seExplosionTime[GeneralManager.instance.gameData.seExplosionTimeLevel]);
        }
    }
    public void SetSpikes()
    {
        LineRenderer parentLR = gameObject.transform.parent.GetComponent<LineRenderer>();

        float size = parentLR.GetPosition(0).x;

        int spikeCount = GeneralManager.instance.seCount[GeneralManager.instance.gameData.seCountLevel];

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

    public IEnumerator CreateSpikeExplosion(float timer)
    {
        yield return new WaitForSeconds(timer);
        for(int i = 0; i < lr.positionCount/2; i++)
        {
            Instantiate(GeneralManager.instance.triBullet, transform.position, Quaternion.Euler(0, 0, (360 / lr.positionCount * 2) * i));
        }
        StartCoroutine(CreateSpikeExplosion(timer));
        yield return null;
    }
}
