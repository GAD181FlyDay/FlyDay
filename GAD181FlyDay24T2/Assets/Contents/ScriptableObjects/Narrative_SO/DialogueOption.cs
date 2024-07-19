using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "Dialogue/Option")]
public class DialogueOption : ScriptableObject
{
    public string dialogueText;
    public DialogueStage nextStage;
    public string[] buttonTexts;
}