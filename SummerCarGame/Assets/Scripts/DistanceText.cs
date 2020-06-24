using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceText : MonoBehaviour
{
    public GameObject text_field;
    public GameObject text_field2;
    public Car moving_car;
    public CoinCounter coins;
    private int initialCoins;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private void Start()
    {
        initialCoins = coins.GetCoins();
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            text_field.GetComponent<UnityEngine.UI.Text>().text = "" + moving_car.getDistanceMiles().ToString() + " mi.";
            text_field2.GetComponent<UnityEngine.UI.Text>().text = "Distance: " + moving_car.getDistanceMiles().ToString() + " mi.\nCoins Gained: " + (coins.GetCoins() - initialCoins).ToString();
        }
    }
}
