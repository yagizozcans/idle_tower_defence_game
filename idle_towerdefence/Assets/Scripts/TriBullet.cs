using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour
{
    public float movementSpeed;
    public LayerMask layer;
    public bool collideWithNew;

    private void Update()
    {
        transform.position += Time.deltaTime * transform.up * movementSpeed;
        if(collideWithNew)
        {
            GameObject obj = GeneralManager.instance.PhysicalRaycastCheck(movementSpeed, "enemy", this.transform, GetComponent<DrawLRObjs>().radius + transform.GetComponent<DrawLRObjs>().lineWidth * 2, layer);
            if (obj != null)
            {
                Destroy(obj);
                Destroy(gameObject);
            }
        }
    }

}
