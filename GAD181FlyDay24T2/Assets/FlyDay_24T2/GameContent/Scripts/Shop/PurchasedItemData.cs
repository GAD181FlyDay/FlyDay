using UnityEngine;

namespace DutyFree
{
    /// <summary>
    /// tracks which item players decided to choose. (bad gift or good gift.)
    /// </summary>

    [CreateAssetMenu]

    public class PurchasedItemData : ScriptableObject
    {
        public string purchasedItem; 
        public bool hasPurchased;
    }
}