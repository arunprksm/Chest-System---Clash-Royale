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
    public TextMeshProUGUI ChestType;
    public TextMeshProUGUI TimerText;

    internal ChestState currentState;

    public SlotView slotView;


    private void Start()
    {
        InitializeFunction();
    }

    private void InitializeFunction()
    {
        EmptyChestBox.SetActive(true);
        FillChestBox.SetActive(false);
        //FillChestButton.image.sprite = null;
        currentState = ChestState.None;
    }
}
