using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public enum Stages
    {
        Stage1,
        Stage2,
        Stage3,
        // Add more stages as needed
    }

    public Text stageText; // Reference to the Text component on the canvas
    public Stages currentStage; // The current stage

    private string[] stageMessages =
    {
        "Welcome to Stage 1",
        "Get ready for Stage 2",
        "Final Stage 3",
        // Add more messages corresponding to the stages
    };

    void Start()
    {
        UpdateStageText();
    }

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
