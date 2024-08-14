using DutyFree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastNarrativeTrigger : MonoBehaviour
{

    #region Variables
    public PurchasedItemData purchasedItemData;
    public PlayerSaveData playerSaveData;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (purchasedItemData.purchasedItem == "goodGift")
        {
            playerSaveData.currentStateInt = 7;
            SceneManager.LoadScene("MainGameScene");
        }
        if (purchasedItemData.purchasedItem == "badGift")
        {
            playerSaveData.currentStateInt = 8;
            SceneManager.LoadScene("MainGameScene");
        }
    }
}
