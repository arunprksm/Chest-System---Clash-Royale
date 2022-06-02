using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChestView : MonoBehaviour
{
    public ChestController ChestController;
    
    public GameObject EmptyChestBox;
    public GameObject FillChestBox;
    public Button FillChestButton;
    public TextMeshProUGUI ChestTypeName;
    public TextMeshProUGUI TimerText;

    internal ChestState currentState;

    public SlotView slotView;


    private void Start()
    {
        InitializeEmptyChestFunction();
    }
    private void Update()
    {
       
    }
    public void InitializeEmptyChestFunction()
    {
        EmptyChestBox.SetActive(true);
        FillChestBox.SetActive(false);
        FillChestButton.image.sprite = null;
        currentState = ChestState.None;
    }
    public void ChestButtonClick()
    {
        ChestController.ChestButtonClickController();
    }
}
