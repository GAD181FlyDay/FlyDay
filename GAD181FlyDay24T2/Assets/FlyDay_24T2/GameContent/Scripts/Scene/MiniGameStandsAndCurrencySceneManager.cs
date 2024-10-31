using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Hello!! Attach to any game object within main game scene!!!

public class MiniGameStandsAndCurrencySceneManager : MonoBehaviour
{
    #region Variables.
    public string sceneToAlwaysLoad = "MinigameStands";
    [SerializeField] private TMP_Text currencyText;
    private float lastKnownCoinAmount;
    #endregion

    private void Start()
    {
        lastKnownCoinAmount = DataManager.Instance.PlayerData.mainLuckyCoinsSource;
        UpdateCurrencyText();

        if (!SceneManager.GetSceneByName(sceneToAlwaysLoad).isLoaded)
        {
            SceneManager.LoadScene("MinigameStands", LoadSceneMode.Additive);
        }
    }

    private void Update()
    {
        if (DataManager.Instance.PlayerData.mainLuckyCoinsSource != lastKnownCoinAmount)
        {
            lastKnownCoinAmount = DataManager.Instance.PlayerData.mainLuckyCoinsSource;
            UpdateCurrencyText();
        }
    }

    private void UpdateCurrencyText()
    {
        currencyText.text = DataManager.Instance.PlayerData.mainLuckyCoinsSource.ToString();
    }
}
