using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : SingletonGenerics<Timer>
{
    private float secondsLeft;
    public float timeToWait = 10000f;
    public Button chestButton;
    public TextMeshProUGUI chestTimer;

    private ulong lastChestOpen;
    private void Start()
    {
        //CheckChestLastOpen();
        chestTimer = GetComponentInChildren<TextMeshProUGUI>();
        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));
        if (!IsChestReady())
        {
            chestButton.interactable = false;
        }
    }

    //private void CheckChestLastOpen()
    //{
    //    PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
    //    if (lastChestOpen == 0)
    //    {
    //        lastChestOpen = (ulong)DateTime.Now.Ticks;
    //    }
    //}

    private void Update()
    {
        //Debug.Log("Last Chest Open " + lastChestOpen);
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
                return;
            }
            //set The Timer

            float minutes = Mathf.FloorToInt((int)GetTimerCount() / 60);
            float seconds = Mathf.FloorToInt((int)GetTimerCount() % 60);

            chestTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //string r = "";
            ////Hours
            //r += ((int)GetTimerCount() / 3600).ToString("00") + "h ";
            //secondsLeft -= ((int)GetTimerCount() / 3600) * 3600;
            ////Minutes
            //r += ((int)GetTimerCount() / 60).ToString("00") + "m ";
            ////Seconds
            //r += ((int)GetTimerCount() % 60).ToString("00") + "s";

            //chestTimer.text = r;

        }
    }

    public void OnClick()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
        chestButton.interactable = false;
    }
    private bool IsChestReady()
    {
        //ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        //ulong m = (ulong)diff / TimeSpan.TicksPerMillisecond;
        //float secondsLeft = (float)(timeToWait - m) / 1000.0f;

        //if (secondsLeft < 0)
        if (GetTimerCount() < 0)
        {
            chestTimer.text = "Start Timer";
            return true;
        }
        return false;
    }

    private float GetTimerCount()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = (ulong)diff / TimeSpan.TicksPerMillisecond;
        secondsLeft = (float)(timeToWait - m) / 1000.0f;
        return secondsLeft;
    }

    //public void SetTimerCount(float _secondsLeft)
    //{
    //    secondsLeft = _secondsLeft;
    //}

    public void ClickDeleteSave()
    {
        PlayerPrefs.DeleteAll();
        lastChestOpen = (ulong)DateTime.Now.Ticks;
    }
}
