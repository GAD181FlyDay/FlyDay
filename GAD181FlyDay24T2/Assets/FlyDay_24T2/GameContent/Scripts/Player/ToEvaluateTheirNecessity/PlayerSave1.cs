using UnityEngine;

namespace player.save.data.part.two
{


    public class PlayerSave1 : MonoBehaviour
    {
        private const string MoneyKey = "Money";
        private const string SceneKey = "CurrentScene";
        private const string DialogueStageKey = "CurrentDialogueStage";
        private const string PositionXKey = "PositionX";
        private const string PositionYKey = "PositionY";
        private const string PositionZKey = "PositionZ";

        public static void SavePlayerStuff(PlayerSaveData saveData)
        {
            PlayerPrefs.SetInt(MoneyKey, saveData.money);
            PlayerPrefs.SetString(SceneKey, saveData.currentScene);
            PlayerPrefs.SetString(DialogueStageKey, saveData.currentDialogueStage.ToString());
            PlayerPrefs.SetFloat(PositionYKey, saveData.position.y);
            PlayerPrefs.SetFloat(PositionXKey, saveData.position.x);
            PlayerPrefs.SetFloat(PositionZKey, saveData.position.z);

            PlayerPrefs.Save();
        }

        //public static PlayerSaveData LoadPlayerData()
        //{
        //    PlayerSaveData playerData;
        //}
    }
}