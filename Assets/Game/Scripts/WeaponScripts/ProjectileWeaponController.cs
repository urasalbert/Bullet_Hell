using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeaponController : MonoBehaviour
{
    public static ProjectileWeaponController Instance { get; private set; }

    [NonSerialized] public float damage;
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


        // Create the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, parentObject.transform);
        Projectile projScript = projectile.GetComponent<Projectile>();

        projScript.Initialize(direction);
        damage = projScript.damage;
        projectileSpeed = projScript.speed;
    }
}
