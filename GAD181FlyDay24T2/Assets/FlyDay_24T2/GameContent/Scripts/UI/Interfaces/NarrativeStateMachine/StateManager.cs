using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Narrative.NarrativeStateStorage;

namespace Narrative
{
    public class StateManager : MonoBehaviour
    {
        #region Variables
        public NarrativeStateStorage currentState;

        [SerializeField] private NarrativeStateStorage initialState;
        [SerializeField] private NarrativePanelManager panelController;
        [SerializeField] private List<NarrativeStateStorage> narrativeStates;
        [SerializeField] private List<PlayerPositionsStorage> playersPositions;
        [SerializeField] private Transform player1Transform;
        [SerializeField] private Transform player2Transform;

        private int _currentEntryIndex;
        private int _lastStateInt = -1;  

        private Dictionary<NarrativeStateStorage.NarrativeStates, NarrativeStateStorage> _stateDictionary;
        #endregion

        private void Start()
        {
            LoadInitialState();
        }

        private void Update()
        {
            InputDelayThenProgress();
        }

        #region Public Functions

        public void ProgressToNextEntry()
        {
            _currentEntryIndex++;
            DisplayCurrentNarrativeEntry();
        }

        public void SetStateInt(int newStateInt)
        {
            if (newStateInt != DataManager.Instance.PlayerData.currentStateInt)
            {
                DataManager.Instance.SetGameState(newStateInt);
                SceneTransitionManager.Instance.LoadSceneBasedOnState(newStateInt); 
                UpdateCurrentState();
            }
        }


        #endregion

        #region Private Functions

        private void InputDelayThenProgress()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ProgressToNextEntry();
            }
        }

        private void LoadInitialState()
        {
            UpdateCurrentState();
            DisplayCurrentNarrativeEntry();
        }

        private void UpdateCurrentState()
        {
            int currentStateInt = DataManager.Instance.PlayerData.currentStateInt;

            if (currentStateInt != _lastStateInt && currentStateInt >= 0 && currentStateInt < narrativeStates.Count)
            {
                _lastStateInt = currentStateInt;
                currentState = narrativeStates[currentStateInt];
                _currentEntryIndex = 0;
                UpdatePlayerPositions();
            }
            else if (currentStateInt < 0 || currentStateInt >= narrativeStates.Count)
            {
                Debug.LogError("Invalid stateInt value in NarrativeStateManager.");
            }
        }

        private void DisplayCurrentNarrativeEntry()
        {
            if (currentState != null && _currentEntryIndex < currentState.narrativeEntries.Length)
            {
                string narrativeText = currentState.narrativeEntries[_currentEntryIndex];
                Sprite image = currentState.narrativeImages[_currentEntryIndex];
                panelController.ShowPanel(narrativeText, image);
            }
            else
            {
                panelController.HidePanel();
            }
        }

        private void UpdatePlayerPositions()
        {
            int currentStateInt = DataManager.Instance.PlayerData.currentStateInt;

            if (currentStateInt >= 0 && currentStateInt < playersPositions.Count)
            {
                player1Transform.position = playersPositions[currentStateInt].playerOnePos;
                player2Transform.position = playersPositions[currentStateInt].playerTwoPos;
            }
            else
            {
                Debug.LogError("Invalid stateInt for player positions.");
            }
        }

        #endregion
    }
}
