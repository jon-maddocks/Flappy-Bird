using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    public float repeatWidth = 80;

    private bool gameOver = false;
    public float speed = 5.0f;

    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        startPosition = transform.position;
        // repeatWidth = GetComponent<BoxCollider>().size.z/2;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = pc.CheckGameOver();

        if (!gameOver)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }


        if (transform.position.z < startPosition.z - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
