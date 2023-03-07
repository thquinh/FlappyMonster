using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    Rigidbody2D pipe;
    public float speed;
    GameController controller;
    private bool temp;
    public AudioClip passClip;
    public AudioClip breakHighScClip;
    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        pipe = GetComponent<Rigidbody2D>();
        controller = FindObjectOfType<GameController>();
        audio = GetComponent<AudioSource>();
        temp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -3 && temp)
        {
            if (ScoreManager.score == ScoreManager.highScore)
            {
                audio.clip = breakHighScClip;
                audio.Play();
            } else
            {
                audio.clip = passClip;
                audio.Play();
            }
            ScoreManager.Instance.IncreaseScore();
            temp= false;
        } else if (transform.position.x <= -4)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.isGameOver= true;
        }
    }
}
