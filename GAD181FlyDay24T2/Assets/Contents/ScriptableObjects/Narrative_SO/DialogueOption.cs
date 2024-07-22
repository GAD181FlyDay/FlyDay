using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "Dialogue/Option")]
public class DialogueOption : ScriptableObject
{
    public DialogueStage stage;
    public string dialogueText;
    public DialogueStage nextStage;
    public string[] buttonTexts;
}