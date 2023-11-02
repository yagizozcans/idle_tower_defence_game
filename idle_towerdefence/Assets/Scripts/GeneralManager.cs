using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;
    private void Start()
    {
        instance = this;
    }

    public GameObject triBullet;
    public GameObject circleBullet;
    public GameObject turret;
    public GameObject enemy1;
}
