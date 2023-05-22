using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject topObstacle;
    public GameObject bottomObstacle;
    public float posY = 8.0f;
    public float posZ = 27.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacles()
    {
        float topRange = Random.Range(7, 16);
        float bottomRange = Random.Range(7, 16);

        topObstacle = Instantiate(topObstacle, new Vector3(0, topRange, posZ), topObstacle.transform.rotation);
        bottomObstacle = Instantiate(bottomObstacle, new Vector3(0, -topRange, posZ), bottomObstacle.transform.rotation);
    }
}
