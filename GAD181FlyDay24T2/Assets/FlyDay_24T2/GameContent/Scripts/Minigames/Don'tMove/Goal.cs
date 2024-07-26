using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private float _players = 0;
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
        panel.SetActive(true);
        win.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Time has been paused");
    }
}
