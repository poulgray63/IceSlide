using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = TagManager.instance.spike;
    }
}
