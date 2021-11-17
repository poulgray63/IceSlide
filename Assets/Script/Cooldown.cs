using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public void OnCooldown() 
    {
        ControlSystem.instance.canImpulse = true;
    }
}
