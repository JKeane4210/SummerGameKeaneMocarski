using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMoving : MonoBehaviour
{
    private GameObject car;

    public void SimulateStart()
    {
        car = GameObject.FindGameObjectWithTag("Player");
    }

    public void PointerDown(float latVel)
    {
        car.GetComponent<MoveCar>().ButtonPressed(latVel);
    }

    public void PointerEnter()
    {
        car.GetComponent<MoveCar>().ResetLatVel();
    }
}
