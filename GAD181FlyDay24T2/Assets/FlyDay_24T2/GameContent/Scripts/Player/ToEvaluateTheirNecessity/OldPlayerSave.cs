using UnityEngine;
using UnityEngine.SceneManagement;

public class OldPlayerSave : MonoBehaviour
{
    private const string MoneyKey = "Money";
    private const string SceneKey = "CurrentScene";
    private const string DialogueStageKey = "CurrentDialogueStage";
    private const string PositionXKey = "PositionX";
    private const string PositionYKey = "PositionY";
    private const string PositionZKey = "PositionZ";

    private PlayerSaveData playerData;

    private void Start()
    {
        playerData = GameObject.Find("GameManager").GetComponent<PlayerSaveData>();
        if (playerData == null)
        {
            Debug.LogError("PlayerData script not found!");
        }
    }

    public static void SavePlayerStuff(PlayerSaveData saveData)
    {
        PlayerPrefs.SetInt(MoneyKey, saveData.money);
        PlayerPrefs.SetString(SceneKey, saveData.currentScene);
        PlayerPrefs.SetString(DialogueStageKey, saveData.currentDialogueStage.ToString());
        PlayerPrefs.SetFloat(PositionXKey, saveData.position.x);
        PlayerPrefs.SetFloat(PositionYKey, saveData.position.y);
        PlayerPrefs.SetFloat(PositionZKey, saveData.position.z);

        PlayerPrefs.Save();
    }

    public static PlayerSaveData LoadPlayerData(PlayerSaveData playerData)
    {
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            playerData.money = PlayerPrefs.GetInt(MoneyKey);
            playerData.currentScene = PlayerPrefs.GetString(SceneKey);
            playerData.currentDialogueStage = (DialogueStage)System.Enum.Parse(typeof(DialogueStage), PlayerPrefs.GetString(DialogueStageKey));
            playerData.position = new Vector3(
                PlayerPrefs.GetFloat(PositionXKey),
                PlayerPrefs.GetFloat(PositionYKey),
                PlayerPrefs.GetFloat(PositionZKey));
        }
        else
        {
            playerData.money = 0;
            playerData.currentScene = SceneManager.GetActiveScene().name;
            playerData.currentDialogueStage = DialogueStage.PacHouse;
            playerData.position = Vector3.zero;
        }
        return playerData;
    }

    // Reward System
    public void Reward(int amount)
    {
        if (playerData != null)
        {
            playerData.money += amount;
            Debug.Log("Money added: " + amount + ". Total money: " + playerData.money);
        }
        else
        {
            Debug.LogError("PlayerData script not found");
        }
    }
}