using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPointNear : MonoBehaviour
{
    public float maxDistance = 5;

    public Vector2 findNewPoint(Vector2 target)
    {
        float distance = Random.Range(0, maxDistance);
        Vector2 randomDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
        return target + (randomDirection * distance);
    }
}
