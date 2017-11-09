using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [Header("State")]
    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justGrounded;
    public bool justNOTGrounded;
    public bool isFalling;

    public bool isWalled;

    [Header("Boxes")]
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;

    public Vector2 ceilingBoxPos;
    public Vector2 ceilingBoxSize;

    public Vector2 wallBoxPos;
    public Vector2 wallBoxSize; 

    [Header("Properties")]
    public int maxHits;
    public bool detectGround = true;
    public bool detectCeil = false;
    public bool detectWall = false; 
    public ContactFilter2D filter;


    public void MyFixedUpdate()
    {
        ResetState();
        DetectGround();
        DetectCeiling();
        DetectWall(); 
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isGrounded = false;
        justNOTGrounded = false;
        justGrounded = false;
        isFalling = true;

        isWalled = false;
    }

    void DetectGround()
    {
        if (!detectGround) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)groundBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, groundBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isGrounded = true;
        }
        isFalling = !isGrounded;

        if (!wasGroundedLastFrame && isGrounded)
        {
            Debug.Log("JUST GROUNDED");
            justGrounded = true;
        }
        if (wasGroundedLastFrame && !isGrounded)
        {
            Debug.Log("JUST NOT GROUNDED");
            justNOTGrounded = true;
        }
    }

    void DetectCeiling()
    {
        if (!detectGround) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)ceilingBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, ceilingBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isGrounded = true;
        }

        if (!wasGroundedLastFrame && isGrounded)
        {
            Debug.Log("JUST GROUNDED");
            justGrounded = true;
        }
        if (wasGroundedLastFrame && !isGrounded)
        {
            Debug.Log("JUST NOT GROUNDED");
            justNOTGrounded = true;
        }
    }

    void DetectWall()
    {
        if (!detectGround) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)wallBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, wallBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isWalled = true;
        }

        if (!wasGroundedLastFrame && isGrounded)
        {
            Debug.Log("JUST GROUNDED");
            justGrounded = true;
        }
        if (wasGroundedLastFrame && !isGrounded)
        {
            Debug.Log("JUST NOT GROUNDED");
            justNOTGrounded = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 newPosGround = (Vector3)groundBoxPos + transform.position;
        Gizmos.DrawWireCube(newPosGround, groundBoxSize);

        Gizmos.color = Color.blue;
        Vector3 newPosCeil = (Vector3)ceilingBoxPos + transform.position;
        Gizmos.DrawWireCube(newPosCeil, ceilingBoxSize);

        Gizmos.color = Color.blue;
        Vector3 newPosWall = (Vector3)wallBoxPos + transform.position;
        Gizmos.DrawWireCube(newPosWall, wallBoxSize);
    }

    public void Flip(bool other)
    {

    }
}
