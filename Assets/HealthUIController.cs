using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    private Image im;
    private RectTransform rt;
    public float sizeMultiplier = 200f;

    void Start()
    {
        im = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(GameController.Instance.playerHealth.normalizedHealth()*sizeMultiplier,rt.sizeDelta.y);
    }

    
}
