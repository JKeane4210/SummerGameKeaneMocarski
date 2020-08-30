using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;

    public float parallaxEffect;
    public bool giveRandomSpeed;
    public bool giveRandomScale;
    public float screenWidth;
    public float screenHeight;

    void Start()
    {
        parallaxEffect = giveRandomSpeed ? Random.Range(3, 7) : parallaxEffect;
        if (giveRandomScale)
        {
            float randomScale = Random.Range(20, 60);
            transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
        Time.timeScale = 1;
        startpos = -screenWidth / 2;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.localPosition = new Vector3(Random.Range(-screenWidth / 2, screenWidth / 2), Random.Range(-screenHeight / 2, screenHeight / 2), 0);
    }

    void FixedUpdate()
    {
        if (parallaxEffect != 0)
        {
            transform.position = new Vector3(transform.position.x - 2 * (1 - parallaxEffect) * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.localPosition.x >= screenWidth / 2)
                transform.localPosition = new Vector3(startpos, Random.Range(-screenHeight / 2, screenHeight / 2), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(startpos + 1 * Mathf.Sin(Time.timeSinceLevelLoad), transform.localPosition.y, transform.localPosition.z);
        }
    }
}
