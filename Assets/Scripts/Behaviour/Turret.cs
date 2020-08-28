using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector3 dirrection;
    public Target target;
    // Update is called once per frame
    void FixedUpdate()
    {
        dirrection = (target.trackTarget()-transform.position).normalized;
        transform.up = dirrection;

    }
}
