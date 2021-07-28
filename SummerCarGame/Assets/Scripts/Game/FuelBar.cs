using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelSlider;
    public Image fillGas;

    /// <summary>
    /// Sets the max value of the fuel
    /// </summary>
    /// <param name="gas">The max value</param>
    public void SetMaxFuel(float gas)
    {
        // slider.maxValue = health;
        // slider.value = health;

        // fill.color = gradient.Evaluate(1f);
        fuelSlider.maxValue = gas;
        fuelSlider.value = gas;

    }

    /// <summary>
    /// Updates the fuel
    /// </summary>
    /// <param name="gas">Current fuel level</param>
    public void SetFuel(float gas)
    {
        // slider.value = health;
        // fill.color = gradient.Evaluate(slider.normalizedValue);

        fuelSlider.value = gas;

    }

    public float GetFuel()
    {
        return fuelSlider.value;
    }
}
