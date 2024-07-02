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

    public LayerMask enemyLayer;
    public GameObject projectilePrefab;
    public Transform firePoint; 
    public Vector3 testTargetPos;

    protected void PlayFireSound()
    {
        // Play fire sound 
    }

    public void FireAtNearestEnemy()
    {
        if (Time.time >= nextFireTime)
        {
            Collider2D nearestEnemy = FindNearestEnemy();
            if (nearestEnemy != null)
            {
                Fire(nearestEnemy.transform.position);
            }
        }
    }
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire(testTargetPos);
        }
    }
    protected Collider2D FindNearestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        Collider2D nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void Fire(Vector3 targetPosition)
    {
        nextFireTime = Time.time + 1f / fireRate;
        PlayFireSound();

        // Create the projectile 
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projScript = projectile.GetComponent<Projectile>();
        projScript.SetTarget(testTargetPos);//Set projectile values setted to test target for now
        projScript.damage = damage;
        projScript.speed = projectileSpeed;
    }
}
