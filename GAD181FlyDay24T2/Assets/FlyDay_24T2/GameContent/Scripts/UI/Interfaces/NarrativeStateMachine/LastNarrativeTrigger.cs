using DutyFree;
using UnityEngine;

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
        }
        if (purchasedItemData.purchasedItem == "badGift")
        {
            playerSaveData.currentStateInt = 8;
        }
    }
}
