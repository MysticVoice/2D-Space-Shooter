using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTargetables : MonoBehaviour
{
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject target in targets)
        {
            GameController.Instance.AddTarget(target);
            
        }
        Debug.Log(GameController.Instance.targetables.Count);
        gameObject.SetActive(false);
    }
}
