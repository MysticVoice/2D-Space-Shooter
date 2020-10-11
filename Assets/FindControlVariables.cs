using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindControlVariables : MonoBehaviour
{
    public Health playerHealth;
    GameController g;
    // Start is called before the first frame update
    void Awake()
    {
        g = GameController.Instance;
        g.playerHealth = playerHealth;
        g.targetables = new List<GameObject>();
        enabled = false;
    }
}
