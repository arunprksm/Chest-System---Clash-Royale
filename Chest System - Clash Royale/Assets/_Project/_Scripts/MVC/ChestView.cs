using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChestView : MonoBehaviour
{
    public GameObject EmptyChestBox;
    public GameObject FillChestBox;
    public Button FillChestButton;
    public TextMeshProUGUI ChestType;
    public TextMeshProUGUI TimerText;

    private ChestState currentState;


    private void Start()
    {
        InitializeFunction();
    }

    private void InitializeFunction()
    {
        EmptyChestBox.SetActive(true);
        FillChestBox.SetActive(false);
        currentState = ChestState.None;
    }
}
