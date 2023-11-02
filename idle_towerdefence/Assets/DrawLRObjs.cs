using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLRObjs : MonoBehaviour
{
    public LineRenderer lr;
    public int cornercount;
    public float radius;
    public float lineWidth;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        DrawObjLooped(cornercount, radius);
    }

    public void DrawObjLooped(int side, float radius)
    {
        lr.positionCount = side;
        float TAU = Mathf.PI * 2;
        for(int i = 0; i < side; i++)
        {
            float currentRadian = (float)i / side * TAU;

            float xPos = Mathf.Cos(currentRadian) * radius;
            float yPos = Mathf.Sin(currentRadian) * radius;
            Vector3 pos = new Vector3(xPos, yPos, 0);
            lr.SetPosition(i, pos);
        }
        lr.loop = true;
    }
}
