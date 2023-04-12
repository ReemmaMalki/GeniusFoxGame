using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManger : MonoBehaviour
{
    // a list array to store questions and it's answers
    public List<QusationAndAnswer> QnA;

    //an array to store questions options
    public GameObject[] options;

    //Variable to keep track of the question being answered
    public int currentQuestion;

    //Store the question
    public Text QuestionText;

    //keep track of the number of questions displayed (total of 5)
    public int totalQus = 0;

    //Keep track of the player's score
    public int score;

    private void Start()
    {
        totalQus = QnA.Count;
        generateQus();
    }

    public void WinGame()
    {
        //Display the winning screen
        SceneManager.LoadScene("Win Scene");
    }

    public void loss()
    {
        //Display the losing screen
        SceneManager.LoadScene("GameOver");
    }



    //Function to stores actions to be taken when the player's answer is correct
    public void correct()
    {

        score += 1; //update the score
        QnA.RemoveAt(currentQuestion); //to avoid displaying the same question twice
        StartCoroutine(WaitForNext()); //request Generate next questions
        
    }

    //Function to stores actions to be taken when the player's answer is incorrect
    public void wrong()
    {

        QnA.RemoveAt(currentQuestion); //to avoid displaying the same question twice
        StartCoroutine(WaitForNext()); //request Generate next questions
       
    }

    //functione to request next question to be displayed
    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQus();

    }

    //Function to display the questions alongside it;s answers
    void SetAnswers()
    {
        //going thriugh answer's options and displaying them
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().statColor;
            options[i].GetComponent<AnswerScript>().isCoorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCoorrect = true;
            }
        }
    }

    void generateQus()
    {
        //keep track of the number of the displayed questions
        if (QnA.Count > 0)
        {

            currentQuestion = Random.Range(0, QnA.Count); //choose a random question from  the array
            QuestionText.text = QnA[currentQuestion].Question; //display the chosen question
            SetAnswers(); //display the question's answer
        }
        else if(score==totalQus)
        {
            Debug.Log("Out of Questions and win");
            WinGame();
        }
        else
        {
            Debug.Log("Out of Questions and loss");
            loss();
        }
    }
}
