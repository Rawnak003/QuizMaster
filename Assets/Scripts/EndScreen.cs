using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalText;
    Score score;
    void Awake()
    {
        score = FindObjectOfType<Score>();
    }
    public void ShowResult()
    {
        finalText.text = "Congratulation!!!\nYour Score: " + score.calcute() + "%";
    }
}
