using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    public ChestView ChestView;
    public bool chestIsEmpty;
    public ChestController chestController;

    private void Start()
    {
        ChestView.slotView = this;
        chestIsEmpty = true;
    }

    public void SpawnRandomChest(ChestScriptableObject chestScriptableObject)
    {
        chestController = ChestService.Instance.GetChest(chestScriptableObject, ChestView);
        chestIsEmpty = false;
    }
}
