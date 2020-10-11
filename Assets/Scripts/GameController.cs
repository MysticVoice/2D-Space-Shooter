using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController :MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameController");
                _instance = go.AddComponent<GameController>();
            }
            return _instance;
        }
    }

    public Health playerHealth { get; set; }
    public List<GameObject> targetables { get; set; }


    public void AddTarget(GameObject target)
    {
        if (targetables == null) targetables = new List<GameObject>();
        targetables.Add(target);
    }

    public Target GetPlayerTarget()
    {
        return playerHealth.GetComponent<Target>();
    }
}
