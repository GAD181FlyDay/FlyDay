using TMPro;
using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for the minigame's 
    /// timer and overall game durtion.
    /// </summary>

    public class MinigameTimer : MonoBehaviour
    {
        #region Variables
        public float gameDuration = 120f; // The game is 2 minutes long for now.
        [SerializeField] private TMP_Text timerText; // UI to display the timer on, might remove it.
        private float _remainingTime; // Remaining game time which helps with timer calculations.
        #endregion

        private void Start()
        {
            // Remaining time variable assigned with a value.
            // Set the timer's text to the remaining time text.
            UpdateTimerText();
        }

        private void Update()
        {
            // Keeps checking if the timer has run out.
        }

        #region Private Functions

        private void UpdateTimerText()
        {
            // Timer text updator, if i decide to display the text :P.
        }

        private void EndGame()
        {
            // show end game panel which shows the final money loss.
        }

        #endregion
    }
}