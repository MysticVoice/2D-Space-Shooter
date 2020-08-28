using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    public List<Thruster> forwardThrusters;
    public List<Thruster> sidewaysThrusters;
    public float rotationForce;
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
        foreach(Thruster t in forwardThrusters)
        {
            thrustDirection += t.calculateThrust(verticalInput);
        }
        foreach (Thruster t in sidewaysThrusters)
        {
            thrustDirection += t.calculateThrust(strafeInput);
        }
        rb.AddForce(thrustDirection);
        rb.AddTorque(-horizontalInput*rotationForce);
        //transform.Rotate(transform.forward, -horizontalInput * rotationForce);
    }

    public void setThrusterForces(float force)
    {
        foreach(Thruster t in forwardThrusters)
        {
            t.force = force;
        }
    }
}
