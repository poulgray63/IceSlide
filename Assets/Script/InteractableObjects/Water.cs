using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = TagManager.instance.water;
    }
}
