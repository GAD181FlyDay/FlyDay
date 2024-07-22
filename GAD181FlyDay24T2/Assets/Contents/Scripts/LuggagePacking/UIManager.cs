using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject interactText;
    public Text timerText;

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

    public void ShowInteractText(bool show)
    {
        interactText.SetActive(show);
    }

    public void UpdateTimerUI(float timeRemaining)
    {
        timerText.text = "Time Remaining: " + Mathf.Ceil(timeRemaining).ToString() + "s";
    }
}

