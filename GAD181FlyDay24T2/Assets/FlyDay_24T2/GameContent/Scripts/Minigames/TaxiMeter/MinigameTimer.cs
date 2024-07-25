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
        public bool gameEnded = false;
        public NotesSpawner noteSpawner;
        public float gameDuration = 120f; // 2 minutes

        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text endGameText;

        private float elapsedTime = 0f;
        
        #endregion

        void Update()
        {
            TakeActionWhenTheMiniGameHasEnded();
        }

        #region Private Functions
        private void TakeActionWhenTheMiniGameHasEnded()
        {
            if (gameEnded) return;

            elapsedTime += Time.deltaTime;
            float remainingTime = gameDuration - elapsedTime;

            if (remainingTime <= 0)
            {
                EndMiniGame();
            }
            else if (remainingTime <= 60f)
            {
                noteSpawner.spawnInterval = Mathf.Lerp(1f, 0.5f, (60f - remainingTime) / 60f); // Speed up notes in the last minute
            }

            timerText.text = "Time: " + Mathf.CeilToInt(remainingTime).ToString();
        }

        private void EndMiniGame()
        {
            gameEnded = true;
            timerText.text = "Time: 0";
            // Handle end of the game, like showing results, etc.
            if (TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue > 100)
            {
                Debug.Log("Game Ended. You owe the Taxi driver: 100 lucky coins");
            }
            else
            {
                Debug.Log("Game Ended. Final Meter Value: " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue);
            }

        }
        #endregion
    }
}