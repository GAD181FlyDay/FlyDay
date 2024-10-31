using System;
using System.IO;
using UnityEngine;

namespace DutyFree
{
    [Serializable]
    public class PurchasedItemData
    {
        public string purchasedItem;
        public bool hasPurchased;

        private static string FilePath => Path.Combine(Application.persistentDataPath, "PurchasedItemData.json");

        public void SaveData()
        {
            string jsonData = JsonUtility.ToJson(this, true);
            File.WriteAllText(FilePath, jsonData);
        }
        public static PurchasedItemData LoadData()
        {
            if (File.Exists(FilePath))
            {
                string jsonData = File.ReadAllText(FilePath);
                return JsonUtility.FromJson<PurchasedItemData>(jsonData);
            }
            return new PurchasedItemData();
        }
        public void ResetData()
        {
            purchasedItem = "";   
            hasPurchased = false; 
            SaveData();           
        }
    }
}
