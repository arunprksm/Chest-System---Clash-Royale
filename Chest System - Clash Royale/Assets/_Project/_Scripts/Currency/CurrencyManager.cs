using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : SingletonGenerics<CurrencyManager>
{
    public int coins;
    public int gems;


    private void Start()
    {
        coins = 100;
        gems = 100;
        ChestSystemManager.Instance.UpdateGemsUI(gems);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void IncreaseGems(int valueToIncrease)
    {
        gems += valueToIncrease;
        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
}
