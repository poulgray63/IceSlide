using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Level : MonoBehaviour
{
    [SerializeField]
    private GameObject staticContainer;
    private void Awake()
    {
        if (staticContainer != null)
        {
            StaticBatchingUtility.Combine(staticContainer);
        }
    }
}
