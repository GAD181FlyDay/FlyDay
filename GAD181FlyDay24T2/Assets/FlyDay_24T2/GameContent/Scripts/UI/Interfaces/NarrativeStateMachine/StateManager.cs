using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Narrative.NarrativeStateStorage;

namespace Narrative
{
    /// <summary>
    /// This Script manages all states.
    /// </summary>

    public class StateManager : MonoBehaviour
    {
        #region Variables.
        [SerializeField] private NarrativeStateStorage initialState;
        [SerializeField] private NarrativePanelManager panelController;
        [SerializeField] private NarrativeStateStorage currentState;
        [SerializeField] private PlayerSaveData playerSaveData;
        [SerializeField] private List<NarrativeStateStorage> narrativeStates; // List of possible states

        private int _currentEntryIndex;
        private float _inputDelay = 3f;
        private float _timer = 0f;
        private bool _canProgress = true;
        // Places the enums states in NarrativeStateStorage objects to dictionary and initializes it.
        private Dictionary<NarrativeStateStorage.NarrativeStates, NarrativeStateStorage> _stateDictionary;
        #endregion


        private void Start()
        {
            UpdateCurrentState();
            DisplayCurrentNarrativeEntry();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ProgressToNextEntry();
            }
        }


        #region Public Functions.
        public void ProgressToNextEntry()
        {
            _currentEntryIndex++;
            DisplayCurrentNarrativeEntry();
        }

        public void SetStateInt(int newStateInt)
        {
            playerSaveData.currentStateInt = newStateInt;
            UpdateCurrentState();
            DisplayCurrentNarrativeEntry();
        }
        #endregion

        #region Private Functions
        private void UpdateCurrentState()
        {
            if (playerSaveData.currentStateInt >= 0 && playerSaveData.currentStateInt < narrativeStates.Count)
            {
                currentState = narrativeStates[playerSaveData.currentStateInt];
                _currentEntryIndex = 0;
            }
            else
            {
                Debug.LogError("Invalid stateInt value in NarrativeStateManager.");
            }
        }

        private void DisplayCurrentNarrativeEntry()
        {
            if (currentState != null && _currentEntryIndex < currentState.narrativeEntries.Length)
            {
                string narrative = currentState.narrativeEntries[_currentEntryIndex];
                Sprite image = currentState.narrativeImages[_currentEntryIndex];
                panelController.ShowPanel(narrative, image);
            }
            else
            {
                panelController.HidePanel();
            }
        }
        #endregion

    }
}