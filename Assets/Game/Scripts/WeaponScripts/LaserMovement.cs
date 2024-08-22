using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 direction;

    private void Awake()
    {
        // Get player movement direction for shooting direction
        PlayerMovement playerMovement = FindAnyObjectByType<PlayerMovement>();

        // Determine the initial direction based on the player's last movement
        if (playerMovement.lastHorizontalVector > 0)
        {
            direction = Vector3.right; // Move right
        }
        else
        {
            direction = Vector3.left; // Move left
        }
    }

    void Update()
    {
        Move();
        Destroy(gameObject,5f);//Destroy game object after 5 secs for antilag
    }

    void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
