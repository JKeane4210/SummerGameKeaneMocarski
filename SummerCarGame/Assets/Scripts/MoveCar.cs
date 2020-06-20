using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    //public float test_stop_vel;
    public float lateral_vel;
    public float forward_vel;
    public CharacterController car;
    public Rigidbody rb;
    public float speed;
    public Car carBlue;

       void Start()
    {
    
    }
    void FixedUpdate()
    {
        if (carBlue.currentHealth <= 0 || carBlue.currentFuel <= 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, forward_vel);
        }
      
    }

}