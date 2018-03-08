using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State { Run, Dead, God }
    public State state = State.Run;

    [Header("State")]
    [SerializeField]
    bool canJump = true;
    [SerializeField]
    bool isJumping;
    [SerializeField]
    bool crouch;
    [SerializeField]
    bool isLookingUp;
    [SerializeField]
    bool isLookingDown;

    [Header("Physics")]
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    CollisionDetection collisions;

    [Header("Speed")]
    [SerializeField]
    float runSpeed;
    float movementSpeed;
    float horizontalSpeed;
    [HideInInspector]
    public Vector2 axis;

    [Header("Forces")]
    [SerializeField]
    float jumpForce;

    [Header("Graphics")]
    public SpriteRenderer rend;
	
	void Update ()
    {
        switch(state)
        {
            case State.Run:
                DefaultUpdate();
                break;
            case State.Dead:
                DeadUpdate();
                break;
            case State.God:
                GodUpdate();
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        collisions.MyFixedUpdate();

        if(isJumping)
        {
            if (collisions.isGrounded)
            {
                isJumping = false; 
            }
        }
    }

    void DefaultUpdate()
    {
        HorizontalMovement();

        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y); 
    }

    void DeadUpdate()
    {

    }

    void GodUpdate()
    {
        rb.Sleep();
    }

    void HorizontalMovement()
    {
        if(collisions.isTouchingWall)
        {
            horizontalSpeed = 0;
            return;
        }

        movementSpeed = runSpeed;

        horizontalSpeed = movementSpeed;
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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    #region PublicFunctions
    public void SetAxis(Vector2 inputAxis)
    {
        axis = inputAxis;
    }

    public void JumpStart()
    {
        if(!canJump) return;

        if(collisions.isGrounded ||collisions.isTouchingWall)
        {
            Jump();
        }
    }
    #endregion

    #region SetFunctions
    public void SetDefault()
    {
        rb.WakeUp(); 
        state = State.Run
    }

    public void SetGod()
    {



        state = State.God;
    }
    #endregion


}
