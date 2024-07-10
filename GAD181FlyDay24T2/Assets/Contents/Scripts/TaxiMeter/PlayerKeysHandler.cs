using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// Handles keyboard inputs to see if they matched the displayed notes or not!
    /// </summary>

    public class PlayerKeysHandler : MonoBehaviour
    {
        #region Variables
        public enum Player { PlayerOne, PlayerTwo }
        public Player player;

        public Collider matchAreaCollider; // Collider for the match area.
        public TaxiMeterBaseLogic taxiMeter; // Reference to the TaxiMeterBaseLogic script.

        private int inputCounter = 0; // Tracks the number of inputs
        private int maxInputs = 0; // Max inputs based on spawned notes

        private const float CorrectlyMatchedNoteMeterValue = 0.25f;
        private const float IncorrectlyMatchedNoteMeterValue = 1.5f;
        #endregion

        private void Update()
        {
            KeyboardInputchecker();
        }

        #region Private Functions
        private void KeyboardInputchecker()
        {
            /// <summary>  
            /// Checks if player input matched the notes based on what the
            /// players have pressed.
            /// WASD are for Player One.
            /// Arrow keys are for Player Two.
            ///</ summary >
            if (player == Player.PlayerOne)
            {
                if (Input.GetKeyDown(KeyCode.W) && inputCounter < maxInputs)
                {
                    CheckMatch("W");
                }
                else if (Input.GetKeyDown(KeyCode.A) && inputCounter < maxInputs)
                {
                    CheckMatch("A");
                }
                else if (Input.GetKeyDown(KeyCode.S) && inputCounter < maxInputs)
                {
                    CheckMatch("S");
                }
                else if (Input.GetKeyDown(KeyCode.D) && inputCounter < maxInputs)
                {
                    CheckMatch("D");
                }
            }
            else if (player == Player.PlayerTwo)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && inputCounter < maxInputs)
                {
                    CheckMatch("Up");
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && inputCounter < maxInputs) 
                {
                    CheckMatch("Left");
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && inputCounter < maxInputs)
                {
                    CheckMatch("Down");
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && inputCounter < maxInputs)
                {
                    CheckMatch("Right");
                }
            }
        }
        private void CheckMatch(string note)
        {
            /// <summary>
            /// Checks if the note is within the match area collider by checking all colliders in the notes.
            /// </summary> 
            inputCounter++;
            Bounds matchAreaBounds = matchAreaCollider.bounds;
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f); // Use a small sphere to detect the note
            foreach (var collider in colliders)
            {
                if (collider == matchAreaCollider)
                {
                    Notes noteComponent = collider.GetComponent<Notes>();
                    if (noteComponent != null && noteComponent.noteType == note)
                    {
                        // Correct match.
                        taxiMeter.AdjustMeter(CorrectlyMatchedNoteMeterValue);
                        Destroy(gameObject); // Destroy the matched note.
                    }
                    else
                    {
                        // Incorrect match.
                        taxiMeter.AdjustMeter(IncorrectlyMatchedNoteMeterValue);
                        Destroy(gameObject); // Destroy the wrongly matched note.
                    }
                    return;
                }
            }
            // Note was not in match area.
            taxiMeter.AdjustMeter(IncorrectlyMatchedNoteMeterValue); // Incorrect match therefore add incorrect amount to meter.
        }

        public void SetMaxInputs(int maxInputs)
        {
            this.maxInputs = maxInputs;
            inputCounter = 0; // Reset input counter each time new notes are spawned
        }

        #endregion
    }
}