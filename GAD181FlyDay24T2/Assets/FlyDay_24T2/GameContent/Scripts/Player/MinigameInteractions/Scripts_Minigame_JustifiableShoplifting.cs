using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Minigame_XnOs : Scripts_InteractionBaseToOverride
{
    [SerializeField] private GameObject minigameStand;
    [SerializeField] private PlayerInteractions playerInteractions;
    [SerializeField] private PlayerSaveData playerSaveData;

    private void Start()
    {
        if (playerInteractions.taxiStand == true)
        {
            float rewardMoneyForDiscoveringMinigame = 10f;
            minigameStand.tag = "Untagged";
            playerSaveData.mainLuckyCoinsSource += rewardMoneyForDiscoveringMinigame;
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
            SceneManager.LoadScene("XandOMinigame");
        }
    }
}
