using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateControls : MonoBehaviour
{
    public GameObject movingCar;

    // Start is called before the first frame update
    void Start()
    {
        ChangeControls c = movingCar.GetComponent<ChangeControls>();
        print(c.GetActiveIndex());
        if(c.GetActiveIndex() == 0)
        {
            c.GetComponent<Accelerometer>().enabled = false;
            c.GetComponent<MoveCar>().enabled = true;
            c.GetComponent<SwipeControls>().enabled = false;

        }
        else if (c.GetActiveIndex() == 1)
        {
            c.GetComponent<Accelerometer>().enabled = true;
            c.GetComponent<MoveCar>().enabled = false;
            c.GetComponent<SwipeControls>().enabled = false;
        }
        else if(c.GetActiveIndex() == 2)
        {
            c.GetComponent<Accelerometer>().enabled = false;
            c.GetComponent<MoveCar>().enabled = false;
            c.GetComponent<SwipeControls>().enabled = true;
        }
    }
}
