using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        #endregion

        private void Start()
        {
            endGamePanel.SetActive(false); 
        }

        #region Public Functions
        public void EndGame()
        {
            endGamePanel.SetActive(true); 
            Time.timeScale = 0; 
        }

        public void RetryGame()
        {
            Time.timeScale = 1; 
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public void ProceedWithStory()
        {
            Time.timeScale = 1; 
            // Load next scene.
        }
        #endregion
    }
}