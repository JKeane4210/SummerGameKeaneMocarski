using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    public Material red;
    public Material blue;
    public Color redColor;
    public Color blueColor;
    public GameObject light1;
    public GameObject light2;
    public Light flasher1;
    public Light flasher2;

    private const float FLASH_INTERVAL = 0.75f;

    private Material lightMat1;
    private Material lightMat2;
    private Color flasherColor1;
    private Color flasherColor2;
    private float timeElapsed;

    void Start()
    {
        lightMat1 = red;
        lightMat2 = blue;
        SwitchColors();
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
            flasherColor1 = blueColor;
            flasherColor2 = redColor;
        }
        else
        {
            lightMat1 = red;
            lightMat2 = blue;
            flasherColor1 = redColor;
            flasherColor2 = blueColor;
        }
        light1.GetComponent<Renderer>().material = lightMat1;
        light2.GetComponent<Renderer>().material = lightMat2;
        flasher1.color = flasherColor1;
        flasher2.color = flasherColor2;
    }
}
