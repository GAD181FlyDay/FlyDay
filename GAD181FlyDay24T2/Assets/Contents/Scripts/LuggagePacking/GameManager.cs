using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager instance;
    public float timeLimit = 60f;
    private float timeRemaining;
    private bool gameActive = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;
            UIManager.instance.UpdateTimerUI(timeRemaining);

            if (timeRemaining <= 0)
            {
                LoseGame();
            }
        }
    }

    public void WinGame()
    {
        gameActive = false;
        UIManager.instance.ShowWinScreen();
    }

    public void LoseGame()
    {
        gameActive = false;
        UIManager.instance.ShowLoseScreen();
        Invoke("RestartGame", 3f); // Restart game after 3 seconds
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


