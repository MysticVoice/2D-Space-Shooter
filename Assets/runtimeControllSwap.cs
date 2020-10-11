using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runtimeControllSwap : MonoBehaviour
{
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) pc.controllMode = PlayerController.ControllMode.Default;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) pc.controllMode = PlayerController.ControllMode.GlobalAxis;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) pc.controllMode = PlayerController.ControllMode.PointToMouse;
    }
}
