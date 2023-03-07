using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static Rigidbody2D player;
    public Animator animator;
    public float force;
    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player= GetComponent<Rigidbody2D>();
        audio= GetComponent<AudioSource>();
        animator.SetFloat("flyAcc", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (player.transform.position.y < 3.5)
                {
                    audio.Play();
                    player.velocity= Vector2.zero;
                    player.AddForce(Vector2.up * force);
                }

            }
        }
        animator.SetFloat("flyAcc", player.velocity.y);
    }
}
