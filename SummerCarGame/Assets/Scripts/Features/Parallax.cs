using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        Time.timeScale = 1;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void FixedUpdate()
    {
        if (parallaxEffect != 0)
        {


            transform.position = new Vector3(transform.position.x - 2 * (1 - parallaxEffect) * Time.deltaTime, transform.position.y, transform.position.z);
            //float temp = (transform.position.x * (1 - parallaxEffect)); // >>> 0
            //float distance = (transform.position.x * parallaxEffect); // >>> 0
            //print(distance);

            //transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

            if (transform.position.x <= -10)
                transform.position = new Vector3(transform.position.x + length, transform.position.y, transform.position.z);

            //if (distance > startpos + length)
            //    startpos += length;
            //if (distance < startpos - length)
            //    startpos -= length;
        }
        else
        {
            transform.position = new Vector3(startpos + 1 * Mathf.Sin(Time.timeSinceLevelLoad), transform.position.y, transform.position.z);

        }
    }
}
