using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float movSpeed;

    void Update()
    {
        transform.position += -transform.right * movSpeed * Time.deltaTime;
    }
}
