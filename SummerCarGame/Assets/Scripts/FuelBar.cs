using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;
    public Image fillGas;
     public void SetMaxFuel(float gas)
    {
        // slider.maxValue = health;
        // slider.value = health;

        // fill.color = gradient.Evaluate(1f);
        fuelSlider.maxValue = gas;
        fuelSlider.value = gas;

    }
    
    public void SetFuel(float gas)
    {
        // slider.value = health;
        // fill.color = gradient.Evaluate(slider.normalizedValue);

        fuelSlider.value = gas;

    }
}
