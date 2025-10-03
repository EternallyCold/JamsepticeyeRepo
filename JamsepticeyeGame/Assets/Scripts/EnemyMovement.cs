using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float movementSpeed;
    public Rigidbody2D rb;

    private bool startToEnd;

    void Start() 
    {
        startToEnd = true;
    }

    void FixedUpdate()
    {
        Vector3 relStart = startToEnd ? startPos : endPos;
        Vector3 relEnd = startToEnd ? endPos : startPos;
        float dist = (relEnd - relStart).magnitude;
        Vector3 dir = (relEnd - relStart).normalized;

        float distLeft = (relEnd - gameObject.transform.position).magnitude;
        float distTravelled = dist - distLeft;
        float ratio = distTravelled / dist;
            
        Vector3 vel = dir * movementSpeed * Time.deltaTime;

        // TODO: Make accel smoother, prolly use cosine function, not really a priority
        
        if (ratio <= 0.5 && rb.velocity.magnitude < movementSpeed) {
            rb.velocity += new Vector2(vel.x, vel.y);
        } 
        else if (ratio > 0.5 && rb.velocity.magnitude > 0f) {
            rb.velocity -= new Vector2(vel.x, vel.y);
        }

        if (distLeft < 1f) { // close enough
            startToEnd = !startToEnd; // switch direction
        }
    }
}
