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
        public int luckyCoins = 100; // Temporary variable until the coin system is fully integrated within the game.
        public int goodGiftPrice = 50;
        public int badGiftPrice = 20;
        public PurchasedItemData purchasedItemData;
        public Button goodGiftButton;
        public Button badGiftButton;
        public GameObject shopPanel;
        #endregion

        private void Start()
        {
            UpdateShopState();
        }

        #region Public Functions.
        public void PurchaseGoodGift()
        {
            if (!purchasedItemData.hasPurchased && luckyCoins >= goodGiftPrice)
            {
                luckyCoins -= goodGiftPrice;
                purchasedItemData.purchasedItem = "goodGift";
                purchasedItemData.hasPurchased = true;
                Debug.Log("Purchased good gift");
                LockShop();
            }
        }

        public void PurchaseBadGift()
        {
            if (!purchasedItemData.hasPurchased && luckyCoins >= badGiftPrice)
            {
                luckyCoins -= badGiftPrice;
                purchasedItemData.purchasedItem = "badGift";
                purchasedItemData.hasPurchased = true;
                Debug.Log("Purchased bad gift");
                LockShop();
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
        #endregion
    }
}