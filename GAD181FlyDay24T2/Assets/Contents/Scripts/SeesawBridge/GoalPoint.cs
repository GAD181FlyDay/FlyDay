using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    private float _players = 0;
    [SerializeField] GoalPointManager GoalPointManager;

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
        GoalPointManager.EnableGameOverUI();
        Time.timeScale = 0f;
        Debug.Log("Time has been paused");
    }
}
