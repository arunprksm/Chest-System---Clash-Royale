using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingletonGenerics<Timer>
{
    public float timeValue;
    //public Text timerText;
    public ChestView ChestView;
    public static event Action OnTimer;
    public static event Action<ChestView, float> OnTimerDisplay;
    public void Update()
    {
        OnTimer?.Invoke();
        OnTimerDisplay?.Invoke(ChestView, timeValue);
        //DisplayTime(ChestView, timeValue);
    }

    public void TimerFunction()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
    }


    public void DisplayTime(ChestView ChestView, float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        ChestView.TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
