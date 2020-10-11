using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        if (target != null) tc.thrust(VectorTools.getWeightedTurnDirection(target.trackTarget(), transform, 5f), 1, 0);
        else tc.thrust(0, 1, 0);
        
    }
}
