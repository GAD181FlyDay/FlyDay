using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Minigame_MovingStatues : OverrideableInteractionBase
{
    [SerializeField] private GameObject minigameStand;
    [SerializeField] private PlayerInteractions playerInteractions;

    private void Start()
    {
        if (playerInteractions.taxiStand == true)
        {
            minigameStand.tag = "Untagged";
        }
    }
    public override void Interact()
    {
        playerInteractions.taxiStand = true;

        minigameStand.tag = "Untagged";

        Invoke("LoadSceneIfUntagged", 0.2f);
    }
}
