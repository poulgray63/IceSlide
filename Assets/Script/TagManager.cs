using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    public static TagManager instance;
    public string water;
    public string finish;
    public string spike;
    public string boost;

    private void Awake()
    {
        instance = this;
    }
}
