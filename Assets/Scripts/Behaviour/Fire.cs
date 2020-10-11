using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<Transform> firePoints;
    public GameObject projectile;
    public LayerMask whatIsTarget;

    public virtual void fireAll()
    {
        
        foreach(Transform firePoint in firePoints)
        {
            fire(firePoint);
        }
    }

    public virtual GameObject fire(Transform t)
    {
        GameObject p = Instantiate(projectile);
        p.GetComponent<DealDamage>().whatIsTarget = whatIsTarget;
        p.transform.position = t.position;
        p.transform.rotation = t.rotation;
        return p;
    }
}
