using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamColor : MonoBehaviour
{
    public Color day;
    public Color night;
    public Sprite dayImg;
    public Sprite nightImg;
    public ButtonManager sceneContr;
    public GameObject dayNightButtonImg;
    public GameObject dayNightButton;

    void Start()
    {
        day.a = 1;
        night.a = 1;
        SetNightDayColor();
    }

    public void NightModeColorChange()
    {
        sceneContr.FlipNightMode();
        SetNightDayColor();
    }

    private void SetNightDayColor()
    {
        if (sceneContr.GetIsNightMode())
        {
            gameObject.GetComponent<Camera>().backgroundColor = night;
            dayNightButtonImg.GetComponent<Image>().overrideSprite = nightImg;
            ColorBlock cb = dayNightButton.GetComponent<Button>().colors;
            cb.normalColor = day;
            cb.selectedColor = day;
            dayNightButton.GetComponent<Button>().colors = cb;
        }
            
        else if (!sceneContr.GetIsNightMode())
        {
            gameObject.GetComponent<Camera>().backgroundColor = day;
            dayNightButtonImg.GetComponent<Image>().overrideSprite = dayImg;
            ColorBlock cb = dayNightButton.GetComponent<Button>().colors;
            cb.normalColor = night;
            cb.selectedColor = night;
            dayNightButton.GetComponent<Button>().colors = cb;
        }
    }
}
