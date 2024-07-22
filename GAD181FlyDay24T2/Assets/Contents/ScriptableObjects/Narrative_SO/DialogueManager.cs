using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Reference to your UI Text or TMP_Text component
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
        if (currentOption == null)
        {
            Debug.LogError("No DialogueOption for this state " + currentState);
            return;
        }

        if (dialogueText == null)
        {
            Debug.LogError("there is no assigned dialogueText.");
            return;
        }
        dialogueText.text = currentOption.dialogueText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentOption.buttonTexts.Length)
            {
                if (optionButtons[i] == null)
                {
                    Debug.LogError("There is no Option button in slot " + i + ", It isn't assigned.");
                    continue;
                }
                
                TMP_Text buttonText = optionButtons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText == null)
                {
                    Debug.LogError("No child text found in optionButtons at " + i + " index.");
                    continue;
                }
                
                buttonText.text = currentOption.buttonTexts[i];
                optionButtons[i].gameObject.SetActive(true);
                int optionIndex = i; // Capture the loop variable
                optionButtons[i].onClick.AddListener(() => AdvanceDialogue(optionIndex));
            }
            else
            {
                if (optionButtons[i] != null)
                {
                    optionButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void AdvanceDialogue(int option)
    {
        DialogueOption currentOption = GetDialogueOption(currentState);
        if (currentOption == null)
        {
            Debug.LogError("Didnt find a DialogueOption for this state: " + currentState);
            return;
        }

        currentState = currentOption.nextStage;
        DisplayDialogue();
    }

    DialogueOption GetDialogueOption(DialogueStage stage)
    {
        if (dialogueOptions == null)
        {
            Debug.LogError("You did not initialise dialogueOptions array.");
            return null;
        }

        foreach (var option in dialogueOptions)
        {
            if (option == null)
            {
                Debug.LogError("One (or more) of the dialogueOptions is null!");
                continue; // continue sifting through options.
            }

            if (option.nextStage == stage)
            {
                return option;
            }
        }
        return null;
    }
}