using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private PlayerSaveData playerSaveData;
    private float _players = 0;
    private float _earnedMoney = 200;
    public GameObject panel;
    public GameObject win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _players += 1; ;

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
        playerSaveData.mainLuckyCoinsSource += _earnedMoney;
        playerSaveData.currentStateInt = 4;
        panel.SetActive(true);
        win.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Time has been paused");
    }
}
