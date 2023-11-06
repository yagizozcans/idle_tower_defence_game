using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTurret : MonoBehaviour
{
    public float distance;

    void Start()
    {
        if(gameObject.name == "TurningCircle")
        {
            CreateTris(GeneralManager.instance.circleTurretObj,GeneralManager.instance.tcCount[GeneralManager.instance.gameData.tcCountLevel]);
        }
        if(gameObject.name == "xRayTurret")
        {
            CreateTris(GeneralManager.instance.xRayTurretObj, GeneralManager.instance.xrayCount[GeneralManager.instance.gameData.xrayCountLevel]);
        }
        if (gameObject.name == "TriTurret")
        {
            CreateTris(GeneralManager.instance.triTurretObj, GeneralManager.instance.ttCount[GeneralManager.instance.gameData.ttCountLevel]);
        }
    }
    private void Update()
    {
        if (gameObject.name == "TurningCircle")
        {
            transform.eulerAngles += new Vector3(0, 0, GeneralManager.instance.tcTurnSpeed[GeneralManager.instance.gameData.tcTurnSpeedLevel] * Time.deltaTime);
        }
        if (gameObject.name == "xRayTurret")
        {
            transform.eulerAngles += new Vector3(0, 0, GeneralManager.instance.xrayTurn[GeneralManager.instance.gameData.xrayTurnLevel] * Time.deltaTime);
        }
        if (gameObject.name == "TriTurret")
        {
            transform.eulerAngles += new Vector3(0, 0, GeneralManager.instance.ttTurnSpeed[GeneralManager.instance.gameData.ttTurnSpeedLevel] * Time.deltaTime);
        }
    }
    public void CreateTris(GameObject rotatingObj,int count)
    {
        for (int i = 0; i < count; i++)
        {
            int angle = (360 / count) * i;
            GameObject newTri = Instantiate(rotatingObj.gameObject, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)),transform);
            newTri.transform.GetChild(0).transform.localPosition = Vector2.up * distance;
            newTri.name = $"tri{i}";
        }
    }
}
