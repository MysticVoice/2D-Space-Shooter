using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTarget : Target
{
    public Vector3 target;
    public override Vector3 trackTarget()
    {
        return target;
    }
}
