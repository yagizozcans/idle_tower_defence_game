using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //Middle Object Auto Attack
    public int moAttackSpeedLevel;

    //Spike Explosion
    public int seCountLevel;
    public int seExplosionTimeLevel;

    //Turning Circles
    public int tcTurnSpeedLevel;
    public int tcCountLevel;
    public int tcRespawnTimeLevel;


    //Triangle Turrets
    public int ttTurnSpeedLevel;
    public int ttCountLevel;


    //Normal Turret
    public int ntRotateSpeedLevel;
    public int ntCountLevel;
    public int ntAttackTimeLevel;

    //Xray Turret
    public int xrayCountLevel;
    public int xrayTurnLevel;

    //Spike Thrower
    public int stAttackSpeedLevel;
    public int stGraphParameterLevel;
    public int stColorLevel;

    public int money;
    public float moAttack;
    public float moHealth;
    public float moDefence;
    public float moHealthUpgradedLevel;
    public float moDefenceUpgradedLevel;

}
