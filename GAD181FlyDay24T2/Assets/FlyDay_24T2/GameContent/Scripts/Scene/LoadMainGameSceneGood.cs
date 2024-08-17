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
        if (purchasedItemData.purchasedItem == "goodGift" )
        {
            Debug.Log("the purchase item is good gift");
        }

        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
