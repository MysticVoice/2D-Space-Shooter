using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThrusterController))]
public class EnemyController : MonoBehaviour
{
    //public Transform target;
    public Target target;
    public Vector2 waypoint;
    ThrusterController tc;
    public Fire fire;
    public float firerate;
    private int waitFrames;
    FindPointNear pointFinder;
    public float pointReachedThreshold = 1;
    private float followDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        waitFrames = 0;
        tc = GetComponent<ThrusterController>();
        pointFinder = GetComponent<FindPointNear>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waypointManagement();
        tc.thrust(getTurnDirection(),1,0);
        if (waitFrames == 0)
        {
            if(fire != null) fire.fire();
            setWaitFrames();
        }
        waitFrames--;
    }


    void setWaitFrames()
    {
        waitFrames = Mathf.FloorToInt((1/firerate) * 30);
    }
    
    public void waypointManagement()
    {
        if(Vector2.Distance(waypoint, new Vector2(transform.position.x, transform.position.y))<pointReachedThreshold)
        {
            waypoint = pointFinder.findNewPoint(new Vector2(target.trackTarget().x, target.trackTarget().y));
        }
        if(Vector3.Distance(target.trackTarget(),transform.position)>followDistance)
        {
            waypoint = new Vector2(target.trackTarget().x, target.trackTarget().y);
        }
    }

    public float getTurnDirection()
    {
        Vector2 direction = waypoint-new Vector2(transform.position.x, transform.position.y);
        float dir = Vector2.SignedAngle(direction, transform.up);
        if(dir > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }

    }
}
