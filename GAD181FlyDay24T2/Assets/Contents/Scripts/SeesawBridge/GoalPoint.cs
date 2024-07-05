using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] GoalPointManager GoalPointManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GoalPointManager.EnableGameOverUI();
            Time.timeScale = 0f;
            Debug.Log("Time has been paused");
        }
    }
}
