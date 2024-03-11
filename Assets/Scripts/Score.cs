using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers = 0;
    int QuestionSeen = 0;
    public int GetCorrectAnswer()
    {
        return correctAnswers;
    }
    public void incrementCorrecAnswer()
    {
        correctAnswers++;
    }
    public int GetQuestionSeen()
    {
        return QuestionSeen;
    }
    public void incrementQuestionSeen()
    {
        QuestionSeen++;
    }
    public int calcute()
    {
        return Mathf.RoundToInt(correctAnswers/(float)QuestionSeen*100);
    }
}
