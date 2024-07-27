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
        Debug.Log("You Win!");
        winLoseText.text = "You Win!";
        PlayerPrefs.SetInt("LuckyCoins", PlayerPrefs.GetInt("LuckyCoins", 0) + 200);
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        winLoseText.text = "You Lose!";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
