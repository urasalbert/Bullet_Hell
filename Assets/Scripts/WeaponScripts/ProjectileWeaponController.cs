using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponController : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public float projectileSpeed;
    public float nextFireTime;

    public GameObject projectilePrefab;
    public Transform firePoint;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
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
        Vector3 direction = playerMovement.moveDirection.x > 0 ? Vector3.right : Vector3.left;
        

        // Create the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projScript = projectile.GetComponent<Projectile>();

        projScript.Initialize(direction);
        projScript.damage = damage;
        projScript.speed = projectileSpeed;
    }
}
