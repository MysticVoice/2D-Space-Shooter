using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionVFXController : MonoBehaviour
{
    public float explosionTime = 2;
    public VisualEffect vfx;
    private float timer;
    void Start()
    {
        enabled = true;
        sendStart();
        timer = Time.time + explosionTime;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        sendStart();
        timer = Time.time+explosionTime;
    }

    void Update()
    {
        if (timerCheck())
        {
            sendStop();
            enabled = false;
        }
    }
    void sendStart()
    {
        vfx.SendEvent("OnPlay");
    }

    void sendStop()
    {
        vfx.SendEvent("OnStop");
    }

    bool timerCheck()
    {
        return timer < Time.time;
    }
}
