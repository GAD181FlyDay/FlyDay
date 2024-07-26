using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
    private const string MoneyKey = "Money";
    private const string SceneKey = "CurrentScene";
    private const string DialogueStageKey = "CurrentDialogueStage";
    private const string PositionXKey = "PositionX";
    private const string PositionYKey = "PositionY";
    private const string PositionZKey = "PositionZ";
    
    public static void SavePlayerStuff(PlayerSaveData saveData)
    {
        PlayerPrefs.SetInt(MoneyKey,saveData.money);
        PlayerPrefs.SetString(SceneKey,saveData.currentScene);
        PlayerPrefs.SetString(DialogueStageKey,saveData.currentDialogueStage.ToString());
        PlayerPrefs.SetFloat (PositionYKey,saveData.position.y);
        PlayerPrefs.SetFloat (PositionXKey,saveData.position.x);
        PlayerPrefs.SetFloat(PositionZKey, saveData.position.z);

        PlayerPrefs.Save();
    }

    public static PlayerSaveData LoadPlayerData(PlayerSaveData playerData)
    {
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            playerData.money = PlayerPrefs.GetInt(MoneyKey);
            playerData.currentScene = PlayerPrefs.GetString(SceneKey);
            playerData.currentDialogueStage = (DialogueStage)System.Enum.Parse(typeof(DialogueStage),
            PlayerPrefs.GetString(DialogueStageKey));
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
}
