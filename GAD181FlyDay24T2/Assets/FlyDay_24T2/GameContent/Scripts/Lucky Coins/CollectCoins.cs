using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private AudioClip luckyCoinCollectedSound;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        Coin = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DataManager.Instance.UpdateCoinAmount(5);

            Debug.Log("You just earned +5 coins! Here's how much money you've got in total: " + DataManager.Instance.PlayerData.mainLuckyCoinsSource);

            if (luckyCoinCollectedSound != null)
            {
                audioSource.PlayOneShot(luckyCoinCollectedSound);
            }
            Destroy(Coin);
        }
    }
}
