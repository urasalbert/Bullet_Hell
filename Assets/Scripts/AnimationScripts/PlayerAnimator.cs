using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Player animations
    Animator animator;
    PlayerMovement playermovement;
    SpriteRenderer spriterenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //If player moving
        if (playermovement.moveDirection.x != 0 || playermovement.moveDirection.y != 0)
        {
            animator.SetBool("isMoving", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    //Face the moving direction
    void SpriteDirectionChecker()
    {
        //lastHorizontalVector for upwards walking fix
        if (playermovement.lastHorizontalVector < 0)// x < 0 left 
        {
            spriterenderer.flipX = false;
        }
        else
        {
            spriterenderer.flipX = true; // x > 0 right
        }
    }
}
