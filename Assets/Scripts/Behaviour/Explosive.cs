using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float explosionRadius;
    public Vector2 center;
    public LayerMask whatIsTarget;
    public int targetCount = 5;
    public ContactFilter2D cf;
    private List<Collider2D> colliders;
    public int damage = 10;

    void Start()
    {
        colliders = new List<Collider2D>();
        colliders.Capacity = targetCount;
        cf = new ContactFilter2D();
        cf.SetLayerMask(whatIsTarget);
        cf.useLayerMask = true;
        enabled = false;
    }
    public void detonate()
    {
        Physics2D.OverlapCircle(center, explosionRadius, cf, colliders);
        foreach(Collider2D c in colliders)
        {
            Health h = c.GetComponentInParent<Health>();
            float trueDamage = (Vector2.Distance(center, c.transform.position)/explosionRadius);
            trueDamage = 1 - trueDamage;
            h.takeDamage(Mathf.CeilToInt(trueDamage*damage));
        }
    }
}
