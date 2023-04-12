using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Display the score on the game screen

public class ScoreScript : MonoBehaviour
{
    public Text ScoreTxt;

    public QuizManger quizManger;

    public void Start()
    {
        ScoreTxt.text = quizManger.score + "/" + quizManger.totalQus;
    }

    void Update()
    {
        ScoreTxt.text = quizManger.score + "/" + quizManger.totalQus;
    }
}
