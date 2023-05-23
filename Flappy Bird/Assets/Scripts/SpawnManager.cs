using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController pc;
    public GameObject topObstacle;
    public GameObject bottomObstacle;

    public int spaceBetween = 16;
    public float posY = 8.0f;
    public float posZ = 27.0f;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.CheckGameOver())
        {
            CancelInvoke("SpawnObstacles");
        }
    }

    void SpawnObstacles()
    {
        float topRange = Random.Range(7, 16);
        float bottomRange = topRange - spaceBetween;

        topObstacle = Instantiate(topObstacle, new Vector3(0, topRange, posZ), topObstacle.transform.rotation);
        topObstacle.tag = "TopObstacle";
        bottomObstacle = Instantiate(bottomObstacle, new Vector3(0, bottomRange, posZ), bottomObstacle.transform.rotation);
        bottomObstacle.tag = "BottomObstacle";
    }
}
