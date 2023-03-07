using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public Animator animator;
    public float spawnTime;
    float temp;
    public bool isGameOver;
    private new AudioSource audio;
    private bool wait = false;

    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
        audio= GetComponent<AudioSource>();
        ScoreManager.Instance.resetScore();
        ScoreManager.Instance.setHighScore(PlayerPrefs.GetFloat("highScore", 0));
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && !wait)
        {
            EndGame();
            GameOver.Instance.setYourScoreText();
            GameOver.Instance.showPanel(true);
        } else
        {
            temp -= Time.deltaTime;
            if(temp <= 0)
            {
                SpawnObstacle();
                temp = spawnTime;
            }
        }
    }

    public void SpawnObstacle()
    {
        float randYPos = Random.Range(-5.5f, 1);
        Vector2 spawnPos = new Vector2(2, randYPos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void EndGame()
    {
        audio.Play();
        wait = true;
        if (ScoreManager.score > ScoreManager.highScore)
        {
            ScoreManager.Instance.setHighScore(ScoreManager.score);
            PlayerPrefs.SetFloat("highScore", ScoreManager.score);
        }
        Time.timeScale = 0;
    }

    public void Restart()
    {
        wait = false;
        GameOver.Instance.showPanel(false);
        ScoreManager.Instance.resetScore();
        SceneManager.LoadScene(1);
    }
}
