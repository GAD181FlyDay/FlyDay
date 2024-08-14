using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeesawBridge_Interaction : Scripts_InteractionBaseToOverride
{
    [SerializeField] private GameObject minigameStand;
    [SerializeField] private PlayerInteractions playerInteractions;

    private void Start()
    {
        if (playerInteractions.seeSawBridge == true)
        {
            minigameStand.tag = "Untagged";
        }
    }
    public override void Interact()
    {
        playerInteractions.seeSawBridge = true;

        minigameStand.tag = "Untagged";

        Invoke("LoadSceneIfUntagged", 0.2f);
    }
    private void LoadSceneIfUntagged()
    {
        if (minigameStand.tag == "Untagged")
        {
            SceneManager.LoadScene("SeesawBridge");
        }
    }
}
