using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public GameObject enemiesRef;
    public Transform searchOrigin;
    public TrackingFire fire;

    public float maxDistance = 10f;
    
    void FixedUpdate()
    {
        findTarget();
    }

    public void findTarget()
    {
        Health[] targets = enemiesRef.GetComponentsInChildren<Health>();
        Health closestTarget = null;
        foreach(Health target in targets)
        {
            float distToTarget = Vector3.Distance(searchOrigin.position, target.transform.position);
            if (distToTarget < maxDistance)
            {
                if (closestTarget == null)
                {
                    closestTarget = target;
                }
                else if (Vector3.Distance(searchOrigin.position, closestTarget.transform.position)
                    >
                    distToTarget
                    )
                {
                    closestTarget = target;
                }
            }
        }
        if (closestTarget != null)
        {
            fire.target = closestTarget.GetComponent<Target>();
        }
        else
        {
            fire.target = null;
        }
    }


}
