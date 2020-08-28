using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDeath : MonoBehaviour
{
    public GameObject prefab;

    void OnDestroy()
    {
        GameObject g = Instantiate(prefab);
        g.transform.position = transform.position;
    }
}
