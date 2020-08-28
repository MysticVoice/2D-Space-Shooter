using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    Rigidbody2D rb;
    public float multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = rb.transform.position;
        transform.position =  v + rb.velocity*multiplier;
    }
}
