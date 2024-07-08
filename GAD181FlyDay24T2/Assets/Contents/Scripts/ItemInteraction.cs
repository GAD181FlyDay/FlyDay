using UnityEngine;

public class  ItemInteraction : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public string itemName;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                inventoryManager.AddItem(itemName);
                gameObject.SetActive(false);
            }
        }
    }
}

