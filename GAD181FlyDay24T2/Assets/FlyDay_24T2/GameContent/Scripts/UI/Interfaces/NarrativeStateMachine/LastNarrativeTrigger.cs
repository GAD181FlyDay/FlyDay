using DutyFree;
using Narrative;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastNarrativeTrigger : MonoBehaviour
{

    #region Variables
    public PurchasedItemData purchasedItemData;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (purchasedItemData.purchasedItem == "goodGift")
        {
            SceneManager.LoadScene("LoadMainGameGoodScene");
        }
        if (purchasedItemData.purchasedItem == "badGift")
        {
            SceneManager.LoadScene("LoadMainGameBadScene");
        }
    }

}
