using Narrative;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for handling the minigame.
    /// It handles retrying and continuing with the narrative options.
    /// </summary>
    public class MinigameManager : MonoBehaviour
    {
        #region Variables
        public GameObject endGamePanel;
        [SerializeField] private MinigameTimer minigameTimer;

        private StateManager stateManager;
        #endregion

        private void Start()
        {
            endGamePanel.SetActive(false);
        }

        private void Update()
        {
            // If the script variable is empty then avoid progressing with the next lines.
            if (minigameTimer == null) return;

            // If the timer has stopped. (Reached zero)
            if (minigameTimer.gameEnded == true)
            {
                EndGame();
            }
        }

        #region Public Functions

        /// <summary>
        /// The following Functions are to be assigned to buttons.
        /// </summary>

        public void RetryGame()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ProceedWithStory()
        {
            DataManager.Instance.SetGameState(1);

            Time.timeScale = 1;
            SceneManager.LoadScene("MainGameScene");
        }

        #endregion

        #region Private Functions
        private void EndGame()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }

        #endregion
    }
}
