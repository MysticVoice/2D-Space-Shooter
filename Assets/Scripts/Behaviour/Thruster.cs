using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public float force;

    public Vector3 calculateThrust(float input)
    {
        return transform.up * force * input;
    }
}
