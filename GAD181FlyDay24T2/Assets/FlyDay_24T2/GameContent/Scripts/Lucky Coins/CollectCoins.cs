using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private PlayerSaveData playerTotalMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerTotalMoney != null)
            {
                playerTotalMoney.mainLuckyCoinsSource += 5;
                Debug.Log("You just earned + 5 coins! Here's how much money you've got in total: " + playerTotalMoney.mainLuckyCoinsSource);
            }

            //Debug.Log("You got +5 Lucky Coins!!! ");
            Destroy(Coin);
        }
    }

    private void Start()
    {
        Coin = this.gameObject;
    }
}