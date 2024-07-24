using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField]private GameObject Coin;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // playerEnter = true;
            Destroy(Coin);
            Debug.Log("You got +5 Lucky Coins!!! ");
        }
    }

    private void Start()
    {
        Coin = this.gameObject;
    }
}