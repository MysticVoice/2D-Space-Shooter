using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(ThrusterController))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private ThrusterController tc;
    public Skill skill;
    public Fire fire;
    public float firerate;

    private bool shiftInput;
    private bool fireInput;
    private int waitFrames;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tc = GetComponent<ThrusterController>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) shiftInput = true;
        if (Input.GetButton("Fire1")) fireInput = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tc.thrust(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),Input.GetAxis("Strafe"));
        if (shiftInput)
        {
            skill.use();
            shiftInput = false;
        }
        if (fireInput && waitFrames == 0)
        {
            fire.fire();
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
