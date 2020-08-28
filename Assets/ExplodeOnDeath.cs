using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDeath : MonoBehaviour
{
    Explosive explosive;
    bool isQuitting = false;
    void Start()
    {
        explosive = GetComponent<Explosive>();
    }
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if(!isQuitting)
        {
            explosive.detonate();
        }
    }
}
