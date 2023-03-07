using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public static float score { get; private set; }
    public static float highScore { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    
    public TextMeshProUGUI scoreText;
    public void IncreaseScore()
    {
        score ++;
        scoreText.text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void setHighScore(float x)
    {
        highScore = x;
    }
}
