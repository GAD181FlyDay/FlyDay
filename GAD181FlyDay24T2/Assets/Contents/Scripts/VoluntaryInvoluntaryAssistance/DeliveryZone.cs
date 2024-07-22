using TMPro;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// The area where players deliver luggages to. (Inspired by OC2's delivery zone lol.)
    /// </summary>

    public class DeliveryZone : MonoBehaviour
    {
        #region Variables
        public int luckyCoins = 0;
        public TMP_Text scoreText;
        [SerializeField] private OrderManager orderManager;
        #endregion

        private void Start()
        {
            UpdateScoreText();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Luggage"))
            {
                Luggage luggage = other.GetComponent<Luggage>();
                if (luggage != null)
                {
                    HandleLuggageDelivery(luggage);
                    other.gameObject.SetActive(false);
                }
            }
        }

        #region Private Functions
        private void HandleLuggageDelivery(Luggage luggage)
        {
            bool matched = false;

            for (int i = 0; i < orderManager.activeOrders.Count; i++)
            {
                if (orderManager.activeOrders[i].luggageType == luggage.luggageType)
                {
                    matched = true;
                    orderManager.CompleteOrder(i);
                    luckyCoins += 5;
                    break;
                }
            }

            if (!matched)
            {
                luckyCoins--;
            }

            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Coins: " + luckyCoins;
            }
        }
        #endregion
    }
}