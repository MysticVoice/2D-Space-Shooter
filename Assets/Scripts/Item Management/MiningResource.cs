using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningResource : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dropResources()
    {
        float type = Perlin.Noise(transform.position.x,transform.position.y);
        float ammount = Perlin.Noise(transform.position.x,transform.position.y,0.9f);
    }
}
