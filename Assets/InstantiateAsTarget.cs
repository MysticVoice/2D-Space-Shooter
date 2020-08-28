using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAsTarget : MonoBehaviour
{
    public Transform targetables;
    // Start is called before the first frame update
    void Start()
    {
        targetables = GameObject.Find("Targetables").transform;
        transform.parent = targetables;
    }
}
