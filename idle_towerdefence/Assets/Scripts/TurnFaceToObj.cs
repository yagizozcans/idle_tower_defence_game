using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFaceToObj : MonoBehaviour
{
    public Transform target;

    public void FixedUpdate()
    {
        if(target != null)
        {
            float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, GeneralManager.instance.ntRotateSpeed[GeneralManager.instance.gameData.ntRotateSpeedLevel] * Time.deltaTime);
        }
    }
}
