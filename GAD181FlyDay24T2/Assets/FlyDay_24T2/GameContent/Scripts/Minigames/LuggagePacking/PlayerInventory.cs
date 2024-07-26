using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int itemsCollected = 0;
    public int totalItems = 20;
    public TMP_Text inventoryText;
    public GameObject Manager;
    public string interactKey = "E";

    //void Update()
    //{
        //if (Input.GetKeyDown(interactKey))
       // {
            // Implement item interaction logic here
           // RaycastHit hit;
           // if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
           // {
                //if (hit.collider.GetComponent<ItemCollector>())
                //{
                  //  hit.collider.GetComponent<ItemCollector>().SendMessage("OnTriggerEnter", GetComponent<Collider>());
               // }
          //  }
        //}
    //}

    public void CollectItem()
    {
        itemsCollected++;
        inventoryText.text = "Items Collected: " + itemsCollected;
        Manager.GetComponent<Manager>().UpdateItemCount();
    }
}

