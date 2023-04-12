using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AnswerScript : MonoBehaviour
{
    public bool isCoorrect = false;

    //QuizManager object to be able to access the functions
    public QuizManger quizManger;

    //Answer background color
    public Color statColor;

    public void Start()
    {
        statColor = GetComponent<Image>().color;
    }

        //Function to change answer background color and send the type of the answer (True, False) 
        //to the quiz manager to be able to keep track of the player's score
    public void Answer()
    {
        if (isCoorrect)
        {
            //set answer background color to green since it's true
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");

            //Send answer type to quiz manager to update score
            quizManger.correct();
        }
        else
        {
            //set answer background color to red since it's not true
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");

            //Send answer type to quiz manager to update score
            quizManger.wrong();
        }
    }
}
