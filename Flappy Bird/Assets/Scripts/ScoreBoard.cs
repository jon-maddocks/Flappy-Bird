using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText= GetComponent<TextMeshProUGUI>();

        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOverScreen()
    {
        scoreText.text = $"GAME OVER.\nFinal score: {score}";
        scoreText.fontStyle = FontStyles.Bold;
        scoreText.color = Color.red;
        scoreText.transform.position = new Vector3(scoreText.transform.position.x-20, scoreText.transform.position.y/2, 0);
    }
}
