using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace XAndOMinigame
{
    public class XAndOMinigameNewLogic : MonoBehaviour
    {
        #region Variables
        [SerializeField] private XAndOFloorTiles[] floorTiles;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TMP_Text playerWonOrDrawText;
        [SerializeField] private TMP_Text currentPlayerText;

        private string _currentPlayer;
        private int _moveCount = 0;
        private bool _gameOver = false;
        public Material xMaterial;
        public Material oMaterial;
        #endregion

        public string CurrentPlayer => _currentPlayer;
        public bool IsGameOver => _gameOver;

        private void Start()
        {
            endGamePanel.gameObject.SetActive(false);

            _currentPlayer = Random.Range(0, 2) == 0 ? "X" : "O";
            UpdateCurrentPlayerText();
        }

        public bool SetCurrentPlayerOnTile(XAndOFloorTiles tile, string playerTag)
        {
            if (tile.cellRenderer.material != xMaterial && tile.cellRenderer.material != oMaterial)
            {
                _moveCount++;

                if (playerTag == "PlayerOne")
                {
                    tile.SetMaterial(xMaterial);
                }
                else if (playerTag == "PlayerTwo")
                {
                    tile.SetMaterial(oMaterial);
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

                Material aMat = floorTiles[a].cellRenderer.material;
                Material bMat = floorTiles[b].cellRenderer.material;
                Material cMat = floorTiles[c].cellRenderer.material;

                // Debug.Log($"Checking tiles: {a}, {b}, {c}");
                // Debug.Log($"Materials: {aMat?.name}, {bMat?.name}, {cMat?.name}");

                if (aMat != null && aMat == bMat && bMat == cMat)
                {
                    if (aMat == xMaterial || aMat == oMaterial)
                    {
                        Debug.Log($"Win detected for: {aMat.name}");
                        return true;
                    }
                }
            }
            return false;
        }


        private void ShowEndGamePanel(string result)
        {
            endGamePanel.gameObject.SetActive(true);
            playerWonOrDrawText.text = result;
            currentPlayerText.gameObject.SetActive(false);
        }

        private void UpdateCurrentPlayerText()
        {
            currentPlayerText.text = "Current Player: " + _currentPlayer;
        }

        public void RestartGame()
        {
            foreach (XAndOFloorTiles tiles in floorTiles)
            {
                tiles.cellRenderer.material = null;
                tiles.gameObject.tag = "Tile";
                typeof(XAndOFloorTiles).GetField("_tileSet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(tiles, false);
            }

            _currentPlayer = Random.Range(0, 2) == 0 ? "X" : "O";
            _moveCount = 0;
            _gameOver = false;
            playerWonOrDrawText.text = "";
            endGamePanel.gameObject.SetActive(false);
            currentPlayerText.gameObject.SetActive(true);
            UpdateCurrentPlayerText();
        }

        public void ExitMinigame()
        {
            Debug.Log("Game has been exited.");
        }
    }
}
