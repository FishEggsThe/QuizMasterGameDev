using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 10f;
    [SerializeField] float timeToShowCorrectAnswer = 6f;


    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0f;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue > 0)
        {
            fillFraction = timerValue / (isAnsweringQuestion ? timeToCompleteQuestion : timeToShowCorrectAnswer); // :DDDDD
        }
        // I think I did it way better than them idk you tell me maybe I ended up causing a memory leak apocalypse with irreversable effects
        if (timerValue <= 0)
        {
            if(isAnsweringQuestion){
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
            else if(!isAnsweringQuestion){
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        //Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
