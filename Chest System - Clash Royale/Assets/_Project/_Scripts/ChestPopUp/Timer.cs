using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingletonGenerics<Timer>
{
    public Button chestButton;
    private ulong lastChestOpen;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        chestButton.interactable = true;

        //if (lastChestOpen != 0)
        //lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));

    }
    private void Update()
    {
        if (!chestButton.IsInteractable())
        {
            ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
            ulong m = (ulong)diff / TimeSpan.TicksPerMillisecond;

            //float secondsLeft = (float)(3000 - m) / 1000;
            //if (secondsLeft < 0)
            //{

            //}
        }
    }

    public void OnClick()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
        chestButton.interactable = false;
    }
}
