using UnityEngine;
using UnityEngine.UI;

namespace Narrative
{

    /// <summary>
    /// 
    /// </summary>

    public class StageManager : MonoBehaviour
    {
        public enum Stages
        {
            PacsonsHouse,
            Taxi,
            ReachedAirport,
            InsideAirport,
            ReachedDutyFree,
            PlaneBoarded,
            FinchsHouse
            // Add more stages as needed
        }

        #region Variables
        public Text stageText; // Reference to the Text component on the canvas
        public Stages currentStage; // The current stage
        #endregion

        void Start()
        {
            UpdateStageText();
        }

        private string[] stageMessages =
        {
        "Pacson's House",
        "Get ready for Stage 2",
        "Final Stage 3",
        // Add more messages corresponding to the stages
    };



        public void SetStage(Stages newStage)
        {
            currentStage = newStage;
            UpdateStageText();
        }

        void UpdateStageText()
        {
            stageText.text = stageMessages[(int)currentStage];
        }
    }
}