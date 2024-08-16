using DutyFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameSceneBad : MonoBehaviour
{
    public PurchasedItemData purchasedItemData;
    public PlayerSaveData playerSaveData;


    void Start()
    {
        playerSaveData.currentStateInt = 8;
        purchasedItemData.purchasedItem = "badGift";
        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
