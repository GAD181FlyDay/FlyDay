using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxInventorySize = 10;

    private List<string> inventory = new List<string>();

    public void AddItem(string itemName)
    {
        if (inventory.Count < maxInventorySize)
        {
            inventory.Add(itemName);
            Debug.Log(itemName + " added to inventory.");
        }
        else
        {
            Debug.Log("Inventory full. Cannot add more items.");
        }
    }

    public void DisplayInventory()
    {
        Debug.Log("Current Inventory:");
        foreach (var item in inventory)
        {
            Debug.Log("- " + item);
        }
    }
}

