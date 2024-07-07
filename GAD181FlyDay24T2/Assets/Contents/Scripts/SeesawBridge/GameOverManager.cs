using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public void ResetScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SeesawBridge");
    }
    public void EnableGameOverUI()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
