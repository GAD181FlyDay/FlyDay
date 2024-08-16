using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGameScene : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    void Start()
    {
        playerSaveData.currentStateInt = 5;
        Invoke("LoadTheMainGameScene", 2f);
    }

    private void LoadTheMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
