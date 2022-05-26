using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel : MonoBehaviour
{
    public string ChestName { get; }
    public int MinCoins { get; }
    public int MaxCoins { get; }
    public int MinGems { get; }
    public int MaxGems { get; }
    public float UnlockTimer { get; }
    public ChestModel(ChestScriptableObject chestScriptableObject)
    {
        ChestName = chestScriptableObject.ChestName;
        MinCoins = chestScriptableObject.MinCoins;
        MaxCoins = chestScriptableObject.MaxCoins;
        MinGems = chestScriptableObject.MinGems;
        MaxGems = chestScriptableObject.MaxGems;
        UnlockTimer = chestScriptableObject.UnlockTimer;
    }
}
