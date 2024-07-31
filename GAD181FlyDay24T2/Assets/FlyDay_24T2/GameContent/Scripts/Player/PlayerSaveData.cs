using UnityEngine;

[CreateAssetMenu]
public class PlayerSaveData : ScriptableObject
{
    #region Dana's added Variables
    public float mainLuckyCoinsSource;
    public int currentStateInt = 0;
    #endregion

    public int money;
    public string currentScene;
    public DialogueStage currentDialogueStage;
    public Vector3 position; 
}
