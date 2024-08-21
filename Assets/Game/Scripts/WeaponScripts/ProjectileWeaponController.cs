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
    public GameObject greenProjectilePrefab;
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
            //Normalize projectile prefab at start
            projectilePrefab.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
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

        if (ProjectileScaleSkill.Instance.isClicked)
        {
            // Change prefab scale if projectile scale skill is taken
            GameObject scaledProjectilePrefab = projectilePrefab;

            scaledProjectilePrefab.transform.localScale = new Vector3(3, 3, 3);
        }
        else return;
    }

    public void Fire()
    {
        nextFireTime = Time.time + 1f / fireRate;
        PlayFireSound();

        Vector3 direction;
        Vector3 diagonalDirectionUp;
        Vector3 diagonalDirectionDown;
        Vector3 Up;
        Vector3 Down;

        //Set directions for up and down projectiles 
        //It does not matter where the character looks
        Up = (Vector3.up).normalized;
        Down = (Vector3.down).normalized;

        // Determine the direction based on the player's facing direction
        if (playerMovement.lastHorizontalVector > 0)
        {
            direction = Vector3.right;
            diagonalDirectionUp = (Vector3.right + Vector3.up).normalized;
            diagonalDirectionDown = (Vector3.right + Vector3.down).normalized;
        }
        else
        {
            direction = Vector3.left;
            diagonalDirectionUp = (Vector3.left + Vector3.up).normalized;
            diagonalDirectionDown = (Vector3.left + Vector3.down).normalized;
        }

        if (ProjectileSkill2.Instance.isClicked)
        {
            //Upper diagonal
            GameObject projectile1 = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, -0.2f, 0), Quaternion.identity, parentObject.transform);
            Projectile projScript1 = projectile1.GetComponent<Projectile>();
            projScript1.Initialize(diagonalDirectionUp);
            float projectileSpeed1 = projScript1.speed;

            //Down diagonal
            GameObject projectile2 = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 0.2f, 0), Quaternion.identity, parentObject.transform);
            Projectile projScript2 = projectile2.GetComponent<Projectile>();
            projScript2.Initialize(diagonalDirectionDown);
            float projectileSpeed2 = projScript2.speed;
        }

        if (UprightandDownrightSkill.Instance.isClicked)
        {
            //Upright proc
            GameObject projectileUp = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 0, 0), Quaternion.identity, parentObject.transform);
            Projectile projUp = projectileUp.GetComponent<Projectile>();

            projUp.Initialize(Up);
            float projectileUpSpeed = projUp.speed;

            //Downright proc
            GameObject projectileDown = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 0, 0), Quaternion.identity, parentObject.transform);
            Projectile projDown = projectileDown.GetComponent<Projectile>();

            projDown.Initialize(Down);
            float projectileDownSpeed = projDown.speed;
        }

        //Behind projectile if skill already taken shoot projectiles behind the player
        if (BackProjectile.Instance.isClicked)
        {
            GameObject backProjectile = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 0.2f, 0), Quaternion.identity, parentObject.transform);
            Projectile procscript = backProjectile.GetComponent<Projectile>();

            procscript.Initialize(-direction);
            float projectileSpeed = procscript.speed;

        }

        // ProjectileSkill.Instance.isClicked control
        if (ProjectileSkill.Instance.isClicked)
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
            float projectileSpeed2 = projScript2.speed;
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
