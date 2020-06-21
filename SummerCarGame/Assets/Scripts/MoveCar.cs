using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class MoveCar : MonoBehaviour
{
    //public float test_stop_vel;
    private float lateral_vel;
    public float forward_vel;
    public CharacterController car;
    public Rigidbody car_rb;
    public Car carBlue;
    private bool isPressed;
    private float deltaLatVel;
    //private Vector3 location_end;
    //private bool isOpen;

    //void Start()
    //{
       
    //}
    void FixedUpdate()
    {
        if (carBlue.currentHealth <= 0 || carBlue.currentFuel <= 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            if (isPressed)
            {
                lateral_vel += deltaLatVel;
                car_rb.velocity = new Vector3(lateral_vel, 0f, forward_vel);
            }
            else
            {
                car_rb.velocity = new Vector3(0, 0f, forward_vel);
                lateral_vel /= 1.1f;
            }
        }
    }

    public void AddLateralVelocity(float lat_vel)
    {
        car_rb.velocity = new Vector3(lat_vel, 0f, forward_vel);
        lateral_vel += lat_vel;
    }

    public void buttonPressed(float lat_vel)
    {
        isPressed = true;
        deltaLatVel = lat_vel;
    }

    public void buttonReleased()
    {
        isPressed = false;
        //deltaLatVel = lat_vel;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    isPressed = true;
    //    print("is pressed");
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    isPressed = false;
    //}
}