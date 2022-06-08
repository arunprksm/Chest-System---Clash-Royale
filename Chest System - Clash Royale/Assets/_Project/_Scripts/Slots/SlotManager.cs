using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonGenerics<SlotManager>
{
    [SerializeField] private SlotView[] Slots;
    [SerializeField] private ChestScriptableObjectLists ChestScriptableObjectLists;
    public bool isUnlocking;

    public void SpawnRandomChestOnClick()
    {
        int slot = CheckSlotIsEmpty();
        if (slot == -1)
        {
            //UIHandler.Instance.ToggleSlotsFullPopup(true);
            Debug.Log("Slots are Full" + slot);
            return;
        }
        Debug.Log("Slots are Filling " + slot);
        Slots[slot].SpawnRandomChest(ChestScriptableObjectLists.ChestLayouts[Random.Range(0, ChestScriptableObjectLists.ChestLayouts.Length)].ChestScriptableObject);
    }

    private int CheckSlotIsEmpty()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Slots[i].chestIsEmpty)
            {
                return i;
            }
        }
        return -1;
    }
}
