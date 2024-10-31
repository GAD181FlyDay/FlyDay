using DutyFree;
using UnityEngine;

public class LastNarrativeTrigger : MonoBehaviour
{
    #region Variables
    public PurchasedItemData purchasedItemData;
    private bool hasTriggered = false;  // Prevents multiple triggers
    #endregion

    private void Start()
    {
        purchasedItemData = PurchasedItemData.LoadData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        hasTriggered = true;

        if (purchasedItemData.purchasedItem == "goodGift")
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(7);
        }
        else if (purchasedItemData.purchasedItem == "badGift")
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(8);
        }
        else
        {
            Debug.LogWarning("No purchase detected.");
        }

    }
}
