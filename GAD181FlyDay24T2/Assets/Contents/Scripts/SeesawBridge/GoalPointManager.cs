using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointManager : MonoBehaviour
{
    [SerializeField] GameObject youWinPanel;
    [SerializeField] GameObject youLostPanel;

    public void EnableGameOverUI()
    {
        youWinPanel.SetActive(true);
    }
    public void EnableLostPanel()
    {
        youLostPanel.SetActive(true);
    }
}
