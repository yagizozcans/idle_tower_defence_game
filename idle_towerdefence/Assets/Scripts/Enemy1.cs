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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "turningcircle")
        {
            if(!collision.GetComponent<Circle>().isRespawning)
            {
                Destroy(gameObject);
            }
        }
    }
}
