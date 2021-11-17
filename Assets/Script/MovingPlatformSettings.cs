using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSettings : MonoBehaviour
{
    public static MovingPlatformSettings movingPlatformSettings;

    public AnimationCurve curveDefault;

    private void Awake()
    {
        movingPlatformSettings = this;
    }
}
