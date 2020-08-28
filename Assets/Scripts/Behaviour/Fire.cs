using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject projectile;
    public LayerMask whatIsTarget;
    private Rigidbody2D rb;

    public virtual GameObject fire()
    {
        GameObject p = Instantiate(projectile);
        p.GetComponent<DealDamage>().whatIsTarget = whatIsTarget;
        p.transform.position = this.transform.position;
        p.transform.rotation = this.transform.rotation;
        return p;
    }
}
