using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustifyableShoplifting
{
    /// <summary>
    /// Responsible for player lost/ got caught behavior.
    /// </summary>

    public class PlayerBustedLogic : MonoBehaviour
    {
        #region Variables
        public GameObject lostPanel;
        #endregion

        private void Start()
        {
            lostPanel.SetActive(false);
        }

        #region Public Functions.
        public void LoseGame()
        {
            lostPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Retry()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene.
        }

        public void Proceed()
        {
            Time.timeScale = 1f;
            // Load next scene.
        }
        #endregion
    }
}