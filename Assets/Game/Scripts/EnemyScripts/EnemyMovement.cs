using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        // Check and flip the sprite direction
        SpriteDirectionChecker();
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
