using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    public int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int ammount)
    {
        health -= ammount;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public float normalizedHealth()
    {
        return health / (float)maxHealth;
    }
}
