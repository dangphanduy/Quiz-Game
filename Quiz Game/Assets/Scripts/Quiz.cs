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
        questionText.text = questionSO.getQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSO.getAnswers(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        if(index == questionSO.getCorrectAnswerIndex())
        {
            questionText.text = "It's correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

    }
}
