using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private bool hasAttackAnim;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Move();

        // Check and flip the sprite direction
        SpriteDirectionChecker();
    }

    void Move()
    {
        float offset = Random.Range(-0.5f, 0.5f) > 0 ? 0.5f : -0.5f;

        Vector2 targetPosition = new Vector2(playerTransform.position.x + offset, playerTransform.position.y);

        if (hasAttackAnim)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }
    // Face the moving direction
    void SpriteDirectionChecker()
    {
        // Check the direction of the player relative to the enemy
        if (playerTransform.position.x < transform.position.x)
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
