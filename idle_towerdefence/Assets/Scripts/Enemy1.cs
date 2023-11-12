using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float movSpeed;
    public float accelerationSpeed;
    public float maxMovSpeed;

    private void Start()
    {
        movSpeed = maxMovSpeed;
    }

    void Update()
    {
        movSpeed = Mathf.Clamp(movSpeed + accelerationSpeed * Time.deltaTime, -Mathf.Infinity, maxMovSpeed); 
        transform.position += -transform.right * movSpeed * Time.deltaTime;
    }
}
