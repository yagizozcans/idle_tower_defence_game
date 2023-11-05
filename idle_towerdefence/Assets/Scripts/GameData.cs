using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Middle Object Auto Attack
    public float moAttackSpeed;
    public bool moActive;

    //Spike Explosion
    public int seCount;
    public int seExplosionTime;
    public bool seActive;

    //Turning Circles
    public float tcTurnSpeed;
    public int tcCount;
    public float tcRespawnTime;
    public bool tcActive;


    //Triangle Turrets
    public float ttTurnSpeed;
    public int ttCount;
    public bool ttActive;


    //Normal Turret
    public float ntRotateSpeed;
    public int ntCount;
    public float ntAttackTime;
    public bool ntActive;


    //Spike Thrower
    public float stAttackSpeed;
    public int stGraphParameter;
    public Color stColor;
    public bool stActive;

}
