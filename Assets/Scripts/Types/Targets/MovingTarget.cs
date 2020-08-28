using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : Target
{
    public override Vector3 trackTarget()
    {
        return transform.position;
    }
}
