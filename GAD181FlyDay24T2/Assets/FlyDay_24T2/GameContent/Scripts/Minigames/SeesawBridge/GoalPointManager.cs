using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointManager : MonoBehaviour
{
    [SerializeField] GameObject youWinPanel;
    [SerializeField] GameObject youLostPanel;

    public void EnableGameOverUI()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        youWinPanel.SetActive(true);
    }
    public void EnableLostPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        youLostPanel.SetActive(true);
    }
}
