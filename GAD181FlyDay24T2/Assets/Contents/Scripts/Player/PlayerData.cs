using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerLevel;
    public float playerHealth;
    public Vector3 playerPosition;
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
        playerData.playerPosition = transform.position;
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData"));
            transform.position = playerData.playerPosition;
        }
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}
