using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string ques = "Enter new question";
    [SerializeField] string[] ans = new string[4];
    [SerializeField] int correctAnsIndex;
    public string GetQuestion()
    {
        return ques;
    }
    public string GetAnswer(int index)
    {
        return ans[index];
    }
    public int GetCorrectAnsIndex()
    {
        return correctAnsIndex;
    }
}
