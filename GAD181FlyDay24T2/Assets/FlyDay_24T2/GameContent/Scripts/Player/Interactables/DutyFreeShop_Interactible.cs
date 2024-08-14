using DutyFree;
using UnityEngine;

public class DutyFreeShop_Interactible : Scripts_InteractionBaseToOverride
{
    #region Variables
    [SerializeField] private GameObject dutyFreeShop;
    [SerializeField] private GameObject dutyFreeShopPanel;
    [SerializeField] private PlayerInteractions playerInteractions;
    public PurchasedItemData purchasedItemData;
    #endregion


    private void Update()
    {
        if (dutyFreeShopPanel.activeSelf == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (purchasedItemData.hasPurchased == true)
        {
            dutyFreeShop.tag = "Untagged";
        }
    }

    #region Public Functions.
    public override void Interact()
    {
        if (purchasedItemData.hasPurchased is false)
        {
            dutyFreeShopPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            dutyFreeShopPanel.SetActive(false);
            Debug.Log("Player has already purchased an item");
        }
    }

    public void ExitShopPanel()
    {
        dutyFreeShopPanel.SetActive(false);
    }
    #endregion

    // If an item has been bought set the duty free bool to true
    // if the duty free bool is true then players can't interact anymore with the shop
}
