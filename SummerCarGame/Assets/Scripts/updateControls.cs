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
        if(c.GetActiveIndex() == 0)
        {
            c.GetComponent<Accelerometer>().enabled = false;
            c.GetComponent<MoveCar>().enabled = true;
        }
        else if (c.GetActiveIndex() == 0)
        {
            c.GetComponent<Accelerometer>().enabled = true;
            c.GetComponent<MoveCar>().enabled = false;
        }
    }
}
