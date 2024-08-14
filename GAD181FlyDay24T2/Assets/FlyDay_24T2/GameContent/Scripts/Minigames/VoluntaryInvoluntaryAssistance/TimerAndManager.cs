using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Handles timer and End Game logic for the game.
    /// </summary>
    
    public class TimerAndManager : MonoBehaviour
    {
        #region Variables
        public float gameDuration = 120f;
        public TMP_Text timerText;
        [SerializeField] private DeliveryZone deliveryZone;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private GameObject timerTextComponent;
        [SerializeField] private TMP_Text endGameText;
        [SerializeField] private PlayerSaveData playerSaveData;

        private float _timeRemaining;
        private bool _isGameActive;
        #endregion

        private void Start()
        {
            Cursor.visible = false;
            _timeRemaining = gameDuration;
            _isGameActive = true;
            endGamePanel.SetActive(false);
        }

        private void Update()
        {
            if (_isGameActive)
            {
                _timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(_timeRemaining);

                if (_timeRemaining <= 0)
                {
                    EndGame();
                }
            }
        }

        #region Private Functions
        private void UpdateTimerDisplay(float timeRemaining)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void EndGame()
        {
            playerSaveData.currentStateInt = 4;
            _isGameActive = false;
            endGamePanel.SetActive(true);
            endGameText.text = "Game Over! You Earned: " + deliveryZone.luckyCoins;
            playerSaveData.mainLuckyCoinsSource += deliveryZone.luckyCoins;
            timerTextComponent.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f; 
        }

        public void Proceed()
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            SceneManager.LoadScene("MainGameScene");
        }
        #endregion
    }
}