using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector2 offset;
    [SerializeField]
    Vector2 smoothTime;
    [SerializeField]
    Vector2 velocity;

    [SerializeField]
    float yPos; 
	
	void FixedUpdate ()
    {
        offset.x = Mathf.Abs(offset.x);

        Vector3 newPosition = new Vector2(player.position.x + offset.x, yPos);

        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, newPosition.x, ref velocity.x, smoothTime.x),
            Mathf.SmoothDamp(transform.position.y, newPosition.y, ref velocity.y, smoothTime.y), transform.position.z);
	}
}
