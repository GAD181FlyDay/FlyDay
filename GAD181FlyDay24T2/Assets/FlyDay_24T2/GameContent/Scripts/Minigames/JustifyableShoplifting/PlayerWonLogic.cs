using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustifyableShoplifting
{
    /// <summary>
    /// Player won behavior.
    /// </summary>

    public class PlayerWonLogic : MonoBehaviour
    {
        #region Variables
        public GameObject winPanel;
        #endregion

        private void Start()
        {
            winPanel.SetActive(false);
        }

        #region Public Functions
        public void WinGame()
        {
            // Activate the win panel and pause the game
            winPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

        public void Proceed()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainGameScene");
        }
        #endregion
    }
}