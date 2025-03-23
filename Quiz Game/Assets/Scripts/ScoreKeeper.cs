using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int correctAnswers = 0;
    int questionSeen = 0;

    public int getCorrectAnswers()
    {
        return correctAnswers;
    }

    public void incrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int getQuestionSeen()
    {
        return questionSeen;
    }

    public void incrementQuestionSeen()
    {
        questionSeen++;
    }   

    public int caculateScore()
    {
        return Mathf.RoundToInt((float)correctAnswers / questionSeen * 100);
    }


}
