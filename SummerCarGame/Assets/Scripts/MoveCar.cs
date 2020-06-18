using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    //public float test_stop_vel;
    public float lateral_vel;
    public float forward_vel;
    public CharacterController car;
    public Rigidbody car_rb;
    public Car carBlue;
    //private Vector3 location_end;
    //private bool isOpen;

    void Start()
    {
       
    }
    void Update()
    {
        if (carBlue.currentHealth <= 0 || carBlue.currentFuel <= 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            car_rb.velocity = new Vector3(0f, 0f, forward_vel);
        }
    }
}