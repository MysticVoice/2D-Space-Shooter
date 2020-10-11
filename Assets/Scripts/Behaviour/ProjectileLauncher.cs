using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : Shootable
{
    public GameObject projectile;
    public override GameObject fire(bool input,LayerMask whatIsTarget)
    {
        GameObject p = Instantiate(projectile);
        p.GetComponent<DealDamage>().whatIsTarget = whatIsTarget;
        p.transform.position = transform.position;
        p.transform.rotation = transform.rotation;
        return p;
    }
}
