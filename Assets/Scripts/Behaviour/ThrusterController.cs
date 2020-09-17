using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    public float forwardsThrust = 10;
    public float sidewaysThrust = 5;
    public float rotationForce = 1;
    public bool stabilize = false;

    private Rigidbody2D rb;
    private Quaternion qt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        qt = transform.rotation;
    }
    public void thrust(float horizontalInput,float verticalInput, float strafeInput)
    {
        Vector3 thrustDirection = Vector3.zero;
        thrustDirection += calculateThrust(verticalInput, transform.up,forwardsThrust);
        thrustDirection += calculateThrust(strafeInput,transform.right,sidewaysThrust);
        rb.AddForce(thrustDirection);
        rb.AddTorque(-horizontalInput*rotationForce);
    }

    public Vector3 calculateThrust(float input, Vector3 direction, float force)
    {
        return direction * force * input;
    }
}
