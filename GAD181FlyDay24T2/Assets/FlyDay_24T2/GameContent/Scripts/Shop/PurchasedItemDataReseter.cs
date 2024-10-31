using DutyFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PurchasedItemDataReseter : MonoBehaviour
{
    private PurchasedItemData purchasedItemData;

    private void Start()
    {
        purchasedItemData = PurchasedItemData.LoadData();
    }
    public void ResetPurchasedData()
    {
        purchasedItemData.ResetData();
    }
}
