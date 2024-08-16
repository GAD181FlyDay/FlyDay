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
        if (purchasedItemData.purchasedItem == "badGift")
        {
            Debug.Log("the purchase item is bad gift");
        }
        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
