using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateControls : MonoBehaviour
{
    private GameObject movingCar;

    public void SimulateStart()
    {
        movingCar = GameObject.FindGameObjectWithTag("Player");
        movingCar.GetComponent<Accelerometer>().enabled = false;
        movingCar.GetComponent<MoveCar>().enabled = false;
        movingCar.GetComponent<SwipeControls>().enabled = false;
        int selectedControl = GameDataManager.GetSelectedControl();
        if (selectedControl == 0)
            movingCar.GetComponent<MoveCar>().enabled = true;
        else if (selectedControl == 1)
            movingCar.GetComponent<Accelerometer>().enabled = true;
        else
            movingCar.GetComponent<SwipeControls>().enabled = true;
    }
}
