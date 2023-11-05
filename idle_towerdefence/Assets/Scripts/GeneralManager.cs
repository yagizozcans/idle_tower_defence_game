using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;

    //Middle Object Auto Attack
    public float[] moAttackSpeed;
    public bool moActive;

    //Spike Explosion
    public int[] seCount;
    public int[] seExplosionTime;
    public bool seActive;

    //Turning Circles
    public float[] tcTurnSpeed;
    public int[] tcCount;
    public float[] tcRespawnTime;
    public bool tcActive;

    //Triangle Turrets
    public float[] ttTurnSpeed;
    public int[] ttCount;
    public bool ttActive;

    //Normal Turret
    public float[] ntRotateSpeed;
    public int[] ntCount;
    public float[] ntAttackTime;
    public bool ntActive;

    //Spike Thrower
    public float[] stAttackSpeed;
    public int[] stGraphParameter;
    public Color[] stColor;
    public bool stActive;

    private void Start()
    {
        instance = this;
    }

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
        GameData data = new GameData();
    }
}
