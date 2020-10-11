using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOverTime : MonoBehaviour
{
    public GameObject spawnObject;
    public float rateOverTime = 1;
    private FindPointNear pointFinder;
    public Transform parent;
    public Target target;

    public LayerMask whatIsTarget;
    private int waitFrames = 0;
    void Start()
    {
        parent = GameObject.Find("Targetables").transform;
        pointFinder = GetComponent<FindPointNear>();
        resetTimer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        waitFrames--;
        if(waitFrames <= 0)
        {
            Vector2 point = pointFinder.findNewPoint(transform.position);
            Vector3 pos = new Vector3(point.x,point.y,0);
            GameObject g = Instantiate(spawnObject);
            g.transform.position = pos;
            if (parent != null)
            {
                g.transform.parent = parent;
                if(g.GetComponent<FollowTargetThrust>() != null)
                {
                    g.GetComponent<FollowTargetThrust>().target = target;
                }
                if(g.GetComponent<DealDamage>() != null)
                {
                    g.GetComponent<DealDamage>().whatIsTarget = whatIsTarget;
                }
                if(g.GetComponent<EnemyController>() != null)
                {
                    g.GetComponent<EnemyController>().moveToTarget = target;
                }
                if(g.GetComponentInChildren<Turret>() != null)
                {
                    g.GetComponentInChildren<Turret>().target = target;
                }
                if (g.GetComponentInChildren<TrackingFire>() != null)
                {
                    g.GetComponentInChildren<TrackingFire>().target = target;
                }
            }
            resetTimer();
        }
    }

    void resetTimer()
    {
        waitFrames = Mathf.CeilToInt(30 / rateOverTime);
    }
}
