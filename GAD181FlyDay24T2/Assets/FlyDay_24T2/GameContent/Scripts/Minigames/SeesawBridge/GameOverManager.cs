using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public void ResetScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SeesawBridge");
    }

    public void Proceed()
    {
        SceneManager.LoadScene("DontMove");
    }

    public void EnableGameOverUI()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
