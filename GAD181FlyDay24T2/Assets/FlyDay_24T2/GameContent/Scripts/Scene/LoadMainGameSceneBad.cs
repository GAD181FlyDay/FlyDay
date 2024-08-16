using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameSceneBad : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    void Start()
    {
        playerSaveData.currentStateInt = 8;
        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
