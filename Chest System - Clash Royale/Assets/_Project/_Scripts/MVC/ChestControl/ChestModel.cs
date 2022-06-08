using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    public string ChestName { get; }
    public string ChestTypeName { get; }
    public Sprite ChestSprite { get; }
    public int MinCoins { get; }
    public int MaxCoins { get; }
    public int MinGems { get; }
    public int MaxGems { get; }
    public float UnlockTimer { get; }

    public string ChestPopUp_CoinValue { get; }
    public string ChestPopUp_GemValue { get; }
    public int CoinCost { get; }
    public int CoinsReward { get; }
    public int GemCost { get; }
    public int GemsReward { get; }
    public ChestModel(ChestScriptableObject chestScriptableObject)
    {
        ChestName = chestScriptableObject.ChestName;
        ChestTypeName = chestScriptableObject.ChestTypeName;
        ChestSprite = chestScriptableObject.ChestSprite;
        MinCoins = chestScriptableObject.MinCoins;
        MaxCoins = chestScriptableObject.MaxCoins;
        MinGems = chestScriptableObject.MinGems;
        MaxGems = chestScriptableObject.MaxGems;
        ChestPopUp_CoinValue = chestScriptableObject.ChestPopUp_CoinValue;
        ChestPopUp_GemValue = chestScriptableObject.ChestPopUp_GemValue;
        UnlockTimer = chestScriptableObject.UnlockTimer;
        CoinsReward = Random.Range(chestScriptableObject.MinCoins, chestScriptableObject.MaxCoins + 1);
        GemsReward = Random.Range(chestScriptableObject.MinGems, chestScriptableObject.MaxGems + 1);
    }
}
