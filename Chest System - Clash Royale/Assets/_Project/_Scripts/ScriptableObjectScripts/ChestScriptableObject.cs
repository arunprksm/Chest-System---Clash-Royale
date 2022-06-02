using UnityEngine;


[CreateAssetMenu(fileName ="Chest Scriptable Object", menuName = "ScriptableObjects/Chests/Create New Chest Scriptable Object")]
public class ChestScriptableObject : ScriptableObject
{
    public string ChestName;
    public string ChestTypeName;
    public Sprite ChestSprite;
    public int MinCoins;
    public int MaxCoins;
    public int MinGems;
    public int MaxGems;
    public string ChestPopUp_CoinValue;
    public string ChestPopUp_GemValue;
    public float UnlockTimer;
}
