using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float maxMovementSpeed;
    public float maxAccel;
    public Rigidbody2D rb;

    private bool startToEnd;

    void Start() 
    {
        startToEnd = true;
    }

    void FixedUpdate()
    {
        Vector3 target = startToEnd ? endPos : startPos;

        Vector3 dirToTarget = (target - gameObject.transform.position).normalized;
        float distToTarget = (target - gameObject.transform.position).magnitude;

        float epsilon = 0.1f;
        bool reachedTargetVel = (maxMovementSpeed - rb.velocity.magnitude) < epsilon;
        float deaccelRadius = (float) Math.Pow(rb.velocity.magnitude, 2f) / (2f * maxAccel); 
        bool slowing = distToTarget < deaccelRadius;

        float accel = maxAccel * (slowing ? -1f : 1f);
        // TODO: Cancel out velocity that is not in direction of target
        Vector2 vel = new Vector2(dirToTarget.x, dirToTarget.y) * (reachedTargetVel ? 0f : accel) * Time.deltaTime;

        rb.velocity += vel;

        if (distToTarget < 1f) {
            startToEnd = !startToEnd;
        }
    }
}
