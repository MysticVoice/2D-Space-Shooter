using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingFire : Fire
{
    public Target target;

    public override GameObject fire(Transform t)
    {
        GameObject p = base.fire(t);
        if (target != null && p.GetComponent<FollowTargetThrust>() != null)
        {
            p.GetComponent<FollowTargetThrust>().target = target;
        }
        return p;
    }
}
