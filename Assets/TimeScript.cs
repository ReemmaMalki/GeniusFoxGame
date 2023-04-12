using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Display the time on the game screen
public class TimeScript : MonoBehaviour
{
    AudioSource over;
    [Header("component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Setting")]
    public float CurrentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = CurrentTime * 60;
        over = GetComponent<AudioSource>();
        over.PlayDelayed((CurrentTime));
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = countDown ? CurrentTime -= Time.deltaTime : CurrentTime += Time.deltaTime;

        if (hasLimit && ((countDown && CurrentTime <= timerLimit) || (!countDown && CurrentTime >= timerLimit)))
        {
            CurrentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            SceneManager.LoadScene("GameOver");
    }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = (CurrentTime / 60).ToString("0.00");


    }

}
