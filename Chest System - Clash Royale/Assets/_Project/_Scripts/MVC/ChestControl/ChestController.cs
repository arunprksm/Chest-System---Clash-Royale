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
    public float unlockTimer = 0;

    public ChestController (ChestView chestView, ChestModel chestModel)
    {
        ChestView = chestView;
        ChestModel = chestModel;
        ChestView.ChestController = this;
        Timer.Instance.ChestView = chestView;
        ChestService.Instance.selectedController = this;
        InitializeLockedChestFunction();
        unlockTimer = ChestModel.UnlockTimer;
        Timer.Instance.timeValue = ChestModel.UnlockTimer;
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
            ChestSystemManager.Instance.SpwanChestButton.SetActive(false);
            ChestSystemManager.Instance.ChestSlots.SetActive(false);
            ChestSystemManager.Instance.ChestPopUp.SetActive(true);
            ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel);
        }
        else if (ChestView.currentState == ChestState.Unlocking)
        {
            //--------------------------------------
            //--------------------------------------
            //--------------------------------------
        }
        else if (ChestView.currentState == ChestState.Unlocked)
        {
            //--------------------------------------
            //--------------------------------------
            //--------------------------------------

            OpenChest();
        }
    }

    public void EnteringUnlockingState()
    {
        SlotManager.Instance.isUnlocking = true;
        InitializeUnLockingChestFunction();
        TimerStartFunction();
    }
    public void EnteringUnlockedState()
    {
        SlotManager.Instance.isUnlocking = false;
        InitializeUnLockedChestFunction();
        ChestView.TimerText.text = "OPEN!";
    }
    public async void TimerStartFunction()
    {
        TimeSpan Ts = TimeSpan.FromSeconds(unlockTimer);
        ChestView.TimerText.text = Ts.ToString();
        await Task.Delay(Ts);
        EnteringUnlockedState();
        Debug.Log("Timer Works");

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
        unlockTimer = ChestModel.UnlockTimer;
        return (int)Mathf.Ceil(unlockTimer / 2);
    }
}
    //public async void StartTimer()
    //{

    //if (unlockTimer > 0)
    //    {
    //        unlockTimer -= Time.deltaTime;
    //        Debug.Log(unlockTimer);
    //        ChestView.TimerText.text = unlockTimer.ToString();
    //    }
        //unlockTimer = 0;
    //    while (unlockTimer > 0)
    //    {
    //        ChestView.TimerText.text = unlockTimer.ToString() + " s";
    //        //await new WaitForSeconds(1f);
    //        unlockTimer -= 1;
    //    }
    //    EnteringUnlockedState();
    //    return;
    //}
