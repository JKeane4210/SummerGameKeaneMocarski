using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void DecreaseHealth(float health)
    {
        if (slider.value > health)
            slider.value -= health;
        else
            slider.value = 0;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float GetValue()
    {
        return slider.value;
    }

    public void IncreaseHealth(float i)
    {
        if (slider.value < slider.maxValue - i)
            slider.value += i;
        else
            slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
