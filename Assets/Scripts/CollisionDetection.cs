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

    public bool isCeiled; 
    public bool wasCeiledLastFrame;
    public bool justCeiled;
    public bool justNOTCeiled;

    public bool isWalled; 
    public bool wasWalledLastFrame;
    public bool justWalled;
    public bool justNOTWalled; 

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


    private void FixedUpdate()
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

        wasCeiledLastFrame = isCeiled;
        isCeiled = false;
        justNOTCeiled = false;
        justCeiled = false;

        wasWalledLastFrame = isWalled;
        isWalled = false;
        justNOTWalled = false;
        justWalled = false; 
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
        if (!detectCeil) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)ceilingBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, ceilingBoxSize, 0, filter, results); 

        if (numHits > 0)
        {
            isCeiled = true;
        }

        if (!wasCeiledLastFrame && isCeiled)
        {
            Debug.Log("JUST CEILED");
            justCeiled = true;
        }
        if (wasCeiledLastFrame && !isCeiled)
        {
            Debug.Log("JUST NOT CEILED");
            justNOTCeiled = true; 
        }
    }

    void DetectWall()
    {
        if (!detectWall) return;

        Collider2D[] results = new Collider2D[maxHits];
        Vector3 newPos = (Vector3)wallBoxPos + transform.position;
        int numHits = Physics2D.OverlapBox(newPos, wallBoxSize, 0, filter, results);

        if (numHits > 0)
        {
            isWalled = true;
        }

        if (!wasWalledLastFrame && isWalled)
        {
            Debug.Log("JUST WALLED");
            justWalled = true;
        }
        if (wasWalledLastFrame && !isWalled)
        {
            Debug.Log("JUST NOT WALLED");
            justNOTWalled = true;
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
}
