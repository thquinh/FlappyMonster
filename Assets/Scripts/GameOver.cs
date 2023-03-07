using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScore;
    public GameObject gameOverPanel;
    public static GameOver Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public void setYourScoreText()
    {
        yourScore.text = "Your score: " + ScoreManager.score;
        highScore.text = "High Score: " + ScoreManager.highScore;
    }

    public void showPanel(bool c)
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(c);
    }


}
