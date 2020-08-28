using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Target target;
    public List<GameObject> boids;
    public float attractionRange = 10;
    public float repulsionRange = 2;
    public float angleLimit = 70;
    public float turnWeight = 1;
    public float repulsionMultiplier = 2;
    public float alignmentPower = 0.01f;
    public float targetingWeight = 0.2f;
    public float thrusterForce = 2.5f;

    private float calcRotation;
    private List<ThrusterController> boidThrusters;

    

    void Start()
    {
        getComponentReferences();
        foreach(ThrusterController t in boidThrusters)
        {
            t.setThrusterForces(thrusterForce);
        }
    }
    void FixedUpdate()
    {
        runBoids();
    }
    void runBoids()
    {
        for (int currentBoidIndex = 0; currentBoidIndex < boids.Count; currentBoidIndex++)
        {
            checkAllBoids(currentBoidIndex);
        }
    }

    void checkAllBoids(int currentBoidIndex)
    {
        calcRotation = 0;
        Transform boid = boids[currentBoidIndex].transform;
        for (int boidToCheckIndex = 0; boidToCheckIndex < boids.Count; boidToCheckIndex++)
        {
            
            if (currentBoidIndex != boidToCheckIndex)
            {
                
                Transform otherBoid = boids[boidToCheckIndex].transform;
                boidBehaviour(boid,otherBoid);
            }
        }
        controllBoid(calcRotation, currentBoidIndex);
    }

    void boidBehaviour(Transform boid,Transform otherBoid)
    {
        if (isBoidInRange(boid.transform,otherBoid.transform, attractionRange))
        {
            calcRotation += boidTurnCalculation(boid, otherBoid);
        }
        if (target != null)
        {
            calcRotation += seek(boid, target.transform) * targetingWeight;
        }
    }

    float boidTurnCalculation(Transform boid, Transform otherBoid)
    {
        float result = 0;
        float angle = Vector3.SignedAngle(boid.transform.up, otherBoid.transform.up, Vector3.forward);
        //angle = limitAngle(angleLimit, angle);
        //result = attraction(angle);
        //Debug.Log
        result += seek(boid, otherBoid);
        

        float dist = Vector3.Distance(boid.transform.position, otherBoid.transform.position);
        if(dist>0.1f)
        {
            float align = attraction(angle * attractionRange / Vector3.Distance(boid.transform.position, otherBoid.transform.position));
            if(angle<0)
            {
                align *= -1;
            }
            result += align*alignmentPower;
        }
        return result;

    }

    float seek(Transform boid, Transform otherBoid)
    {
        float result = 0;
        float turnDir = Vector3.SignedAngle(boid.transform.up, otherBoid.transform.position - boid.transform.position, Vector3.forward);

        if (isBoidInRange(boid, otherBoid, repulsionRange))
        {
            result += avoidance(turnDir)*repulsionMultiplier;
        }
        else
        {
            result += attraction(turnDir);

        }
        return result;
    }

    bool isBoidInRange(Transform boid, Transform otherBoid, float range)
    {
        return Vector3.Distance(boid.position,otherBoid.position)<range;
    }

    float limitAngle(float limit, float angle)
    {
        if (angle > limit || angle < -limit)
        {
            return angle;
        }
        else return 0;
    }

    float attraction(float angle)
    {
        //Debug.Log();
        float result = (invertAngle(Mathf.Abs(angle)) / angleLimit) * turnWeight;
        if (angle < 0)
        {
            result *= -1;
        }
        return result;
    }

    float avoidance(float angle)
    {
        return -attraction(angle);
    }

    float invertAngle(float angle)
    {
        return angleLimit - angle;
    }

    float align(float calcAngle)
    {
        //return Remap.map(calcAngle, 0, angleLimit, 0, 1) * turnWeight;
        return attraction(calcAngle);
    }

    

    void getComponentReferences()
    {
        boidThrusters = new List<ThrusterController>();
        for (int boidIndex = 0; boidIndex < boids.Count; boidIndex++)
        {
            boidThrusters.Add(boids[boidIndex].GetComponent<ThrusterController>());
        }
    }

    void controllBoid(float turnDir, int boidNumber)
    {
        boidThrusters[boidNumber].thrust(-turnDir,1,0);
    }
}
