using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question:")]
    [SerializeField] TextMeshProUGUI QText;
    [SerializeField] List<QuestionSO> qu = new List<QuestionSO>();
    QuestionSO Q;

    [Header("Answer:")]
    [SerializeField] GameObject[] AButtons;
    int CorrectAnswerIndex;
    bool hasAnswered = true;

    [Header("Button colors:")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer:")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring:")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    [Header("Slider:")]
    [SerializeField] Slider progressBar;

    public bool isComplete = false;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        progressBar.maxValue = qu.Count;
        progressBar.value = 0;
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQues)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnswered = false;
            GetNextQuestion();
            timer.loadNextQues = false;
        }
        else if(!hasAnswered && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    void displayQuestion()
    {
        QText.text = Q.GetQuestion();
        for (int i = 0; i < AButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = AButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = Q.GetAnswer(i);
        }
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == Q.GetCorrectAnsIndex())
        {
            QText.text = "Correct!";
            buttonImage = AButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            score.incrementCorrecAnswer();
        }
        else
        {
            CorrectAnswerIndex = Q.GetCorrectAnsIndex();
            string ca = Q.GetAnswer(CorrectAnswerIndex);
            QText.text = "Wrong! Correct: " + ca;
            buttonImage = AButtons[CorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    public void OnAnswerSelected(int index)
    {
        hasAnswered = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.cancelTimer();
        scoreText.text = "Score: " + score.calcute() + "%";
    }
    void GetNextQuestion()
    {
        if(qu.Count > 0)
        {
            SetButtonState(true);
            SetButtonDefaultSprite();
            GetRandomQuestion();
            displayQuestion();
            progressBar.value++;
            score.incrementQuestionSeen();
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, qu.Count);
        Q = qu[index];
        if (qu.Contains(Q))
        {
            qu.Remove(Q);
        }
    }
    void SetButtonState(bool state)
    {
        for(int i=0;i<AButtons.Length; i++)
        {
            Button button = AButtons[i].GetComponent<Button>();
            button.interactable = state;   
        }
    }
    void SetButtonDefaultSprite()
    {
        for(int i = 0; i < AButtons.Length; i++)
        {
            Image buttonImage = AButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
