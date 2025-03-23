using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswered = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    public bool isCompleted;


    [System.Obsolete]
    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isCompleted = true;
                return;
            }
            hasAnswered = false;
            timer.loadNextQuestion = false;
            getNextQuestion();
        }
        else if(!hasAnswered && !timer.isAnsweringTheQuestion)
        {
            displayAnswer(-1);
            setButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnswered = true;
        displayAnswer(index);
        setButtonState(false);
        timer.cancelTimer();
        scoreText.text = "Score: " + scoreKeeper.caculateScore() + "%";
    }

    void displayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestion.getCorrectAnswerIndex())
        {
            questionText.text = "It's correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.incrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            string correctAnswer = currentQuestion.getAnswers(correctAnswerIndex);
            questionText.text = "It's wrong! The correct answer is:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    void getNextQuestion()
    {
        if(questions.Count > 0)
        {
            getRamdomQuestion();
            displayQuestion();
            setButtonState(true);
            setDefaultButtonSprite();
            progressBar.value++;
            scoreKeeper.incrementQuestionSeen();
        }
    }

    void getRamdomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    void displayQuestion()
    {
        questionText.text = currentQuestion.getQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswers(i);
        }
    }

    void setButtonState(bool state)
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void setDefaultButtonSprite()
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
