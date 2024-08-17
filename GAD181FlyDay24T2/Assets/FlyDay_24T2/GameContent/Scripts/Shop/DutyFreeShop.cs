using Narrative;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DutyFree
{
    /// <summary>
    /// Purchase logic! 
    /// if players have enugh money then they can purchase somethin.
    /// After they purchase somethin, they cant purchase anything else and the shop locks.
    /// </summary>

    public class DutyFreeShop : MonoBehaviour
    {
        #region Variables
        public PlayerSaveData playerSaveData;
        public int goodGiftPrice = 350;
        public int badGiftPrice = 225;
        public PurchasedItemData purchasedItemData;
        public Button goodGiftButton;
        public Button badGiftButton;
        public GameObject shopPanel;
        public StateManager stateManager;
        public NarrativeStateStorage stateStorage;

        [SerializeField] private TMP_Text cantPurchase;
        #endregion

        private void Start()
        {
            UpdateShopState();
        }

        #region Public Functions.
        public void PurchaseGoodGift()
        {
            Debug.Log("Button works");
            if (!purchasedItemData.hasPurchased && playerSaveData.mainLuckyCoinsSource >= goodGiftPrice)
            {
                playerSaveData.currentStateInt = 5;
                stateManager.currentState = stateStorage;
                // Debug.Log(playerSaveData.currentStateInt);
                playerSaveData.mainLuckyCoinsSource -= goodGiftPrice;
                purchasedItemData.purchasedItem = "goodGift";
                purchasedItemData.hasPurchased = true;
                // Debug.Log(purchasedItemData.purchasedItem);

                LockShop();
            }
            else
            {
                cantPurchase.text = " You don't have enough money to purchase. ";
                Invoke("HideText", 1f);
            }
        }

        public void PurchaseBadGift()
        {
            Debug.Log("Button works");
            if (!purchasedItemData.hasPurchased && playerSaveData.mainLuckyCoinsSource >= badGiftPrice)
            {
                playerSaveData.currentStateInt = 5;
                stateManager.currentState = stateStorage;
                // Debug.Log(playerSaveData.currentStateInt);
                playerSaveData.mainLuckyCoinsSource -= badGiftPrice;
                purchasedItemData.purchasedItem = "badGift";
                purchasedItemData.hasPurchased = true;
                // Debug.Log("Purchased bad gift");
                LockShop();
            }
            else
            {
                cantPurchase.text = " You don't have enough money to purchase. ";
                Invoke("HideText", 1f);
            }
        }
        #endregion

        #region Private Functions.
        private void LockShop()
        {
            goodGiftButton.interactable = false;
            badGiftButton.interactable = false;
            shopPanel.layer = LayerMask.NameToLayer("UI"); // Changed it to a non interactable layer so that players can't interact with it no more.
        }


        private void UpdateShopState()
        {
            if (purchasedItemData.hasPurchased)
            {
                LockShop();
            }
        }

        private void HideText()
        {
            cantPurchase.text = "";
        }
        #endregion
    }
}