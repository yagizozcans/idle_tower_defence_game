using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTurret : MonoBehaviour
{
    public float distance;
    public int count;
    public GameObject rotatingobj;

    public float turnSpeed;

    void Start()
    {
        CreateTris();
    }
    private void Update()
    {
        transform.eulerAngles += new Vector3(0,0,turnSpeed * Time.deltaTime);
    }
    public void CreateTris()
    {
        for (int i = 0; i < count; i++)
        {
            int angle = (360 / count) * i;
            GameObject newTri = Instantiate(rotatingobj.gameObject, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)),transform);
            newTri.transform.GetChild(0).transform.localPosition = Vector2.up * distance;
            newTri.name = $"tri{i}";
        }
    }
}
