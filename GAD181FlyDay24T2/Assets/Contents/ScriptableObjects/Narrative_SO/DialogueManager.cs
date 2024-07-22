using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Reference to your UI Text or TMP_Text component
    public Button[] optionButtons; // Reference to your UI Buttons

    public DialogueOption[] dialogueOptions;

    public DialogueStage currentState;


    public void Start()
    {
        currentState = DialogueStage.PacHouse;
        DisplayDialogue();
    }

    void DisplayDialogue()
    {
        DialogueOption currentOption = GetDialogueOption(currentState);
        if (currentOption == null) return;

        dialogueText.text = currentOption.dialogueText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentOption.buttonTexts.Length)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = currentOption.buttonTexts[i];
                optionButtons[i].gameObject.SetActive(true);
                int optionIndex = i; // Capture the loop variable
                optionButtons[i].onClick.AddListener(() => AdvanceDialogue(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void AdvanceDialogue(int option)
    {
        DialogueOption currentOption = GetDialogueOption(currentState);
        if (currentOption == null) return;

        currentState = currentOption.nextStage;
        DisplayDialogue();
    }

    DialogueOption GetDialogueOption(DialogueStage stage)
    {
        foreach (var option in dialogueOptions)
        {
            if (option.nextStage == stage)
            {
                return option;
            }
        }
        return null;
    }

}