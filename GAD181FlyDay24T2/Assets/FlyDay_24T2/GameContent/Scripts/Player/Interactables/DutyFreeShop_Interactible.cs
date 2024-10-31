using DutyFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DutyFreeShop_Interactible : Scripts_InteractionBaseToOverride
{
    #region Variables
    [SerializeField] private GameObject dutyFreeShop;
    [SerializeField] private GameObject dutyFreeShopPanel;
    [SerializeField] private PlayerInteractions playerInteractions;

    private PurchasedItemData purchasedItemData;
    #endregion

    private void Start()
    {
        // Load the purchased item data at the start
        purchasedItemData = PurchasedItemData.LoadData();
    }

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
            purchasedItemData.hasPurchased = false;
            purchasedItemData.SaveData();

            DataManager.Instance.SetGameState(5);

            Invoke("LoadBoardingScene", 2f);
        }
    }

    #region Public Functions
    public override void Interact()
    {
        if (!purchasedItemData.hasPurchased)
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
        SceneManager.LoadScene("BlankSceneRefresher");
    }
    #endregion
}
