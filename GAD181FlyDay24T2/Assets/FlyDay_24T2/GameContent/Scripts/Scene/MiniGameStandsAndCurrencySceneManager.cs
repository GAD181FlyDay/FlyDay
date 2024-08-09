using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Hello!! Attach to any game object within main game scene!!!

public class MiniGameStandsAndCurrencySceneManager : MonoBehaviour
{
    #region Variables.
    public string sceneToAlwaysLoad = "MinigameStands"; 
    public PlayerSaveData playerSaveData;

    [SerializeField] private TMP_Text currencyText;
    #endregion

    private void Start()
    {
        currencyText.text = playerSaveData.mainLuckyCoinsSource + "";
        if (!SceneManager.GetSceneByName(sceneToAlwaysLoad).isLoaded)
        {
            SceneManager.LoadScene("MinigameStands", LoadSceneMode.Additive);
        }
    }
}
