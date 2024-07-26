using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int totalItems = 20;
    public int itemsCollected = 0;
    public TMP_Text winLoseText;

    public void UpdateItemCount()
    {
        itemsCollected++;
        if (itemsCollected >= totalItems)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        // Implement win logic here
        Debug.Log("You Win!");
        winLoseText.text = "You Win!";
        // Add reward logic
        PlayerPrefs.SetInt("LuckyCoins", PlayerPrefs.GetInt("LuckyCoins", 0) + 200);
    }

    public void LoseGame()
    {
        // Implement lose logic here
        Debug.Log("You Lose!");
        winLoseText.text = "You Lose!";
        // Reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
