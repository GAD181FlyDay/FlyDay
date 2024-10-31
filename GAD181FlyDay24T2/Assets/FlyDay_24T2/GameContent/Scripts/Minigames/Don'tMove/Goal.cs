using UnityEngine;

public class Goal : MonoBehaviour
{
    private float _players = 0;
    private float _earnedMoney = 200;
    public GameObject panel;
    public GameObject win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _players += 1;

            if (_players == 2)
            {
                EndPointReached();
            }
        }
    }

    public void EndPointReached()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        DataManager.Instance.UpdateCoinAmount(_earnedMoney);
        DataManager.Instance.SetGameState(4);

        panel.SetActive(true);
        win.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Time has been paused");
    }
}
