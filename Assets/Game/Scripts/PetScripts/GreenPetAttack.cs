using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPetAttack : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public Transform firePoint;

    public GameObject projectilePrefab;
    private GameObject parentObject;

    private void Awake()
    {
        parentObject = GameObject.FindWithTag("Environment");
    }
    void Update()
    {
        if (Time.time > nextFireTime)
        {

            ShootProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootProjectile()
    {
        GameObject laser = Instantiate(projectilePrefab, firePoint.position,
            Quaternion.identity, parentObject.transform);
    }




}
