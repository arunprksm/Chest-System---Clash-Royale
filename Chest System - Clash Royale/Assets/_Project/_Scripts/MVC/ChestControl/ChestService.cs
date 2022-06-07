using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGenerics<ChestService>
{
    public ChestController selectedController;
    //public float unlockTimer;

    private void Start()
    {
        InitializeOnStart();
    }
    private void Update()
    {
        
    }
    private void InitializeOnStart()
    {
        ChestSystemManager.Instance.ChestPopUp.SetActive(false);
        ChestSystemManager.Instance.SpwanChestButton.SetActive(true);
        ChestSystemManager.Instance.ChestSlots.SetActive(true);
    }

    public ChestController GetChest(ChestScriptableObject ChestScriptableObject, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(ChestScriptableObject);
        ChestController chestController = new ChestController(chestView, chestModel);
        return chestController;
    }

    public void OnClickStartTimer()
    {
        selectedController.EnteringUnlockingState();
        ChestSystemManager.Instance.CloseUnlockChestPopup();
    }

    public void UseGemsButton()
    {
        if(CurrencyManager.Instance.gems > selectedController.GetGemCost())
        {
            CurrencyManager.Instance.DecreaseGems(valueToDecrease: selectedController.GetGemCost());
            OpenNowButton();
        }
        else if(CurrencyManager.Instance.gems < selectedController.GetGemCost())
        {
            Debug.Log("Gem Is Not Enough");
        }
    }
    public void OpenNowButton()
    {
        selectedController.EnteringUnlockedState();
        ChestSystemManager.Instance.CloseButton();
    }
    public void EnableRewardsPopup(bool setActive)
    {
        if (!setActive)
        {
            selectedController = null;
        }
        else
        {
            //ChestSystemManager.Instance.rewardReceivedText.text = "You received " + selectedController.ChestModel.CoinsReward + " coins and " + selectedController.ChestModel.GemsReward + " gems.";
        }
        //ChestSystemManager.Instance.rewardPopup.SetActive(setActive);
    }
}
