using DutyFree;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Variables.
    public static DataManager Instance { get; private set; }
    public PlayerSaveData PlayerData { get; private set; }

    private PurchasedItemData purchasedItemData;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region Public Functions.
    public void SaveData()
    {
        PlayerData.SaveData();
    }

    public void UpdateCoinAmount(float amount)
    {
        PlayerData.mainLuckyCoinsSource += amount;
        SaveData();
    }

    public void SetGameState(int newState)
    {
        PlayerData.currentStateInt = newState;
        SaveData();
    }

    public void ResetGameData()
    {
        PlayerData.mainLuckyCoinsSource = 200;  
        PlayerData.currentStateInt = 0;  
        PlayerData.SaveData();
    }
    #endregion

    #region Private Functions.
    private void LoadData()
    {
        PlayerData = PlayerSaveData.LoadData();
    }
    #endregion

}
