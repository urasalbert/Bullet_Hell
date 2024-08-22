using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPetAttack : MonoBehaviour
{
    public float fireRate;
    private float nextFireTime = 0f;

    public Transform firePoint;

    public GameObject projectilePrefab;
    public GameObject smallProjectilePrefab;
    public float projectileSpeed;
    public float splitTime = 5f;
    public float smallProjectileLifetime = 5f;

    private GameObject parentObject;
    private Vector3 direction;

    PlayerMovement playerMovement;

    private void Awake()
    {
        parentObject = GameObject.FindWithTag("Environment");
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (playerMovement.lastHorizontalVector > 0)
            {
                direction = Vector3.right; 
            }
            else
            {
                direction = Vector3.left; 
            }

            ShootProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootProjectile()
    {
        GameObject laser = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, parentObject.transform);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }

        StartCoroutine(SplitProjectile(laser));
    }

    IEnumerator SplitProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(splitTime);

        for (int i = 0; i < 8; i++)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            GameObject smallProjectile = Instantiate(smallProjectilePrefab, projectile.transform.position, Quaternion.identity, parentObject.transform);
            Rigidbody2D rb = smallProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = randomDirection * 2f;

            Destroy(smallProjectile, smallProjectileLifetime);
        }

        Destroy(projectile);
    }
}
