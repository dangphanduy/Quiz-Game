using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [System.Obsolete]
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void showFinalScore() 
    {
        scoreText.text = "Congratulation!\nYou score " + scoreKeeper.caculateScore() + "%";
    }

}
