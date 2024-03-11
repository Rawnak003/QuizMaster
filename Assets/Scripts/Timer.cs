using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToQues = 30f;
    [SerializeField] float timeToAns = 10f;

    public bool loadNextQues;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;
    void Update()
    {
        UpdateTime();
    }
    public void cancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTime()
    {
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToQues;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToAns;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToAns;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToQues;
                loadNextQues = true;
            }
        }
    }
}
