using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetThrust : MonoBehaviour
{
    public Target target;
    ThrusterController tc;
    public float startVelocity = 100;
    // Start is called before the first frame update
    void Start()
    {
        tc = GetComponent<ThrusterController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * startVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tc.thrust(getTurnDirection(), 1, 0);
    }

    public float getTurnDirection()
    {
        Vector2 direction;
        if (target != null)
        {
             direction = target.trackTarget() - transform.position;
        }
        else
        {
            direction = transform.up;
        }
        float dir = Vector2.SignedAngle(direction, transform.up);
        if (dir > 0)
        {
            return 1;
        }
        else if (dir < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }

    }
}
