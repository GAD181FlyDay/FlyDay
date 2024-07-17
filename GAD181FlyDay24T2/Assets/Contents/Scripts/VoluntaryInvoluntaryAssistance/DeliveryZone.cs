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

        #region Private Functions
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayersInteraction player = other.GetComponent<PlayersInteraction>();
                if (player == null) return;

                // Check if the player is holding luggage and a plate
                bool hasPlate = false;
                bool matched = false;

                foreach (GameObject luggageObj in player.GetHeldLuggage())
                {
                    Luggage luggage = luggageObj.GetComponent<Luggage>();
                    if (luggage != null && luggage.isOnPlate)
                    {
                        hasPlate = true;
                        break;
                    }
                }

                if (hasPlate)
                {
                    foreach (GameObject luggageObj in player.GetHeldLuggage())
                    {
                        Luggage luggage = luggageObj.GetComponent<Luggage>();
                        if (luggage == null) continue;

                        for (int i = 0; i < orderManager.activeOrders.Count; i++)
                        {
                            if (orderManager.activeOrders[i].luggageType == luggage.luggageType)
                            {
                                matched = true;
                                orderManager.activeOrders.RemoveAt(i);
                                player.RemoveLuggage(luggageObj);
                                luggageObj.SetActive(false);
                                score++;
                                break;
                            }
                        }

                        if (!matched)
                        {
                            score--;
                            player.RemoveLuggage(luggageObj);
                            luggageObj.SetActive(false);
                        }

                        UpdateScoreText();
                    }
                }
            }
        }

        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + score;
        }
        #endregion
    }
}