using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    public static GameCycle instance;
    public enum Statement 
    {
        Waiting,
        Game,
        Pause
    }

    public Statement _statement;
    public Statement statement 
    {
        get 
        {
            return _statement;
        }
        set 
        {
            if (_statement == Statement.Waiting)
            {
                if (value == Statement.Game) 
                {
                    UIManager.instance.animatorPanelStartScreen.SetTrigger("Hide");
                }
            }
            _statement = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        statement = Statement.Waiting;
    }

    public void Win() 
    {
        UIManager.instance.animatorPanelWin.SetTrigger("Show");
    }
}
