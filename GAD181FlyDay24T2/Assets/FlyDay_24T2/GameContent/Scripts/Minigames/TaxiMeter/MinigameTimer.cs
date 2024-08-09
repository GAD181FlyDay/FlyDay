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
            playerSaveData.mainLuckyCoinsSource -= TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue;
            Debug.Log("Here is your money despite the loss " + playerSaveData.mainLuckyCoinsSource);

            if (TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue > 100)
            {
                endGameText.text = ("Are Taxis usually this expensive?" + " You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
                // Debug.Log("Are Taxis usually this expensive?" + " You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
            }
            else
            {
                endGameText.text = ("Not a bad price for a long Taxi ride!, You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
                // Debug.Log("Not a bad price for a long Taxi ride!, You paid the driver " + TaxiMeterBaseLogic.taxiMeterBaseLogic.meterValue + " Lucky Coins");
            }

        }
        #endregion
    }
}