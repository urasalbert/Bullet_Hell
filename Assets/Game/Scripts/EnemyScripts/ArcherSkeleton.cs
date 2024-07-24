using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArcherSkeleton : MonoBehaviour
{
    [SerializeField] internal GameObject projectilePrefab;
    private float projectileSpeed = 10f;
    private Transform playerTransform;
    Animator animator;
    private float timeSinceLastShot;
    private float fireInterval = 3f; // Fire every 3 seconds
    private SpriteRenderer spriteRenderer;
    Transform _playerTransform;
    GameObject parentObject;
    [NonSerialized] public bool isRight;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentObject = GameObject.FindWithTag("Environment");
    }

    void Start()
    {
        // Additional check to ensure projectilePrefab is not null
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab is not assigned!");
        }
        timeSinceLastShot = fireInterval; // Initialize to fire immediately on start
    }

    private void Update()
    {
        SpriteDirectionChecker();
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireInterval)
        {
            animator.SetBool("isShooting", true);

            FireProjectile();
            timeSinceLastShot = 0f; // Reset the timer
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }


    void FireProjectile()
    {
        if (projectilePrefab == null)
        {
            Debug.Log("Ok prefab'ý atanmýþ deðil");
            return;
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 direction;
        Quaternion rotation;

        if (playerTransform.position.x > transform.position.x)
        {
            direction = Vector3.right;
            rotation = Quaternion.Euler(0, 0, -90); // Yön sað
        }
        else
        {
            direction = Vector3.left;
            rotation = Quaternion.Euler(0, 0, 90); // Yön sol
        }

        // Create bow prefab
        GameObject arrowPrefab = Instantiate(projectilePrefab, transform.position, rotation, parentObject.transform);

        if (arrowPrefab == null) // Null check
        {
            Debug.LogError("Projeyi oluþturmakta baþarýsýz");
            return;
        }

        Rigidbody2D rb = arrowPrefab.GetComponent<Rigidbody2D>();

        if (rb != null) // If there is rb set speed
        {
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projede rb bileþeni bulunamadý");
        }

        Destroy(arrowPrefab, 10f); // Destroy it for antilag
    }
    void SpriteDirectionChecker()
    {
        // Check the direction of the player relative to the enemy
        if (_playerTransform.position.x < transform.position.x)
        {
            // Player is to the left, face left
            spriteRenderer.flipX = false;
            isRight = false; //For arrow rotation script
        }
        else
        {
            // Player is to the right, face right
            spriteRenderer.flipX = true;
            isRight = true;
        }
    }
}
