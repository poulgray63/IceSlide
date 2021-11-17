using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Animator animatorWinTimer;
    public Animator animatorPanelStartScreen;
    public Animator animatorPanelWin;
    public Text textWinTimer;
    public Text textLevel;
    public Text textFPS;
    public GameObject iconPromptHand;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        textFPS.text = "FPS: " + Mathf.RoundToInt(1 / Time.deltaTime);
    }
    public void OpenSettings() 
    {
        Light light = GameObject.Find("Directional Light").GetComponent<Light>();
        if (light.shadows == LightShadows.Hard)
        {
            light.shadows = LightShadows.None;
        }
        else 
        {
            light.shadows = LightShadows.Hard;
        }
    }
}
