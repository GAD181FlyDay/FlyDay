using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public GameObject narrativePanel; // The UI panel that contains narrative content
    public MonoBehaviour playerController; // Reference to the player controller script

    void Update()
    {
        if (narrativePanel.activeInHierarchy)
        {
            playerController.enabled = false;
        }
        else
        {
            playerController.enabled = true;
        }
    }

    public void ShowNarrative()
    {
        narrativePanel.SetActive(true);
    }

    public void HideNarrative()
    {
        narrativePanel.SetActive(false);
    }
}
