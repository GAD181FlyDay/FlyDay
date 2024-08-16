using DutyFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameSceneGood : MonoBehaviour
{
    public PlayerSaveData playerSaveData;
    public PurchasedItemData purchasedItemData;

    void Start()
    {
        playerSaveData.currentStateInt = 7;
        purchasedItemData.purchasedItem = "goodGift";
        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
