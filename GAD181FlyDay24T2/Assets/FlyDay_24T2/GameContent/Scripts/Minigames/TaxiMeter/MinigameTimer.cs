using TMPro;
using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for the minigame's 
    /// timer and overall game duration.
    /// </summary>
    public class MinigameTimer : MonoBehaviour
    {
        #region Variables
        public bool gameEnded = false;
        public NotesSpawner noteSpawner;
        public float gameDuration = 90f; // 1 and a half minutes.

        [SerializeField] private PlayerSaveData playerSaveData;
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
            else if (remainingTime <= 30f)
            {
                noteSpawner.initialMinSpawnInterval = Mathf.Lerp(1f, 0.5f, (30f - remainingTime) / 30f);
                noteSpawner.initialMaxSpawnInterval = Mathf.Lerp(2f, 1f, (30f - remainingTime) / 30f);
            }

            // Update the timer display
            int minutes = Mathf.FloorToInt(remainingTime / 60F);
            int seconds = Mathf.FloorToInt(remainingTime % 60F);

            string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = "Time: " + timeText;
        }

        private void EndMiniGame()
        {
            gameEnded = true;
            timerText.text = "Time: 0";
            playerSaveData.mainLuckyCoinsSource -= TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue;
            Debug.Log("Here is your money despite the loss " + playerSaveData.mainLuckyCoinsSource);

            if (TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue > 100)
            {
                endGameText.text = ("Are Taxis usually this expensive?" + " You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
            }
            else
            {
                endGameText.text = ("Not a bad price for a long Taxi ride!, You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
            }
        }
        #endregion
    }
}
