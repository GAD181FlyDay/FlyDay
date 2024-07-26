using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XAndOMinigame
{
    /// <summary>
    /// This script handles the main logic for the minigame X and O.
    /// It contains the following details: Button arrays, Checks if the players won or not, 
    /// Changes UI text,  and displays buttons.
    /// </summary>

    public class XAndOLogic : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Button[] buttons;
        [SerializeField] private TMP_Text[] buttonTexts;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private TMP_Text playerWonOrDrawText;
        [SerializeField] private TMP_Text currentPlayerText; 

        private string _currentPlayer;
        private int _moveCount = 0;
        private bool _gameOver = false;
        #endregion

        private void Start()
        {
            endGamePanel.gameObject.SetActive(false);

            _currentPlayer = Random.Range(0, 2) == 0 ? "X" : "O";
            UpdateCurrentPlayerText();
        }

        #region Public Functions

        #region Button input 'listener'.
        public void OnButtonClick(Button button)
        {
            Debug.Log("Button clicked by: " + _currentPlayer);

            if (!_gameOver)
            {
                int index = System.Array.IndexOf(buttons, button);

                if (index == -1)
                {
                    Debug.LogError("Button not found in the array.");
                    return;
                }

                if (buttonTexts[index].text == "")
                {
                    buttonTexts[index].text = _currentPlayer;
                    _moveCount++;

                    if (CheckWin())
                    {
                        ShowEndGameButtons();
                        playerWonOrDrawText.text = _currentPlayer + " Won!";
                        Debug.Log(_currentPlayer + " Wins!");
                        _gameOver = true;
                        currentPlayerText.gameObject.SetActive(false); 
                    }
                    else if (_moveCount == 9)
                    {
                        ShowEndGameButtons();
                        playerWonOrDrawText.text = "Draw!";
                        Debug.Log("Draw!");
                        _gameOver = true;
                        currentPlayerText.gameObject.SetActive(false); 
                    }
                    else
                    {
                        SwitchPlayer();
                        UpdateCurrentPlayerText();
                    }
                }
            }
        }
        #endregion

        #region Win conditions checker
        public bool CheckWin()
        {
            for (int i = 0; i < winningConditions.GetLength(0); i++)
            {
                int a = winningConditions[i, 0];
                int b = winningConditions[i, 1];
                int c = winningConditions[i, 2];

                if (buttons[a].GetComponentInChildren<TMP_Text>().text == _currentPlayer &&
                    buttons[b].GetComponentInChildren<TMP_Text>().text == _currentPlayer &&
                    buttons[c].GetComponentInChildren<TMP_Text>().text == _currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region End game buttons
        public void RestartGame()
        {
            Debug.Log("Game has been restarted.");
         
            foreach (TMP_Text buttonText in buttonTexts)
            {
                if (buttonText != null)
                {
                    buttonText.text = "";
                }
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
        #endregion

        #endregion

        #region Private Functions
        #region Switches players per turn.
        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == "X" ? "O" : "X";
        }
        #endregion

        #region A collection of win conditions.
        private int[,] winningConditions = new int[,]
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
        #endregion

        #region Displays end game buttons.
        private void ShowEndGameButtons()
        {
            endGamePanel.gameObject.SetActive(true);
        }
        #endregion

        #region Updates the current player text.
        private void UpdateCurrentPlayerText()
        {
            currentPlayerText.text = "Current Player: " + _currentPlayer;
        }
        #endregion

        #endregion

    }
}