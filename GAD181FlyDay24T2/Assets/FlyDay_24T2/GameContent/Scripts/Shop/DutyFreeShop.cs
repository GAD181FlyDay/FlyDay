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
                playerSaveData.mainLuckyCoinsSource -= goodGiftPrice;
                purchasedItemData.purchasedItem = "goodGift"; // Note to self, make it so that if its goodGift string then the proceed after boarding sets the int to 4, else to 5.
                purchasedItemData.hasPurchased = true;
                Debug.Log("Purchased good gift");
                playerSaveData.currentStateInt = 5;
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
                playerSaveData.mainLuckyCoinsSource -= badGiftPrice;
                purchasedItemData.purchasedItem = "badGift";
                purchasedItemData.hasPurchased = true;
                Debug.Log("Purchased bad gift");
                playerSaveData.currentStateInt = 5;
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