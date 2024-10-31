using TMPro;
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

        [SerializeField] private TMP_Text totalCoinAmount;
        #endregion

        private void Start()
        {
            winPanel.SetActive(false);
        }

        #region Public Functions
        public void WinGame()
        {
            totalCoinAmount.text = "Good work! You now have " + DataManager.Instance.PlayerData.mainLuckyCoinsSource + " lucky coins in total!";
            DataManager.Instance.SetGameState(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

        public void Proceed()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainGameScene");
        }
        #endregion
    }
}
