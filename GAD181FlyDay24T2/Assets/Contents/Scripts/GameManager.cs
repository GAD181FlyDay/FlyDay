using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timerText;
    public float gameDuration = 60f; 
    private float timer;
    private bool isGameOver = false;

    private int itemsCollected = 0;
    public int itemsToCollect = 10; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = gameDuration;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();

            if (timer <= 0f)
            {
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
    }

    public void AddItem(int itemId)
    {
        itemsCollected++;
        if (itemsCollected >= itemsToCollect)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You win!");
    }

    void GameOver()
    {
        Debug.Log("Game over!");
    }
}

