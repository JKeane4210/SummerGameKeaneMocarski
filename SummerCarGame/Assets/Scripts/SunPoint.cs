using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunPoint : MonoBehaviour
{
    static float sunPoint = 60;
    public GameObject slider;
    public Gradient gradient;
    public GameObject sun;
    public GameObject sunPointTxt;

    void Start()
    {
        if (sun != null)
            sun.transform.rotation = Quaternion.Euler(new Vector3(sunPoint, 0, 0));
        if (slider != null)
            slider.GetComponent<Slider>().value = sunPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null)
        {
            SunSlider sunSlider = slider.GetComponent<SunSlider>();
            float val = slider.GetComponent<Slider>().normalizedValue;
            sunSlider.fill.GetComponent<Image>().color = gradient.Evaluate(val);
            sunSlider.background.GetComponent<Image>().color = gradient.Evaluate(val);
            sunPoint = slider.GetComponent<Slider>().value;
            if (val <= 0.1f)
                sunPointTxt.GetComponent<Text>().text = "Sun Point: Sunrise";
            else if (val <= 0.4f)
                sunPointTxt.GetComponent<Text>().text = "Sun Point: Morning";
            else if (val <= 0.6f)
                sunPointTxt.GetComponent<Text>().text = "Sun Point: Noon";
            else if (val <= 0.9f)
                sunPointTxt.GetComponent<Text>().text = "Sun Point: Afternoon";
            else
                sunPointTxt.GetComponent<Text>().text = "Sun Point: Sunset";
        }
    }

    //public float GetSunPoint()
    //{
    //    return sunPoint;
    //}
}
