using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    public GameObject text_field;
    public GameObject text_field2;
    //public GameObject text_field3;
    private Car moving_car;
    private CoinCounter coins;
    private int initialCoins;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public void SimulateStart()
    {
        moving_car = GameObject.FindGameObjectWithTag("Player").GetComponent<Car>();
        coins = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinCounter>();
        initialCoins = coins.GetCoins();
        //text_field.GetComponent<UnityEngine.UI.Text>().text = "?????";
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            text_field.GetComponent<UnityEngine.UI.Text>().text = "" + moving_car.getDistanceMiles().ToString() + " mi.";
            //text_field3.GetComponent<TextMeshProUGUI>().text = "" + (coins.GetCoins() - initialCoins).ToString() + "";
            text_field2.GetComponent<UnityEngine.UI.Text>().text = "Distance: " + moving_car.getDistanceMiles().ToString() + " mi.\nCoins Gained: " + (coins.GetCoins() - initialCoins).ToString();
        }
    }
}
