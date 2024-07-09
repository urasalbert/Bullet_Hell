using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    [HideInInspector]
    public float lastHorizontalVector, lastVerticalVector;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputManagement();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        //Storing last vectors for better char flip animations
        if(moveDirection.x != 0)
        {
            lastHorizontalVector = moveDirection.x;
        }
        if (moveDirection.y != 0)
        {
            lastVerticalVector = moveDirection.y;
        }


    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
