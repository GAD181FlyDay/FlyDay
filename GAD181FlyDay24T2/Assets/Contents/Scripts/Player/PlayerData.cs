using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerMoney;
    public int playerMischief;
   
}

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        LoadPlayerData();
    }

    public void SavePlayerData()
    {

        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData"));
        }
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}
