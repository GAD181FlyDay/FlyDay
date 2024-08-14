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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            lostPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Retry()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene.
        }
        #endregion
    }
}