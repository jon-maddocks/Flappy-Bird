using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public PlayerController pc;
    public ScoreBoard sb;

    public float speed = 20.0f;
    public float posZ = 30;
    public bool gameOver=false;
    public bool scoreIncremented = false;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        sb = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameOver = pc.CheckGameOver();

        if(!gameOver)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }

        if (transform.position.z < -posZ && gameObject.CompareTag("TopObstacle") && gameObject.CompareTag("BottomObstacle"))
        {
            Destroy(gameObject);
        }

        if(GameObject.FindWithTag("TopObstacle") && transform.position.z <= -3 && transform.position.y > 0 && !scoreIncremented)
        {
            scoreIncremented= true;
            sb.IncrementScore();
        }
    }
}
