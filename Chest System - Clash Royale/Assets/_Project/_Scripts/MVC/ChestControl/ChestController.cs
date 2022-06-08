using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    public ChestView ChestView { get; }
    public ChestModel ChestModel { get; }
    public float unlockTimer = 0f;



    public ChestController (ChestView chestView, ChestModel chestModel)
    {
        ChestView = chestView;
        ChestModel = chestModel;
        ChestView.ChestController = this;
        OnEnableFunction();
        unlockTimer = ChestModel.UnlockTimer;
    }

    public void OnEnableFunction()
    {
        ChestView.EmptyChestBox.SetActive(false);
        ChestView.FillChestBox.SetActive(true);
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite;

        ChestView.currentState = ChestState.Unlocked;
    }


    public int GetGemCost()
    {
        unlockTimer = ChestModel.UnlockTimer;
        return (int)Mathf.Ceil(unlockTimer / 2);
    }
}
