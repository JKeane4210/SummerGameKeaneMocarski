using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateControls : MonoBehaviour
{
    private GameObject movingCar;

    //// Start is called before the first frame update
    public void SimulateStart()
    {
        movingCar = GameObject.FindGameObjectWithTag("Player");
        ChangeControls c = movingCar.GetComponent<ChangeControls>();
        print("Active Control Index=" + c.GetActiveIndex().ToString());
        if (c.GetActiveIndex() == 0)
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
        else if (c.GetActiveIndex() == 2)
        {
            c.GetComponent<Accelerometer>().enabled = false;
            c.GetComponent<MoveCar>().enabled = false;
            c.GetComponent<SwipeControls>().enabled = true;
        }
    }

    //void Update()
    //{
    //    //if (movingCar != null)
    //    //{
    //    //    try
    //    //    {
    //    ChangeControls c = movingCar.GetComponent<ChangeControls>();
    //    print("Active Control Index=" + c.GetActiveIndex().ToString());
    //    if (c.GetActiveIndex() == 0)
    //    {
    //        c.GetComponent<Accelerometer>().enabled = false;
    //        c.GetComponent<MoveCar>().enabled = true;
    //        c.GetComponent<SwipeControls>().enabled = false;

    //    }
    //    else if (c.GetActiveIndex() == 1)
    //    {
    //        c.GetComponent<Accelerometer>().enabled = true;
    //        c.GetComponent<MoveCar>().enabled = false;
    //        c.GetComponent<SwipeControls>().enabled = false;
    //    }
    //    else if (c.GetActiveIndex() == 2)
    //    {
    //        c.GetComponent<Accelerometer>().enabled = false;
    //        c.GetComponent<MoveCar>().enabled = false;
    //        c.GetComponent<SwipeControls>().enabled = true;
    //            }
    //    //    }
    //    //    catch
    //    //    {
    //    //        print("Error Update Controls");
    //    //    }
    //    //}
    //}
}
