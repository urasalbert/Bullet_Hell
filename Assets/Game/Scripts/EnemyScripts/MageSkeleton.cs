using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSkeleton : MonoBehaviour
{
    [SerializeField] internal GameObject projectilePrefab;
    private float projectileSpeed = 3f;
    private Transform playerTransform;
    Animator animator;
    private float timeSinceLastShot;
    private float fireInterval = 3f; // Fire every 3 seconds
    private SpriteRenderer spriteRenderer;
    Transform _playerTransform;
    GameObject parentObject;
    EnemyMovement enemyMovement;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentObject = GameObject.FindWithTag("Environment");
        enemyMovement = GetComponent<EnemyMovement>();
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

    void Update()
    {
        //If enemy is not frozen
        if (!enemyMovement.isFrozen)
        {
            SpriteDirectionChecker();
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= fireInterval)
            {
                animator.SetBool("isCasting", true);

                FireProjectile();
                timeSinceLastShot = 0f; // Reset the timer
            }
            else
            {
                animator.SetBool("isCasting", false);
            }
        }
    }

    void FireProjectile()
    {
        if (projectilePrefab == null) return;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Get the player's current transform before shooting

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, parentObject.transform);

        if (projectile == null) // Null check for projectile creation
        {
            Debug.LogError("Failed to instantiate projectile");
            return;
        }

        Vector3 targetPosition = playerTransform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null) // Null check if it's not null add velocity to projectile
        {
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile does not have a rb component");
        }

        Destroy(projectile,10f);// Anti lag destroy
    }
    void SpriteDirectionChecker()
    {
        // Check the direction of the player relative to the enemy
        if (_playerTransform.position.x < transform.position.x)
        {
            // Player is to the left, face left
            spriteRenderer.flipX = false;
        }
        else
        {
            // Player is to the right, face right
            spriteRenderer.flipX = true;
        }
    }
}
