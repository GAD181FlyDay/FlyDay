using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerSaveData playerSaveData;
    public void loadAfterScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Proceed()
    {
        playerSaveData.currentStateInt = 4;
        SceneManager.LoadScene("MainGameScene");
    }
}
