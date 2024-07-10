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
        [SerializeField] private MinigameManager minigameManager;
        private float _remainingTime; // Remaining game time which helps with timer calculations.
        
        #endregion

        private void Start()
        {
            _remainingTime = gameDuration;
            UpdateTimerText();
        }

        private void Update()
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                UpdateTimerText();

                if (_remainingTime <= 0)
                {
                    minigameManager.EndGame();
                }
            }
        }

        #region Private Functions

        private void UpdateTimerText()
        {
            timerText.text = "Time: " + Mathf.Max(0, _remainingTime).ToString("0.00");
        }

        #endregion
    }
}