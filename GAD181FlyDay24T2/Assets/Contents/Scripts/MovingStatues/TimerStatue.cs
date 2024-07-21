using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerStatue : MonoBehaviour
{
    [SerializeField] int startTime = 10;
    private float currentTime;
    [SerializeField] GoalPointManager goalPointManager;
    [SerializeField] TextMeshProUGUI timerValue;   
   void CountDown()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            int currentTimeInt = (int)currentTime;
            timerValue.text = currentTimeInt.ToString(); 
        }
        else
        {
            goalPointManager.EnableLostPanel();
            Time.timeScale = 0f;
        }
    }

    private void Start()
    {
        currentTime = startTime;    
    }

    private void Update()
    {
        CountDown();
    }
}
