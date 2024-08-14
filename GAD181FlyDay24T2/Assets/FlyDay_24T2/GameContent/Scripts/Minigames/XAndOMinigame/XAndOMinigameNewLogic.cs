using DutyFree;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XAndOMinigame
{
    public class XAndOMinigameNewLogic : MonoBehaviour
    {
        #region Variables.
        public Material xMaterial;
        public Material oMaterial;
        public Material resetMaterial;
        public PlayerSaveData playerSaveData;
        public string CurrentPlayer => _currentPlayer;
        public bool IsGameOver => _gameOver;

        [SerializeField] private XAndOFloorTiles[] floorTiles;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TMP_Text playerWonOrDrawText;
        [SerializeField] private TMP_Text currentPlayerText;
        [SerializeField] private PurchasedItemData purchasedItemData;

        private string _currentPlayer;
        private int _moveCount = 0;
        private bool _gameOver = false;
        private int[] gameState;
        #endregion

        private void Start()
        {
            endGamePanel.SetActive(false);
            _currentPlayer = Random.Range(0, 2) == 0 ? "X" : "O";
            UpdateCurrentPlayerText();

            gameState = new int[floorTiles.Length];

            for (int i = 0; i < floorTiles.Length; i++)
            {
                floorTiles[i].tileIndex = i;
            }
        }

        #region Public Functions.
        public bool SetCurrentPlayerOnTile(XAndOFloorTiles tile, string playerTag, int tileIndex)
        {
            if (gameState[tileIndex] == 0)
            {
                _moveCount++;

                if (playerTag == "PlayerOne")
                {
                    tile.SetMaterial(xMaterial);
                    gameState[tileIndex] = 1;
                    Debug.Log("Player One set a tile.");
                }
                else if (playerTag == "PlayerTwo")
                {
                    tile.SetMaterial(oMaterial);
                    gameState[tileIndex] = 2;
                    Debug.Log("Player Two set a tile.");
                }

                if (CheckWin())
                {
                    ShowEndGamePanel(_currentPlayer + " Won!");
                    _gameOver = true;
                    return true;
                }
                else if (_moveCount == floorTiles.Length)
                {
                    ShowEndGamePanel("Draw!");
                    _gameOver = true;
                    return true;
                }

                SwitchPlayer();
                UpdateCurrentPlayerText();
                return true;
            }
            return false;
        }
        public void RestartGame()
        {
            foreach (XAndOFloorTiles tile in floorTiles)
            {
                tile.cellRenderer.material = resetMaterial;
                tile.gameObject.tag = "GridTile";
                tile.GetType().GetField("_tileSet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(tile, false);
            }

            _currentPlayer = Random.Range(0, 2) == 0 ? "X" : "O";
            _moveCount = 0;
            _gameOver = false;
            gameState = new int[floorTiles.Length];
            playerWonOrDrawText.text = "";
            endGamePanel.SetActive(false);
            currentPlayerText.gameObject.SetActive(true);
            UpdateCurrentPlayerText();
        }

        public void ExitMinigame()
        {
            if (purchasedItemData.purchasedItem == "goodGift")
            {
                playerSaveData.currentStateInt = 6;
            }
            if (purchasedItemData.purchasedItem == "badGift")
            {
                playerSaveData.currentStateInt = 7;
            }
            Debug.Log("Game has been exited.");

            SceneManager.LoadScene("MainGameScene");
        }
        #endregion

        #region Private Functions
        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == "X" ? "O" : "X";
        }

        private bool CheckWin()
        {
            int[,] winningConditions = new int[,]
            {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            for (int i = 0; i < winningConditions.GetLength(0); i++)
            {
                int a = winningConditions[i, 0];
                int b = winningConditions[i, 1];
                int c = winningConditions[i, 2];

                if (gameState[a] != 0 && gameState[a] == gameState[b] && gameState[b] == gameState[c])
                {
                    return true;
                }
            }
            return false;
        }

        private void ShowEndGamePanel(string result)
        {
            endGamePanel.SetActive(true);
            playerWonOrDrawText.text = result;
            currentPlayerText.gameObject.SetActive(false);
        }

        private void UpdateCurrentPlayerText()
        {
            currentPlayerText.text = "Current Player: " + _currentPlayer;
        }
        #endregion
    }
}
