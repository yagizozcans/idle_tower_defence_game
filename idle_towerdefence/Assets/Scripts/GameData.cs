using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Middle Object Auto Attack
    public int moAttackSpeedLevel;
    public bool moActive;

    //Spike Explosion
    public int seCountLevel;
    public int seExplosionTimeLevel;
    public bool seActive;

    //Turning Circles
    public int tcTurnSpeedLevel;
    public int tcCountLevel;
    public int tcRespawnTimeLevel;
    public bool tcActive;


    //Triangle Turrets
    public int ttTurnSpeedLevel;
    public int ttCountLevel;
    public bool ttActive;


    //Normal Turret
    public int ntRotateSpeedLevel;
    public int ntCountLevel;
    public int ntAttackTimeLevel;
    public bool ntActive;

    //Xray Turret
    public int xrayCountLevel;
    public int xrayTurnLevel;
    public bool xrayActive;

    //Spike Thrower
    public int stAttackSpeedLevel;
    public int stGraphParameterLevel;
    public int stColorLevel;
    public bool stActive;

}
