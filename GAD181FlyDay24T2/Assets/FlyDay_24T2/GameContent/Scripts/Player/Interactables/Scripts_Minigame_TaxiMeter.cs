using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Minigame_TaxiMeter : Scripts_InteractionBaseToOverride
{
    [SerializeField] private GameObject minigameStand;
    [SerializeField] private PlayerInteractions playerInteractions;

    private void Start()
    {
        if (playerInteractions.taxiStand == true)
        {
            minigameStand.tag = "Untagged";
            minigameStand.layer = 0;
        }
    }
    public override void Interact()
    {
        playerInteractions.taxiStand = true;

        minigameStand.tag = "Untagged";

        Invoke("LoadSceneIfUntagged", 0.2f);
    }

    private void LoadSceneIfUntagged()
    {
        if (minigameStand.tag == "Untagged")
        {
            SceneManager.LoadScene("TaxiMeter");
        }
    }
}
