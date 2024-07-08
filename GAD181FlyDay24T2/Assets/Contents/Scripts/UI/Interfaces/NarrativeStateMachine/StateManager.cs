using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Narrative
{
    /// <summary>
    /// This Script manages all states.
    /// </summary>

    public class StateManager : MonoBehaviour
    {
        #region Variables
        #region Script references
        // The initial narrative state set through scriptable object.
        [SerializeField] private NarrativeStateStorage initialState;

        // The current narrative state set through the scriptable object.
        private NarrativeStateStorage _currentState;
        #endregion

        #region ints and floats
        // The current Array index of displayed narrative text.
        private int _currentNarrativeIndex;

        // The delay between inputs to prevent narrative skip spamming. 
        private float _inputDelay = 1f;  // (in seconds).

        // Timer to track the delay.
        private float _timer = 0f;
        #endregion

        // Checks to see if the delay is done to allow the players to progress,
        private bool _canProgress = true;

        // Places the enums states into to NarrativeStateStorage objects dictionary and initializes it.
        private Dictionary<NarrativeStateStorage.NarrativeStates, NarrativeStateStorage> _stateDictionary = new Dictionary<NarrativeStateStorage.NarrativeStates, NarrativeStateStorage>();
        #endregion

        void Start()
        {
            // Find all NarrativeStateStorage objects in the Resources folder.
            NarrativeStateStorage[] allStates = Resources.LoadAll<NarrativeStateStorage>("");
            foreach (NarrativeStateStorage state in allStates)
            {
                // Add each state to the dictionary.
                _stateDictionary[state.stateType] = state;
            }

            // Set the initial state and start the narrative from 0.
            _currentState = initialState;
            _currentNarrativeIndex = 0;

            // Display the first narrative entry
            DisplayCurrentNarrativeEntry();
        }

        void Update()
        {
            // If input is not allowed, update the timer
            if (!_canProgress)
            {
                _timer += Time.deltaTime;
                if (_timer >= _inputDelay)
                {
                    // Allow input and reset the timer
                    _canProgress = true;
                    _timer = 0f;
                }
            }

            // Check for mouse click input and if input is allowed
            if (Input.GetMouseButtonDown(0) && _canProgress)
            {
                // Progress to the next narrative entry and disable input
                ProgressToNextEntry();
                _canProgress = false;
            }
        }

        #region Public Functions

        #region Progress to the next narrative entry.
        public void ProgressToNextEntry()
        {
            /// <summary>
            /// This Function moves down the narrative array and then displays
            /// the next narrative line if there are any.
            /// </summary>
            _currentNarrativeIndex++;
            DisplayCurrentNarrativeEntry();
        }
        #endregion

        #region State setter.
        public void SetState(NarrativeStateStorage newState)
        {
            /// <summary>
            /// This Function is responsible for updating the current state to the new state
            /// and then display them.
            /// </summary>
            _currentState = newState;
            _currentNarrativeIndex = 0;

            DisplayCurrentNarrativeEntry();
        }
        #endregion

        #endregion

        #region Private Functions

        #region Show current state's narrative.
        private void DisplayCurrentNarrativeEntry()
        {
            /// <summary>
            /// This Function checks if there are more narrative entries to display then displays them.
            /// Currently it just logs them onto the console, change that with UI later on.
            /// If there isn't anymore any narrative entries to display then it would transition to the next state.
            /// </summary>
            if (_currentNarrativeIndex < _currentState.narrativeEntries.Length)
            {
                Debug.Log(_currentState.narrativeEntries[_currentNarrativeIndex]);
            }
            else
            {
                TransitionToNextState();
            }
        }
        #endregion

        #region Transition to the next state.
        private void TransitionToNextState()
        {
            /// <summary>
            /// This Function checks if the next state exists in the dictionary. (to avoid null issues)
            /// If there is then it would set up the new state.
            /// If there isn't then the narrative has ended. no more to display.
            /// </summary>
            if (_stateDictionary.ContainsKey(_currentState.nextState))
            {
                SetState(_stateDictionary[_currentState.nextState]);
            }
            else
            {
                Debug.Log("End of narrative.");
            }
        }
        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        #region Previous script content
        //    public enum Stages
        //    {
        //        PacsonsHouse,
        //        Taxi,
        //        ReachedAirport,
        //        InsideAirport,
        //        ReachedDutyFree,
        //        PlaneBoarded,
        //        FinchsHouse
        //        // Add more stages as needed
        //    }

        //    #region Variables
        //    public Text stageText; // Reference to the Text component on the canvas
        //    public Stages currentStage; // The current stage
        //    #endregion

        //    void Start()
        //    {
        //        UpdateStageText();
        //    }

        //    private string[] stageMessages =
        //    {
        //    "Pacson's House",
        //    "Get ready for Stage 2",
        //    "Final Stage 3",
        //    // Add more messages corresponding to the stages
        //};



        //    public void SetStage(Stages newStage)
        //    {
        //        currentStage = newStage;
        //        UpdateStageText();
        //    }

        //    void UpdateStageText()
        //    {
        //        stageText.text = stageMessages[(int)currentStage];
        //    }
        #endregion
    }
}