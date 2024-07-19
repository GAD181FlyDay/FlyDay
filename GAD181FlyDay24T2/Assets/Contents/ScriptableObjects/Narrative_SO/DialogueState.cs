using UnityEngine;

public class DialogueState : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager.Start();
    }

    DialogueStage CustomStateTransition(DialogueStage currentState, int option)
    {
        switch (currentState)
        {
            case DialogueStage.Greeting:
                if (option == 0)
                {
                    return DialogueStage.Question;
                }
                else
                {
                    return DialogueStage.Farewell;
                }
            case DialogueStage.Question:
                return DialogueStage.Farewell;
            case DialogueStage.Farewell:
                return DialogueStage.End;
            case DialogueStage.End:
                // Conversation ends, no further state
                return DialogueStage.End;
            default:
                return DialogueStage.End;
        }
    }
}