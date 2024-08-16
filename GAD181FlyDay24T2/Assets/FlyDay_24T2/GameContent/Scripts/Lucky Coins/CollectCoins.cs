using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    #region Variables.
    [SerializeField] private GameObject Coin;
    [SerializeField] private PlayerSaveData playerTotalMoney;
    [SerializeField] private AudioClip luckyCoinCollectedSound;
    [SerializeField] private AudioSource audioSource;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerTotalMoney != null)
            {
                playerTotalMoney.mainLuckyCoinsSource += 5;
                Debug.Log("You just earned +5 coins! Here's how much money you've got in total: " + playerTotalMoney.mainLuckyCoinsSource);
            }

            if (luckyCoinCollectedSound != null)
            {
                audioSource.PlayOneShot(luckyCoinCollectedSound);
            }
            Destroy(Coin);
        }
    }

    private void Start()
    {
        Coin = this.gameObject;
    }
}