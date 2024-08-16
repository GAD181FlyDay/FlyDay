using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerSaveData playerSaveData;
    public void loadAfterScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Proceed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerSaveData.currentStateInt = 4;
        SceneManager.LoadScene("MainGameScene");
    }
}
