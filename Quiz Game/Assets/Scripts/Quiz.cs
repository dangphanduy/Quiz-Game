using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        getNextQuestion();
        //displayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if(index == questionSO.getCorrectAnswerIndex())
        {
            questionText.text = "It's correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = questionSO.getCorrectAnswerIndex();
            string correctAnswer = questionSO.getAnswers(correctAnswerIndex);
            questionText.text = "It's wrong! The correct answer is:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        setButtonState(false);
    }

    void getNextQuestion()
    {
        setButtonState(true);
        setDefaultButtonSprite();
        displayQuestion();
    }
    void displayQuestion()
    {
        questionText.text = questionSO.getQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSO.getAnswers(i);
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
