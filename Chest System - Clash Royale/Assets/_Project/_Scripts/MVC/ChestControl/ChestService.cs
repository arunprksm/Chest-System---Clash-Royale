using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGenerics<ChestService>
{
    public ChestController selectedController;

    public ChestController GetChest(ChestScriptableObject randomChestSO, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(randomChestSO);
        ChestController chestController = new ChestController(chestView, chestModel);
        return chestController;
    }
}
