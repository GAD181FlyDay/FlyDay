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
        [SerializeField] private List<NarrativeStateStorage> narrativeStates;
        [SerializeField] private List<PlayerPositionsStorage> playersPositions;
        [SerializeField] private Transform player1Transform;
        [SerializeField] private Transform player2Transform;

        private int _currentEntryIndex;

        //private float _inputDelay = 1.5f;
        //private float _timer = 0f; 
        //private bool _canProgress = true;

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
            InputDelayThenProgress();
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
        private void InputDelayThenProgress()
        {
            //if (!_canProgress)
            //{
            //    _timer += Time.deltaTime;
            //    if (_timer >= _inputDelay)
            //    {
            //        _canProgress = true;
            //        _timer = 0f;
            //    }
            //}

            if (Input.GetKeyUp(KeyCode.Space)) // && _canProgress
            {
                ProgressToNextEntry();
                // _canProgress = false;
            }
        }


        private void UpdateCurrentState()
        {
            if (playerSaveData.currentStateInt >= 0 && playerSaveData.currentStateInt < narrativeStates.Count)
            {
                currentState = narrativeStates[playerSaveData.currentStateInt];
                _currentEntryIndex = 0;
                UpdatePlayerPositions();
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
                string _narrative = currentState.narrativeEntries[_currentEntryIndex];
                Sprite image = currentState.narrativeImages[_currentEntryIndex];
                panelController.ShowPanel(_narrative, image);
            }
            else
            {
                panelController.HidePanel();
            }
        }


        private void UpdatePlayerPositions()
        {
            if (playerSaveData.currentStateInt >= 0 && playerSaveData.currentStateInt < playersPositions.Count)
            {
                player1Transform.position = playersPositions[playerSaveData.currentStateInt].playerOnePos;
                player2Transform.position = playersPositions[playerSaveData.currentStateInt].playerTwoPos;
            }
            else
            {
                Debug.LogError("Invalid stateInt for player positions.");
            }
        }

        #endregion

    }
}