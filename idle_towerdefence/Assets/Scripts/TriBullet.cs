using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour
{
    public float movementSpeed;

    private void Update()
    {
        transform.position += Time.deltaTime * transform.up * movementSpeed;
    }
}
