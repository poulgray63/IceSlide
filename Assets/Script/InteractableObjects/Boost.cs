using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = TagManager.instance.boost;
    }
}
