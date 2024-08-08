using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArcherSkeletonMove : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed = 2f;
    private float stopDistance = 7f;
    private Animator animator;


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        if (playerTransform == null) // Null check
        {
            Debug.LogWarning("Player Transform is not assigned!");
            return;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position); // Calc the distance current and
        //compare it with stopDistance

        if (distanceToPlayer > stopDistance)
        {
            animator.SetBool("isMoving", true);
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetTrigger("isShoot");
            //animator.SetBool("isMoving", false);
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the direction vector between enemy and player
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        // Move the enemy in this direction
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }
}
