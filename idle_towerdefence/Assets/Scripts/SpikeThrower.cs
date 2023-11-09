using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeThrower : MonoBehaviour
{
    float timer;
    public float throwTime;
    int counter = 1;
    public int graphParamater;

    private void Update()
    {
        if(GeneralManager.instance.gameData.stGraphParameterLevel != 0)
        {
            timer += Time.deltaTime;
            if (timer > GeneralManager.instance.stAttackSpeed[GeneralManager.instance.gameData.stAttackSpeedLevel])
            {
                CreateSpike(counter * (360 / GeneralManager.instance.stGraphParameter[GeneralManager.instance.gameData.stGraphParameterLevel]));
                counter++;
                timer = 0;
            }
        }
    }

    public void CreateSpike(int zRotation)
    {
        GameObject spike = Instantiate(GeneralManager.instance.triBullet, transform.position, Quaternion.Euler(0, 0, zRotation));
        spike.GetComponent<LineRenderer>().startColor = GeneralManager.instance.stColor[Random.Range(0, GeneralManager.instance.stColor.Length)];
        spike.GetComponent<LineRenderer>().endColor = GeneralManager.instance.stColor[Random.Range(0, GeneralManager.instance.stColor.Length)];
    }
}
