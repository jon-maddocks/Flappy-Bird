using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    public float posZ = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        if (transform.position.z < -posZ && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
