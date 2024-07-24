using UnityEngine;

[CreateAssetMenu]
public class PlayerSaveData : ScriptableObject
{
    #region Dana's added Variables
    public Vector3 playerOnePos;
    public Vector3 playerTwoPos;
    public float mainLuckyCoinsSource;
    #endregion

    public int money;
    public string currentScene;
    public DialogueStage currentDialogueStage;
    public Vector3 position; 
}
