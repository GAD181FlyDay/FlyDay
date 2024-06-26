using UnityEngine;
using UnityEngine.UI;

namespace XAndOMinigame
{
    /// <summary>
    /// This script handles the main logic for the minigame X and O.
    /// It contains the following details: Button arrays, Checks if the players won or not, 
    /// Changes UI text,  and displays buttons.
    /// </summary>
    /// 
    public class XAndOScriptLogic : MonoBehaviour
    {
        #region Variables
        // Holds an array of 9 buttons.
        // [SerializeField] private Button[] xAndOGridButtons = new Button[9];

        // Retry and Exit game buttons. Attach buttons to display once 9 moves have been completed.
        [SerializeField] private GameObject retryButton; 
        [SerializeField] private GameObject exitButton;
        // Tracks how many rounds were played/ how many moves both players made in total.
        private int _playerMoves;

        // Keeps track of the current player, are they X or O?
        // private char _currentPlayer;

        // checks
        // private bool minigameUnlockedForTheFirstTime = false;

        // Accesses the main coin system script.
        //Variable currently missing^^

        #endregion

        void Start()
        {
            // Make X start first, set the player to player X.

            // Set the player moves to 0 since they just started the round.

            // Set both retry and exit button Inactive.

        }

        #region Public functions
        /// <summary>
        /// Actions to execute whenever the grid buttons are pressed.
        /// </summary>
        public void OnButtonPress()
        {
            // Access the buttons' children (texts) and check if they're empty before executing the following code:
            // Change the empty text to whatever the current player's char is (X or O).
            // Check if the current player won by checking each row and see if it matches any of the win conditions.
            // Check if 9 rounds have been completed, if they have been completed: display buttons to retry the game.
            // Switch players.

            // If it isn't empty then do the following:
            // Nothing! No input feedback.
        }

        /// <summary>
        /// Allows the players to restart the X and O game.
        /// </summary>
        public void RestartGame()
        {

        }

        #endregion
    }
}