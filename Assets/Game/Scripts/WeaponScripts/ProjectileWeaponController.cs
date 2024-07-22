using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeaponController : MonoBehaviour
{
    public static ProjectileWeaponController Instance { get; private set; }

    [NonSerialized] public float damage = 30;
    [NonSerialized] public float range;
    [NonSerialized] public float fireRate = 1.5f;
    [NonSerialized] public float projectileSpeed;
    [NonSerialized] public float nextFireTime;

    public GameObject parentObject;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    protected void PlayFireSound()
    {
        // Play fire sound 
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    public void Fire()
    {
        nextFireTime = Time.time + 1f / fireRate;
        PlayFireSound();

        // Determine the direction based on the player's facing direction
        Vector3 direction = playerMovement.lastHorizontalVector > 0 ? Vector3.right : Vector3.left;


        // ProjectileSkill.Instance.isClicked control
        if (ProjectileSkill.Instance.isClicked == true)
        {
            // If the player received the ability that increases the first projectile, two projectiles will be thrown.
            GameObject projectile1 = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, -0.2f, 0), Quaternion.identity, parentObject.transform);
            GameObject projectile2 = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 0.2f, 0), Quaternion.identity, parentObject.transform);

            // Access and initialize the Projectile script for both projectiles
            Projectile projScript1 = projectile1.GetComponent<Projectile>();
            projScript1.Initialize(direction);
            float projectileSpeed1 = projScript1.speed;

            Projectile projScript2 = projectile2.GetComponent<Projectile>();
            projScript2.Initialize(direction);
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, parentObject.transform);

            Projectile projScript = projectile.GetComponent<Projectile>();
            projScript.Initialize(direction);

            float projectileSpeed = projScript.speed;
        }

    }
}
