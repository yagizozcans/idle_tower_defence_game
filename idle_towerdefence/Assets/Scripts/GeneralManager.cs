using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;

    public BaseParameters healthParameters;
    public BaseParameters attackParameters;
    public BaseParameters defenceParameters;
    public BaseParameters seCountParameters;
    public BaseParameters seAttackSpeedParameters;
    public BaseParameters ttCountParameters;
    public BaseParameters ttAttackSpeedParameters;
    public BaseParameters tcCountParameters;
    public BaseParameters ntCountParameters;
    public BaseParameters xrayCountParameters;
    public BaseParameters stGraphParameters;

    //Middle Object Auto Attack
    public float[] moAttackSpeed;

    //Spike Explosion
    public int[] seCount;
    public float[] seExplosionTime;

    //Turning Circles
    public float[] tcTurnSpeed;
    public int[] tcCount;
    public float[] tcRespawnTime;

    //Triangle Turrets
    public float[] ttTurnSpeed;
    public int[] ttCount;

    //Normal Turret
    public float[] ntRotateSpeed;
    public int[] ntCount;
    public float[] ntAttackTime;

    //Xray Turret
    public int[] xrayCount;
    public int[] xrayTurn;

    //Spike Thrower
    public float[] stAttackSpeed;
    public int[] stGraphParameter;
    public Color[] stColor;

    public GameData gameData;

    private void Start()
    {
        instance = this;
        LoadFromJson();
    }

    public GameObject turrets;
    public GameObject spikeExplosion;
    public GameObject spikeThrower;
    public GameObject turningCircles;
    public GameObject TriangleTurret;
    public GameObject XrayTurret;

    public GameObject xRayTurretObj;
    public GameObject triTurretObj;
    public GameObject circleTurretObj;


    public GameObject triBullet;
    public GameObject circleBullet;
    public GameObject turret;
    public GameObject enemy1;

    public GameObject PhysicalRaycastCheck(float movementSpeed,string tag,Transform whichobj, float radius, LayerMask layer)
    {
        Vector2 newPos = whichobj.transform.up * movementSpeed * Time.deltaTime + whichobj.transform.position;
        float distance = Mathf.Sqrt(
            Mathf.Pow(newPos.x - whichobj.transform.position.x, 2) + 
            Mathf.Pow(newPos.y - whichobj.transform.position.y, 2));
        Debug.DrawLine(whichobj.transform.position, newPos, Color.red);
        RaycastHit2D ray = Physics2D.CircleCast(whichobj.transform.position, radius, newPos - (Vector2)whichobj.transform.position, distance,layer);
        if(ray.collider != null && ray.transform.gameObject.tag == tag)
        {
            return ray.transform.gameObject;
        }
        return null;
    }

    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.dataPath + "/save.json", json);
    }
    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/save.json");
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
