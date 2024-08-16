
using UnityEngine;
using UnityEngine.SceneManagement;

public class VIVA_Interactible : Scripts_InteractionBaseToOverride
{
    [SerializeField] private GameObject minigameStand;
    [SerializeField] private PlayerInteractions playerInteractions;

    private void Start()
    {
        if (playerInteractions.voluntaryInVoluntaryAssistance == true)
        {
            minigameStand.tag = "Untagged";
        }
    }
    public override void Interact()
    {
        playerInteractions.voluntaryInVoluntaryAssistance = true;

        minigameStand.tag = "Untagged";

        Invoke("LoadSceneIfUntagged", 0.2f);
    }

    private void LoadSceneIfUntagged()
    {
        if (minigameStand.tag == "Untagged")
        {
            SceneManager.LoadScene("VoluntaryInVoluntaryAssistance");
        }
    }
}