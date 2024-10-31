using Narrative;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        public int goodGiftPrice = 350;
        public int badGiftPrice = 225;
        public Button goodGiftButton;
        public Button badGiftButton;
        public GameObject shopPanel;
        public StateManager stateManager;
        public NarrativeStateStorage stateStorage;

        [SerializeField] private TMP_Text cantPurchase;

        private PurchasedItemData purchasedItemData;
        private bool purchaseComplete = false; 
        #endregion

        private void Start()
        {
            purchasedItemData = PurchasedItemData.LoadData();
            UpdateShopState();
        }

        #region Public Functions.
        public void PurchaseGoodGift()
        {
            if (!purchaseComplete && !purchasedItemData.hasPurchased && DataManager.Instance.PlayerData.mainLuckyCoinsSource >= goodGiftPrice)
            {
                CompletePurchase("goodGift", goodGiftPrice);
                Invoke("LoadBlankLoadScene", 2f);
            }
            else
            {
                InsufficientCurrencyMessage();
            }
        }

        public void PurchaseBadGift()
        {
            if (!purchaseComplete && !purchasedItemData.hasPurchased && DataManager.Instance.PlayerData.mainLuckyCoinsSource >= badGiftPrice)
            {
                CompletePurchase("badGift", badGiftPrice);
                Invoke("LoadBlankLoadScene", 2f);
            }
            else
            {
                InsufficientCurrencyMessage();
            }
        }
        #endregion

        #region Private Functions.
        private void CompletePurchase(string item, int price)
        {
            DataManager.Instance.UpdateCoinAmount(-price);
            purchasedItemData.purchasedItem = item;
            purchasedItemData.hasPurchased = true;
            purchasedItemData.SaveData();

            purchaseComplete = true;
            LockShop();
        }

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

        private void InsufficientCurrencyMessage()
        {
            cantPurchase.text = "You don't have enough money to purchase.";
            Invoke("HideText", 1f);
        }

        private void HideText()
        {
            cantPurchase.text = "";
        }

        private void LoadBlankLoadScene()
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(10);
        }
        #endregion
    }
}
