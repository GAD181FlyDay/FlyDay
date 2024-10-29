using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerSaveData
{
    public float mainLuckyCoinsSource;
    public int currentStateInt = 0;

    private static string FilePath => Path.Combine(Application.persistentDataPath, "PlayerSaveData.json");

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(FilePath, jsonData);
    }

    public static PlayerSaveData LoadData()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = File.ReadAllText(FilePath);
            return JsonUtility.FromJson<PlayerSaveData>(jsonData);
        }
        return new PlayerSaveData();
    }
}
