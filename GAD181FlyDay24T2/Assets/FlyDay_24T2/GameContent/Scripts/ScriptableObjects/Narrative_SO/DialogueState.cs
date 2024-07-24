using UnityEngine;

public class DialogueState : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int money;

    void Start()
    {
        dialogueManager.Start();
    }

    DialogueStage CustomStateTransition(DialogueStage currentState, int option)
    {
        switch (currentState)
        {
            case DialogueStage.ParentsOpenGift:
                if (money < 250)
                {
                    return DialogueStage.GoodEnding;
                }
                else
                {
                    return DialogueStage.BadEnding;
                }
            case DialogueStage.TheoIntro:
                return DialogueStage.TheoTV;
            case DialogueStage.TheoTV:
                return DialogueStage.End;
            case DialogueStage.End:
                // Conversation ends, no further state
                return DialogueStage.End;
            default:
                return DialogueStage.End;
        }
    }
}