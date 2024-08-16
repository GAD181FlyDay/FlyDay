using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameSceneGood : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    void Start()
    {
        playerSaveData.currentStateInt = 7;
        Invoke("LoadMainGameScene", 2f);
    }

    private void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
