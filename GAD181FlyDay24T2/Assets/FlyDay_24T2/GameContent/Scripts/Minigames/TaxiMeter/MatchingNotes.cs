using TaxiMeter;
using UnityEngine;

public class MatchingNotes : MonoBehaviour
{
    #region Variables
    public NotesPooling wasdNotePool;
    public NotesPooling arrowNotePool;
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
        GameObject[] activeNotes = wasdNotePool.pooledNotes.FindAll(note => note.activeInHierarchy).ToArray();
        if (note.StartsWith("Up") || note.StartsWith("Left") || note.StartsWith("Down") || note.StartsWith("Right"))
        {
            activeNotes = arrowNotePool.pooledNotes.FindAll(note => note.activeInHierarchy).ToArray();
        }

        foreach (GameObject activeNote in activeNotes)
        {
            if (activeNote.GetComponent<Notes>().noteType == note && IsWithinMatchArea(activeNote.transform))
            {
                // The note is in the match area.
                TaxiMeterBaseLogic.taxiMeterBaseLogic.UpdateMeter(true);
                activeNote.SetActive(false);
                Debug.Log("Matched!!!");
                return;
            }
        }
        TaxiMeterBaseLogic.taxiMeterBaseLogic.UpdateMeter(false);
        Debug.Log("Didn't match");
    }

    private void InputChecker()
    {
        #region WASD inputs.
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