using OpenCover.Framework.Model;
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

        public Collider2D matchAreaCollider; // Collider for the match area.
        public TaxiMeterBaseLogic taxiMeter; // Reference to the TaxiMeterBaseLogic script.

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
                if (Input.GetKeyDown(KeyCode.W))
                {
                    CheckMatch("W");
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    CheckMatch("A");
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    CheckMatch("S");
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    CheckMatch("D");
                }
            }
            else if (player == Player.PlayerTwo)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    CheckMatch("Up");
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    CheckMatch("Left");
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    CheckMatch("Down");
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
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
            Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
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
        #endregion
    }
}