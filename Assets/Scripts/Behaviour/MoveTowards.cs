using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Vector3 target;
    public float moveDist = 0.1f;
    bool destinationReached = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        if (Vector3.Distance(transform.position,target)>0.01f)
        {
            destinationReached = true;
            enabled = false;
        }
    }

    public void move()
    {
        Vector3.MoveTowards(transform.position, target, moveDist);
    }
}
