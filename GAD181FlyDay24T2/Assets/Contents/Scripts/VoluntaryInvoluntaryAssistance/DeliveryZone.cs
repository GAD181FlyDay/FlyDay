using TMPro;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// The area where players deliver luggages to. (Inspired by OC2's delivery zone lol.)
    /// </summary>

    public class DeliveryZone : MonoBehaviour
    {
        #region Variables.
        public int score = 0;
        public TMP_Text scoreText;

        [SerializeField] private OrderManager orderManager;
        #endregion

        private void Start()
        {
            UpdateScoreText();
        }

        #region Private Functions.
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Luggage"))
            {
                Luggage luggage = other.GetComponent<Luggage>();
                bool matched = false;

                for (int i = 0; i < orderManager.activeOrders.Count; i++)
                {
                    if (orderManager.activeOrders[i].luggageType == luggage.luggageType)
                    {
                        matched = true;
                        orderManager.activeOrders.RemoveAt(i);
                        Destroy(other.gameObject);
                        score++;
                        break;
                    }
                }

                if (!matched)
                {
                    score--;
                    Destroy(other.gameObject);
                }

                UpdateScoreText();
            }
        }

        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + score;
        }
        #endregion
    }
}