using UnityEngine;

namespace TaxiMeter
{
    public class MatchingNotes : MonoBehaviour
    {
        #region Variables
        public NotesPooling waNotePool;
        public NotesPooling sdNotePool;
        public NotesPooling upLeftNotePool;
        public NotesPooling downRightNotePool;

        [SerializeField] MinigameTimer minigameTimerScript;
        [SerializeField] private Transform matchArea;

        private float _matchRangeMinY = -0.5f;
        private float _matchRangeMaxY = 0.5f;
        #endregion

        void Update()
        {
            InputChecker();
        }

        #region Private Functions
        private void CheckMatch(string note)
        {
            GameObject[] activeNotes = null;

            if (note == "W" || note == "A")
            {
                activeNotes = waNotePool.pooledNotes.FindAll(n => n.activeInHierarchy).ToArray();
            }
            else if (note == "S" || note == "D")
            {
                activeNotes = sdNotePool.pooledNotes.FindAll(n => n.activeInHierarchy).ToArray();
            }
            else if (note == "Up" || note == "Left")
            {
                activeNotes = upLeftNotePool.pooledNotes.FindAll(n => n.activeInHierarchy).ToArray();
            }
            else if (note == "Down" || note == "Right")
            {
                activeNotes = downRightNotePool.pooledNotes.FindAll(n => n.activeInHierarchy).ToArray();
            }

            // Check if the active note matches the input and is within the match area
            if (activeNotes != null)
            {
                foreach (GameObject activeNote in activeNotes)
                {
                    if (activeNote.GetComponent<Notes>().noteType == note && IsWithinMatchArea(activeNote.transform))
                    {
                        // The note is in the match area.
                        TaxiMeterBaseLogic.taxiMeterBaseLogic.UpdateMeter(true);
                        activeNote.SetActive(false);
                        // Debug.Log("Matched!!!");
                        return;
                    }
                }
            }

            TaxiMeterBaseLogic.taxiMeterBaseLogic.UpdateMeter(false);
            // Debug.Log("Didn't match");
        }

        private void InputChecker()
        {
            if (!minigameTimerScript.gameEnded)
            {
                #region WASD inputs
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
                #endregion

                #region Directional arrows inputs
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
                #endregion
            }
            else
            {
                // Debug.Log("game has ended.");
            }
        }

        private bool IsWithinMatchArea(Transform noteTransform)
        {
            // Checks if the notes are in the matched area based on its Y axis.
            float _noteY = noteTransform.position.y;
            float _matchAreaY = matchArea.position.y;
            float _matchRangeMin = _matchAreaY + _matchRangeMinY;
            float _matchRangeMax = _matchAreaY + _matchRangeMaxY;

            return _noteY >= _matchRangeMin && _noteY <= _matchRangeMax;
        }
        #endregion
    }
}