using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    public abstract GameObject fire(bool input, LayerMask whatIsTarget);
}
