using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 0.1f;
    void FixedUpdate()
    {
        transform.position += transform.up * speed;
    }
}
