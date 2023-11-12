using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveParent : MonoBehaviour
{
    float tmr;
    private void Update()
    {
        tmr += Time.deltaTime;
        if(tmr > GeneralManager.instance.shockWaveBaseTimer - 0.02f * (GeneralManager.instance.gameData.shockWaveUpgradedLevel + 1))
        {
            Instantiate(GeneralManager.instance.shockWave, transform.position, Quaternion.identity);
            tmr = 0;
        }
    }
}
