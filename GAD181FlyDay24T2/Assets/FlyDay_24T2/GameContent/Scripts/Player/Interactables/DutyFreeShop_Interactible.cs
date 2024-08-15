using DutyFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DutyFreeShop_Interactible : Scripts_InteractionBaseToOverride
{
    #region Variables
    public PurchasedItemData purchasedItemData;

    [SerializeField] private GameObject dutyFreeShop;
    [SerializeField] private GameObject dutyFreeShopPanel;
    [SerializeField] private PlayerInteractions playerInteractions;
    [SerializeField] private PlayerSaveData playerSaveData;

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
            playerSaveData.currentStateInt = 5;
            dutyFreeShop.tag = "Untagged";
            purchasedItemData.hasPurchased = false;
            Invoke("LoadBoardingScene", 3f);
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

    #region Private Functions
    private void LoadBoardingScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    #endregion
    // If an item has been bought set the duty free bool to true
    // if the duty free bool is true then players can't interact anymore with the shop
}
