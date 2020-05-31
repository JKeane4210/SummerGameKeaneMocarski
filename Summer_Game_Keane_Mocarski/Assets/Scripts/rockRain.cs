using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockRain : MonoBehaviour
{
    public GameObject g;
    public int interval;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    private int count = 0;
    private int rockCount;

    private void Start()
    {
        if(xMin > xMax)
        {
            float temp = xMin;
            xMin = xMax;
            xMax = temp;
        }
        if (zMin > zMax)
        {
            float temp = zMin;
            zMin = zMax;
            zMax = temp;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        count++;
        if((count != 0 && count % interval == 0) && rockCount <= 10)
        {
            float randScale = Random.Range(1f, 5f);
            Vector3 randPosition = new Vector3(Random.Range(xMin, xMax), 100f, Random.Range(zMin, zMax));
            GameObject boulder = g;
            //boulder.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0f, Mathf.PI * 2f), Random.Range(0f, Mathf.PI * 2f), Random.Range(0f, Mathf.PI * 2f));
            boulder.transform.localScale = new Vector3(randScale, randScale, randScale);
            Instantiate(boulder, randPosition, Quaternion.identity);
            rockCount++;
            print(boulder.GetComponent<Rigidbody>().angularVelocity);
        }
    }
}
