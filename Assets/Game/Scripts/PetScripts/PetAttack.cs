using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAttack : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public Transform laserPoint;

    public GameObject laserPrefab;
    private GameObject parentObject;

    private void Awake()
    {
        parentObject = GameObject.FindWithTag("Environment");
    }
    void Update()
    {      
        if (Time.time > nextFireTime)
        {
            ShootLaser();
            
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootLaser()
    {       
        GameObject laser = Instantiate(laserPrefab, laserPoint.position, 
            Quaternion.Euler(0, 0, 90), parentObject.transform);
    }
}
