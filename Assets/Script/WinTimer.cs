using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTimer : MonoBehaviour
{
    public static WinTimer instance;
    [SerializeField] private Animator animator;
    private Coroutine timerTick;
    private int _timerCount = 3;
    private int timerCount 
    {
        get { return _timerCount; }
        set 
        {
            _timerCount = value;
            UIManager.instance.textWinTimer.text = value.ToString();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator TimerTick() 
    {
        yield return new WaitForSeconds(1f);
        timerCount--;
        animator.SetTrigger("Tick");
        if (timerCount == 0)
        {
            StopCoroutine(timerTick);
            GameCycle.instance.Win();
            UIManager.instance.textWinTimer.text = "WIN!";
        }
        else
        {
            timerTick = StartCoroutine(TimerTick());
        }
    }

    public void TimerStart()
    {
        timerCount = 3;
        UIManager.instance.textWinTimer.gameObject.SetActive(true);
        animator.SetTrigger("Tick");
        timerTick = StartCoroutine(TimerTick());
    }

    public void TimerStop()
    {
        UIManager.instance.textWinTimer.gameObject.SetActive(false);
        if (timerTick != null)
        {
            StopCoroutine(timerTick);
        }
    }
}
