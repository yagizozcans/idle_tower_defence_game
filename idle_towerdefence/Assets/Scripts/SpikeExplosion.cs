using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeExplosion : MonoBehaviour
{
    LineRenderer lr;

    public float rotateSpeed;

    public void SetSpikeExplosion()
    {
        StopAllCoroutines();
        lr = GetComponent<LineRenderer>();
        SetSpikes();
        StartCoroutine(CreateSpikeExplosion(GeneralManager.instance.seExplosionTime[GeneralManager.instance.gameData.seExplosionTimeLevel]));
    }

    private void Update()
    {
        transform.eulerAngles += Vector3.forward * Time.deltaTime * rotateSpeed;
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
        for (int i = 0; i < lr.positionCount / 2; i++)
        {
            GameObject tri = Instantiate(GeneralManager.instance.triBullet, transform.position, Quaternion.Euler(0, 0, ((360 / lr.positionCount * 2) * i) + transform.eulerAngles.z));
        }
        yield return new WaitForSeconds(timer);
        StartCoroutine(CreateSpikeExplosion(timer));
        yield return null;
    }
}
