using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    public Material red;
    public Material blue;
    public GameObject light1;
    public GameObject light2;

    private const float FLASH_INTERVAL = 0.75f;

    private Material lightMat1;
    private Material lightMat2;
    private float timeElapsed;

    void Start()
    {
        lightMat1 = red;
        lightMat2 = blue;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > FLASH_INTERVAL)
        {
            SwitchColors();
            timeElapsed = 0;
        }
    }

    public void SwitchColors()
    {
        if(lightMat1 == red)
        {
            lightMat1 = blue;
            lightMat2 = red;
        }
        else
        {
            lightMat1 = red;
            lightMat2 = blue;
        }
        light1.GetComponent<Renderer>().material = lightMat1;
        light2.GetComponent<Renderer>().material = lightMat2;
    }
}
