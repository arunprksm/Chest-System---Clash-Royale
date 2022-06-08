using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChestPopUpScript : SingletonGenerics<ChestPopUpScript>
{
    public TextMeshProUGUI ChestPopUp_Heading;
    public TextMeshProUGUI ChestPopUp_CoinValue;
    public TextMeshProUGUI ChestPopUp_GemValue;
    public TextMeshProUGUI ChestPopUpUnlocking_Heading;
    public TextMeshProUGUI ChestPopUpUnlocking_CoinValue;
    public TextMeshProUGUI ChestPopUpUnlocking_GemValue;
    public TextMeshProUGUI ChestPopUpUnlocking_TimerText;

    //public Button ChestPopUp_Close;
    //public Button ChestPopUp_OpenNow;
    //public Button ChestPopUp_StartTimer;

    bool TimerRunning;
    ChestView ChestView;
    internal float unlockTimer;

    private void Update()
    {
        if (TimerRunning)
        {
            TimerText();
        }
    }
    private void LateUpdate()
    {
        if (TimerRunning)
        {
            ChestView.unlockTimer = unlockTimer;
        }
    }
    public void SetChestPopUpValues(ChestModel _chestModel, ChestView _chestView)
    {
        ChestPopUpUnlocking_Heading.text = ChestPopUp_Heading.text = _chestModel.ChestName;
        ChestPopUpUnlocking_CoinValue.text = ChestPopUp_CoinValue.text = _chestModel.ChestPopUp_CoinValue;
        ChestPopUp_GemValue.text = ChestPopUpUnlocking_GemValue.text = _chestModel.ChestPopUp_GemValue;
        TimerRunning = _chestView.TimerRunning;
        ChestView = _chestView;
        unlockTimer = ChestView.unlockTimer;
    }
    private void TimerText()
    {
        unlockTimer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt((int)unlockTimer / 60);
        float seconds = Mathf.FloorToInt((int)unlockTimer % 60);
        ChestPopUpUnlocking_TimerText.text = string.Format("Timer: " + "{0:00}:{1:00}", minutes, seconds);
    }
}
