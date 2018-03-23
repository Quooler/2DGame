using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State { Run, Dead, God }
    public State state = State.Run;

    [Header("Sound clips")]
    [SerializeField]
    AudioSource myAudioSource; 
    [SerializeField]
    AudioClip jumpAudio;
    [SerializeField]
    AudioClip dieAudio;
    [SerializeField]
    AudioClip groundedAudio; 

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
    [SerializeField]
    Collider2D collider; 

    [Header("Speed")]
    [SerializeField]
    float runSpeed;
    float movementSpeed;
    float horizontalSpeed;

    [Header("Forces")]
    [SerializeField]
    float jumpForce;

    [Header("Graphics")]
    public SpriteRenderer rend;
    [SerializeField]
    Animator animator;

    [SerializeField]
    InputManager manager; 

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
        if (state != State.Dead)
        {
            collisions.MyFixedUpdate();

            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("IsFalling", true);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
        }        
    }

    void DefaultUpdate()
    {
        HorizontalMovement();
    }

    void DeadUpdate()
    {
        if (transform.position.y < -2)
        {
            manager.LoadEndScene(); 
        }
    }

    void GodUpdate()
    {
        rb.Sleep();
    }

    void HorizontalMovement()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (collisions.isTouchingWall)
        {
            movementSpeed = 0;
        }
        else
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
    }

    #region PublicFunctions
    public void JumpStart()
    {
        if(!canJump) return;

        if(collisions.isGrounded || collisions.isTouchingWall)
        {
            animator.SetTrigger("Jump");
            myAudioSource.PlayOneShot(jumpAudio);
            Jump();
        }
    }
    #endregion

    #region SetFunctions
    public void SetDefault()
    {
        rb.WakeUp();
        state = State.Run; 
    }

    public void SetGod()
    {



        state = State.God;
    }

    public void SetDead()
    {
        collider.enabled = false;
        collisions.enabled = false; 
        StatsManager.playerPoints = 0;
        state = State.Dead;
        rb.velocity = Vector3.zero;
        myAudioSource.PlayOneShot(dieAudio);
    }
    #endregion


}
