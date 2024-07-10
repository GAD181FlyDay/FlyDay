using UnityEditor.Experimental.GraphView;
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

        private float inputCooldown = 0f;
        private float cooldownTime = 0.1f;
        private const float CorrectlyMatchedNoteMeterValue = 0.25f;
        private const float IncorrectlyMatchedNoteMeterValue = 1.5f;
        #endregion

        private void Update()
        {
            BothPlayersInputchecker();
        }

        #region Private Functions
        private void BothPlayersInputchecker()
        {
            /// <summary>  
            /// Checks if player input matched the notes based on what the
            /// players have pressed.
            /// WASD are for Player One.
            /// Arrow keys are for Player Two.
            ///</ summary >
            ///
            if (Time.time >= inputCooldown)
            {
                if (player == Player.PlayerOne)
                {
                    CheckPlayerOneInput();
                }
                else if (player == Player.PlayerTwo)
                {
                    CheckPlayerTwoInput();
                }

                inputCooldown = Time.time + cooldownTime;
            }
        }

        private void CheckPlayerOneInput()
        {
            ///<summary>
            /// Checks player one WASD Inputs.
            /// </summary>
            if (inputCounter < maxInputs)
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
        }

        private void CheckPlayerTwoInput()
        {
            /// <summmary>
            /// Checks Two Arrow keys INputs.
            /// </summmary>

            if (inputCounter < maxInputs)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    CheckMatch("Up");
                    Debug.Log("Up");
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    CheckMatch("Left");
                    Debug.Log("Left");
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    CheckMatch("Down");
                    Debug.Log("Down");
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    CheckMatch("Right");
                    Debug.Log("Right");
                }
            }
        }

        private void CheckMatch(string note)
        {
            /// <summary>
            /// Checks if the note is within the match area collider by checking all colliders in the notes.
            /// </summary> 

            inputCounter++;

            GameObject noteObject = GameObject.Find(note + "Notes");
            if (noteObject != null)
            {
                if (noteObject != null && noteObject.GetComponent<Notes>().isInMatchArea)
                {
                    taxiMeter.AdjustMeter(CorrectlyMatchedNoteMeterValue);
                    Destroy(noteObject);
                    Debug.Log("Matched: " + note);
                }
                else
                {
                    taxiMeter.AdjustMeter(IncorrectlyMatchedNoteMeterValue);
                    Debug.Log("Not matched: " + note + " (Not in MatchArea)");
                }
            }
            else
            {
                taxiMeter.AdjustMeter(IncorrectlyMatchedNoteMeterValue);
                Debug.Log("Not matched: " + note + " (No note found)");
            }
        }

        public void SetMaxInputs(int maxInputs)
        {
            this.maxInputs = maxInputs;
            inputCounter = 0; // Reset input counter each time new notes are spawned
        }

        #endregion
    }
}