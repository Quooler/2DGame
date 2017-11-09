﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDetection))]
public class CharacterBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, GodMode }
    public State state;
    [Header("State")]
    public bool canMove = true;
    public bool canJump = true;
    public bool isFacingRight = true;
    public bool isJumping = false;
    public bool isRunning = false;
    public bool crouch = false;
    public bool isLookingUp = false;
    public bool isLookingDown = false;
    [Header("Physics")]
    public Rigidbody2D rb;
    public CollisionDetection collisions;
    [Header("Speed")]
    public float walkSpeed;
    public float runSpeed;
    public float movementSpeed;
    public float horizontalSpeed;
    public Vector2 axis;
    [Header("Forces")]
    public float jumpWalkForce;
    public float jumpRunForce;
    public float jumpForce;
    [Header("Graphics")]
    public SpriteRenderer rend;
    
    void Start ()
    {
        collisions = GetComponent<CollisionDetection>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        switch(state)
        {
            case State.Default:
                DefaultUpdate();
                break;
            case State.Dead:
                break;
            case State.GodMode:
                GodUpdate(); 
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        collisions.MyFixedUpdate();

        if(isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    protected virtual void DefaultUpdate()
    {
        // Calcular el movimiento horizontal
        HorizontalMovement();
        // Calcular el movimiento vertical
    }

    protected virtual void GodUpdate()
    {
        HorizontalMovement();

        FlyMovement(); 
    }

    void HorizontalMovement()
    {
        if(!canMove)
        {
            horizontalSpeed = 0;
            return;
        }
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Punto muerto
        if(-0.1f < axis.x && axis.x < 0.1f)
        {
            if(collisions.isGrounded)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            horizontalSpeed = 0;
            return;
        }
        //Si toca la pared
        if(collisions.isWalled)
        {
            if((isFacingRight && axis.x > 0) || (!isFacingRight && axis.x < 0))
            {
                horizontalSpeed = 0;
                return;
            }
        }

        if(isFacingRight && axis.x < 0) Flip();
        if(!isFacingRight && axis.x > 0) Flip();

        if(isRunning) movementSpeed = runSpeed;
        else movementSpeed = walkSpeed;

        horizontalSpeed = axis.x * movementSpeed;
    }
    void VerticalMovement()
    {
        crouch = false;
        isLookingDown = false;
        isLookingUp = false;
    }
    void Jump()
    {
        isJumping = true;
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        rend.flipX = !rend.flipX;
        collisions.Flip(isFacingRight);
    }

    void FlyMovement()
    {

    }

    #region Public
    public void SetAxis(Vector2 inputAxis)
    {
        axis = inputAxis;
    }
    public void JumpStart() //Decidir como será el salto
    {
        if(!canJump) return;

        if(collisions.isGrounded)
        {
            if(isLookingDown)
            {
                Debug.Log("bajar plataforma");
            }

            if(isRunning) jumpForce = jumpRunForce;
            else jumpForce = jumpWalkForce;
            Jump();
        }
    }
    #endregion
}
