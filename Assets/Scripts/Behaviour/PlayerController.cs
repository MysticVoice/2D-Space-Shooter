using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D),typeof(ThrusterController))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private ThrusterController tc;
    public Skill skill;
    public Fire fire;
    public float firerate;
    public ControllMode controllMode;
    public Target mouseTarget;

    private bool shiftInput;
    private bool fireInput;
    private int waitFrames;
    

    public enum ControllMode
    {
        Default,
        PointToMouse,
        GlobalAxis
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tc = GetComponent<ThrusterController>();
        fire = GetComponent<Fire>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) shiftInput = true;
        if (Input.GetButton("Fire1")) fireInput = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(controllMode)
        {
            case ControllMode.Default:
                tc.thrust(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Strafe"));
                break;
            case ControllMode.PointToMouse:
                tc.thrust(VectorTools.getWeightedTurnDirection(mouseTarget.trackTarget(),transform,20f), Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
                break;
            case ControllMode.GlobalAxis:
                tc.thrustWorldSpace(VectorTools.getWeightedTurnDirection(mouseTarget.trackTarget(), transform, 20f), Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
                break;
        }
        
        if (shiftInput)
        {
            skill.use();
            shiftInput = false;
        }
        if (fireInput && waitFrames == 0)
        {
            fire.fireAll();
            fireInput = false;
            setWaitFrames();
        }
        else if (waitFrames > 0) waitFrames--;
    }

    void setWaitFrames()
    {
        waitFrames = Mathf.FloorToInt((1 / firerate) * 30);
    }
}
