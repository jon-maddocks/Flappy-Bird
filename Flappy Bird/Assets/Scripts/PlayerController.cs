using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private ScoreBoard sb;
    public AudioSource jumpSource;
    public AudioSource gameOverSource;


    public float velocity = 20.0f;
    private bool gameOver = false;

    private float topBoundary;
    private float bottomBoundary;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        sb = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();

        float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y;
        float screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        topBoundary = screenTop;
        bottomBoundary= screenBottom;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(transform.up * velocity);
            jumpSource.Play();
        }

        if (!gameOver)
        {
            // Calculate the new position of the bird
            Vector3 newPosition = transform.position;

            if (newPosition.y > topBoundary)
            {
                newPosition.y = topBoundary;
                playerRb.AddForce(new Vector3(0, -10, 0));
            }
            else if (newPosition.y < bottomBoundary + 1)
            {
                newPosition.y = bottomBoundary + 1;
                playerRb.AddForce(transform.up * velocity);
            }

            // Update the bird's position
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("TopObstacle") || collision.gameObject.CompareTag("BottomObstacle"))
        {
            gameOverSource.Play();
            gameOver = true;
            sb.GameOverScreen();
        }
    }

    public bool CheckGameOver()
    {
        return gameOver;
    }
}

/* TODO: Add - background, player sprite, obstacle sprites
 *       Audio - BGM, jump sounds, game over sound
 *       Particle effects
 * 
 */