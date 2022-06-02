using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChestPopUpScript : SingletonGenerics<ChestPopUpScript>
{
    public TextMeshProUGUI ChestPopUp_Heading;
    public Button ChestPopUp_Close;
    public TextMeshProUGUI ChestPopUp_CoinValue;
    public TextMeshProUGUI ChestPopUp_GemValue;
    public Button ChestPopUp_OpenNow;
    public Button ChestPopUp_StartTimer;

    public void SetChestPopUpValues(ChestModel _chestModel)
    {
        ChestPopUp_Heading.text = _chestModel.ChestName;
        ChestPopUp_CoinValue.text = _chestModel.ChestPopUp_CoinValue;
        ChestPopUp_GemValue.text = _chestModel.ChestPopUp_GemValue;
    }
}
