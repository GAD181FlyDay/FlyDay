using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int itemCount = 0;
    public int totalItems = 10;
    public Text inventoryText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem(GameObject item)
    {
        itemCount++;
        Destroy(item);
        UpdateInventoryUI();
        CheckWinCondition();
    }

    void UpdateInventoryUI()
    {
        inventoryText.text = "Items Collected: " + itemCount + "/" + totalItems;
    }

    void CheckWinCondition()
    {
        if (itemCount >= totalItems)
        {
            //GameManager.instance.WinGame();
        }
    }
}

