using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public LayerMask whatIsTarget;
    Collider2D target;
    Health health;
    private Collider2D self;
    public int damage = 10;

    void Start()
    {
        self = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        target = Physics2D.OverlapCircle(transform.position, transform.localScale.x/10,whatIsTarget);
        if(target != null && target != self)
        {
            health = target.GetComponentInParent<Health>();
            if (health != null)
            {
                health.takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
