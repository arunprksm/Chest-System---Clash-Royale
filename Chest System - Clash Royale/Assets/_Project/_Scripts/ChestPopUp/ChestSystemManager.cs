using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChestSystemManager : SingletonGenerics<ChestSystemManager>
{
    [SerializeField] internal GameObject ChestPopUp;
    [SerializeField] internal GameObject ChestSlots;
    [SerializeField] internal GameObject SpwanChestButton;

    [SerializeField] private TextMeshProUGUI valueOfCoins;
    [SerializeField] private TextMeshProUGUI valueOfGems;
    [SerializeField] private GameObject chestSlotsFullPopup;
    [SerializeField] private GameObject busyUnlockingPopup;
    [SerializeField] private GameObject unlockChestPopup;
    [SerializeField] private GameObject insufficientCurrenciesPopup;
    [SerializeField] public GameObject rewardPopup;
    [SerializeField] public TextMeshProUGUI rewardReceivedText;

    public void EnableSlotsFullPopup(bool setActive)
    {
        chestSlotsFullPopup.SetActive(setActive);
    }
    public void EnableIsBusyUnlockingPopup(bool setActive)
    {
        busyUnlockingPopup.SetActive(setActive);
    }
    public void ToggleUnlockChestPopup()
    {
        unlockChestPopup.SetActive(false);
        SpwanChestButton.SetActive(true);
        ChestSlots.SetActive(true);
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }

    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void ToggleInsufficientResourcesPopup(bool setActive)
    {
        insufficientCurrenciesPopup.SetActive(setActive);
    }
}
