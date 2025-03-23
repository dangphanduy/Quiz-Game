using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool loadNextQuestion;
    [SerializeField] float timeToComplete = 10f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;
    public float fillFraction;
    public bool isAnsweringTheQuestion;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    public void cancelTimer()
    {
        timerValue = timeToShowCorrectAnswer;
        isAnsweringTheQuestion = false;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringTheQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToComplete;
                
            }

            else
            {
                isAnsweringTheQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }

            else
            {
                isAnsweringTheQuestion = true;
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
        }
        Debug.Log(isAnsweringTheQuestion + ": " + timerValue + "= " + fillFraction);
    }
}
