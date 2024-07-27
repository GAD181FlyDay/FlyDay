using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeightGameManager : MonoBehaviour
{
    public WeightGauge weightGauge;
    public TMP_text resultText;
    public Button retryButton;
    public Button payButton; 
    public int luckyCoinsPenalty = 50;
    public int luckyCoinsReward = 5;

    private bool playersReady = false;

    void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        payButton.onClick.AddListener(PayPenalty);
        retryButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playersReady && Input.GetKeyDown(KeyCode.Space))
        {
            weightGauge.StopGauge();
        }

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.RightControl))
        {
            playersReady = true;
        }
    }

    public void CheckWeight()
    {
        float weight = Mathf.Lerp(0, 60, (weightGauge.arrow.localEulerAngles.z + 90) / 180);
        if (weight >= 29.5f && weight <= 30.5f)
        {
            resultText.text = "You Win! +5 Lucky Coins";
            PlayerPrefs.SetInt("LuckyCoins", PlayerPrefs.GetInt("LuckyCoins", 0) + luckyCoinsReward);
        }
        else
        {
            resultText.text = "You Lose!";
        }

        retryButton.gameObject.SetActive(true);
    }

    public void RetryGame()
    {
        resultText.text = "";
        retryButton.gameObject.SetActive(false);
        playersReady = false;
        weightGauge.ResetGauge();
    }

    public void PayPenalty()
    {
        int luckyCoins = PlayerPrefs.GetInt("LuckyCoins", 0);
        if (luckyCoins >= luckyCoinsPenalty)
        {
            PlayerPrefs.SetInt("LuckyCoins", luckyCoins - luckyCoinsPenalty);
            resultText.text = "You Paid 50 Lucky Coins";
        }
        else
        {
            resultText.text = "Not Enough Lucky Coins!";
        }
    }
}

