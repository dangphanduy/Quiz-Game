using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Question", menuName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Nhập câu hỏi ở đây";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 0;
    public String getQuestion()
    {
        return question;
    }

    public string getAnswers(int index)
    {
        return answers[index];
    }

    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
