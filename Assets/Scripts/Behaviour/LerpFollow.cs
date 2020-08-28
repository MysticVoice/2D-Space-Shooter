using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float lerpFactor = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position,lerpFactor)+offset;
    }
}
