using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointManager : MonoBehaviour
{
    [SerializeField] GameObject youWinPanel;

    public void EnableGameOverUI()
    {
        youWinPanel.SetActive(true);
    }
}
