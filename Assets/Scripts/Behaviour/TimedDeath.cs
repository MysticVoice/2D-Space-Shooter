using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float lifetime = 10;
    float spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTime+lifetime<Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
