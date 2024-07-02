using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public void ResetScene()
    {
        SceneManager.LoadScene("SeesawBridge");
    }
    public void EnableGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

}
