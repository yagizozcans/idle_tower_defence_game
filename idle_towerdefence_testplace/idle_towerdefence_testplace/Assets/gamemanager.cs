using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text maint;

    public float costbase;
    public float rateGrowth;

    public float baseattack;
    public float ownedcount;
    public float attacktime;

    public void Calculate()
    {
        float dps = ownedcount * baseattack * (1/attacktime);
        maint.text = (costbase*Mathf.Pow(rateGrowth, dps)).ToString();
    }
}
