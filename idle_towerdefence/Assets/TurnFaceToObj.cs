using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFaceToObj : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;

    public void FixedUpdate()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
