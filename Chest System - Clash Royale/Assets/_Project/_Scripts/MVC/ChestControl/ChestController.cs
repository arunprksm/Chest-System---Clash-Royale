using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class ChestController
{
    public ChestView ChestView { get; }
    public ChestModel ChestModel { get; }
    public float timerValue;
    public ChestController(ChestView chestView, ChestModel chestModel)
    {
        ChestView = chestView;
        ChestModel = chestModel;
        ChestView.ChestController = this;
        InitializeLockedChestFunction();
        ChestView.unlockTimer = ChestModel.UnlockTimer;
    }

    public void InitializeLockedChestFunction()
    {
        ChestView.EmptyChestBox.SetActive(false);
        ChestView.FillChestBox.SetActive(true);
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite;
        ChestView.ChestTypeName.text = ChestModel.ChestTypeName.ToString();
        ChestView.TimerText.text = "Start timer";
        ChestView.currentState = ChestState.Locked;
    }
    public void InitializeUnLockingChestFunction()
    {
        ChestView.EmptyChestBox.SetActive(false);
        ChestView.FillChestBox.SetActive(true);
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite;
        ChestView.currentState = ChestState.Unlocking;
    }

    public void InitializeUnLockedChestFunction()
    {
        ChestView.EmptyChestBox.SetActive(false);
        ChestView.FillChestBox.SetActive(true);
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite;
        ChestView.currentState = ChestState.Unlocked;
    }
    public void ChestButtonClickController()
    {

        if (ChestView.currentState == ChestState.Locked)
        {
            ChestService.Instance.selectedController = this;
            ChestSystemManager.Instance.SpwanChestButton.SetActive(false);
            //ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel, ChestView);
            ChestSystemManager.Instance.ChestSlots.SetActive(false);
            ChestSystemManager.Instance.ChestPopUp.SetActive(true);
            ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel, ChestView);
        }
        else if (ChestView.currentState == ChestState.Unlocking)
        {
            ChestService.Instance.selectedController = this;
            ChestSystemManager.Instance.OpenUnlockChestPopupUnlocking();
            ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel, ChestView);
        }
        else if (ChestView.currentState == ChestState.Unlocked)
        {
            //--------------------------------------
            //--------------------------------------
            //--------------------------------------
            ChestService.Instance.selectedController = this;
            OpenChest();
        }
    }

    public void EnteringUnlockingState()
    {
        ChestView.TimerRunning = true;
        SlotManager.Instance.isUnlocking = true;
        InitializeUnLockingChestFunction();
        TimerStartFunction();
    }
    public void EnteringUnlockedState()
    {
        ChestView.TimerRunning = false;
        ChestView.unlockTimer = 0f;
        SlotManager.Instance.isUnlocking = false;
        InitializeUnLockedChestFunction();
        ChestView.TimerText.text = "OPEN CHEST!";
    }
    public void TimerCountFunction()
    {
        ChestView.unlockTimer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt((int)ChestView.unlockTimer / 60);
        float seconds = Mathf.FloorToInt((int)ChestView.unlockTimer % 60);
        ChestView.TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //ChestPopUpScript.Instance.ChestPopUpUnlocking_TimerText.text = ChestView.TimerText.text;
        //ChestView.IsTimerRunning = PlayerPrefs.GetFloat("Timer", ChestView.unlockTimer);
    }
    public async void TimerStartFunction()
    {
        TimeSpan Ts = TimeSpan.FromSeconds(ChestView.unlockTimer);
        //ChestView.TimerText.text = Ts.ToString();
        await Task.Delay(Ts);
        if (ChestView.currentState == ChestState.Unlocking)
        {
            EnteringUnlockedState();
        }
        //Debug.Log("Timer Works");
    }

    public void OpenChest()
    {
        ChestView.InitializeEmptyChestFunction();
        ReceiveChestRewards();
        ChestView.slotView.chestIsEmpty = true;
        ChestView.slotView.chestController = null;
    }

    public void ReceiveChestRewards()
    {
        CurrencyManager.Instance.IncreaseCoins(ChestModel.CoinsReward);
        CurrencyManager.Instance.IncreaseGems(ChestModel.GemsReward);
    }
    public int GetGemCost()
    {
        //ChestView.unlockTimer = ChestModel.UnlockTimer;
        return (int)Mathf.Ceil(ChestView.unlockTimer / 2);
    }
}