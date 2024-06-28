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
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text playerWonOrDrawText;

        private string _currentPlayer = "X";
        private int _moveCount = 0;
        private bool _gameOver = false;
        #endregion

        private void Start()
        {
            // Hides the restart button and exit button from appearance.
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }

        #region Public Functions

        #region Button input 'listener'.
        public void OnButtonClick(Button button)
        {
            Debug.Log("Button clicked by: " + _currentPlayer);

            // Execute the code only if the game is not over.
            if (!_gameOver)
            {
                // Find the number of the interacted with button in the button array.
                int index = System.Array.IndexOf(buttons, button);

                if (index == -1)
                {
                    Debug.LogError("Button not found in the array.");
                    return;
                }

                if (buttonTexts[index].text == "")
                {
                    // Set the interacted with button's text to the current player's symbol.
                    buttonTexts[index].text = _currentPlayer;
                    _moveCount++;

                    // Check if the current player won.
                    if (CheckWin())
                    {
                        ShowEndGameButtons();
                        playerWonOrDrawText.text = _currentPlayer + " Won!";
                        Debug.Log(_currentPlayer + " Wins!");
                        _gameOver = true;
                    }
                    // Check if all 9 moves are made.
                    else if (_moveCount == 9)
                    {
                        ShowEndGameButtons();
                        playerWonOrDrawText.text = "Draw!";
                        Debug.Log("Draw!");
                    }
                    // Switch to the next player.
                    else
                    {
                        SwitchPlayer();
                    }
                }
            }
        }
        #endregion

        #region Win conditions checker
        public bool CheckWin()
        {
            // Run through all the win combinations.
            for (int i = 0; i < winningConditions.GetLength(0); i++)
            {
                int a = winningConditions[i, 0];
                int b = winningConditions[i, 1];
                int c = winningConditions[i, 2];

                // Check if the current player has all three positions in a winning combination.
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
            // Clear the text of all buttons.
            foreach (TMP_Text buttonText in buttonTexts)
            {
                if (buttonText != null)
                {
                    buttonText.text = "";
                }
            }

            // Reset the game back to the starting state.
            _currentPlayer = "X";
            _moveCount = 0;
            _gameOver = false;
            playerWonOrDrawText.text = "";
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }

        public void ExitMinigame()
        {
            Debug.Log("Game has been exited.");
            // Scene unloads or the panel switches off.
        }
        #endregion

        #endregion

        #region Private Functions
        #region Switches players per turn.
        private void SwitchPlayer()
        {
            // Switch the current player from X to O or from O to X.
            _currentPlayer = _currentPlayer == "X" ? "O" : "X";
        }
        #endregion

        #region A collection of win conditions.
        private int[,] winningConditions = new int[,]
        {
            { 0, 1, 2 }, // up left to right.
            { 3, 4, 5 }, // middle left to right.
            { 6, 7, 8 }, // down left to right.
            { 0, 3, 6 }, // left up to bottom.
            { 1, 4, 7 }, // middle up to bottom.
            { 2, 5, 8 }, // right up to bottom.
            { 0, 4, 8 }, // top left to right bottom.
            { 2, 4, 6 }  // top right to bottom left.
        };
        #endregion

        #region Displays end game buttons.
        private void ShowEndGameButtons()
        {
            // Show the restart button and the exit button when the game ends.
            restartButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
        #endregion

        #endregion
    }
}