using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemy : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Transform playerTransform;
    private Animator animator;
    private float triggerRadius = 7f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Get player with tag in scene
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        SpriteDirectionChecker();

        //Check trigger for attack behaivour
        if (distanceToPlayer <= triggerRadius)
        {
            Debug.Log("Mimic is attacking");
            TriggerAttackSound();
            MoveTowardsPlayer();
            TriggerAttackAnimation();
        }
    }

    //Trigger follow / run animation
    void TriggerAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    //Move to the player
    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }

    bool flag1 = false;
    void TriggerAttackSound()
    {
       
        if(!flag1)
        {
            MimicSounds.Instance.PlayMimicAttackSound();
            flag1 = true;
        }
        
    }
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
