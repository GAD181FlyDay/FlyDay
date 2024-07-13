using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId; 
    public GameObject collectedEffect;

    private bool isCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        isCollected = true;
        if (collectedEffect != null)
        {
            Instantiate(collectedEffect, transform.position, Quaternion.identity);
        }
        GameManager.Instance.AddItem(itemId); 
        gameObject.SetActive(false); 
    }
}

