using TMPro;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Handles timer for the game.
    /// </summary>

    public class TimerAndManager : MonoBehaviour
    {
        #region Variables
        public float gameDuration = 180f;
        public TMP_Text timerText;
        public DeliveryZone deliveryZone;

        private float _timeRemaining;
        #endregion

        private void Start()
        {
            _timeRemaining = gameDuration;
        }

        private void Update()
        {
            _timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(_timeRemaining).ToString();

            if (_timeRemaining <= 0)
            {
                EndGame();
            }
        }

        #region Private Functions.
        private void EndGame()
        {
            Debug.Log("Game Over! Score: " + deliveryZone.score);
            // might change this to another script.
        }
        #endregion
    }
}