using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorTools
{
    public static float getTurnDirection(Vector3 target, Transform transform)
    {
        Vector2 direction;
        if (target != null)
        {
            direction = target - transform.position;
        }
        else
        {
            direction = transform.up;
        }
        float dir = Vector2.SignedAngle(direction, transform.up);
        if (dir > 0)
        {
            return 1;
        }
        else if (dir < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }

    }

    public static float getWeightedTurnDirection(Vector3 target, Transform transform, float maximumTorqueAngle)
    {
        Vector2 direction;
        if (target != null)
        {
            direction = target - transform.position;
        }
        else
        {
            direction = transform.up;
        }
        float dir = Vector2.SignedAngle(direction, transform.up);
        if (dir > 0)
        {
            dir = Mathf.Clamp(dir, 0, maximumTorqueAngle);
        }
        else if (dir < 0)
        {
            dir = Mathf.Clamp(dir, -maximumTorqueAngle, 0);
        }
        else
        {
            dir = 0;
        }
        dir = (dir / maximumTorqueAngle);
        return dir;
    }
}
