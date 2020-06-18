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
    private Vector3 location_end;
    private bool isOpen;

    void Start()
    {
       
    }
    void Update()
    {
        if (carBlue.currentFuel > 0 && carBlue.currentHealth > 0)
        {
            car_rb.velocity = new Vector3(0f, 0f, forward_vel);
        }
        else
        {
            Time.timeScale = 0;
            //car_rb.velocity = Vector3.zero;
            //car_rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //if (isOpen)
            //{
            //    location_end = new Vector3(car_rb.position.x, car_rb.position.y, car_rb.position.z + 4f);
            //    isOpen = false;
            //}
            //car_rb.MovePosition(location_end);
        }
    }
}
// if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        // {
        //     Vector3 move = transform.forward * z + transform.right * x;
        //     car.Move(move * forward_vel * Time.deltaTime);
        //     car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
        //     if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        //     {
        //         Vector3 move2 = transform.right * x + transform.forward * z;
        //         car.Move(move2 * lateral_vel * Time.deltaTime);
        //         car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
        //     }
        //     if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        //     {
        //         Vector3 move2 = -1 * transform.right * x - transform.forward * z;
        //         car.Move(move2 * -lateral_vel * Time.deltaTime);
        //         car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
        //     }
        // }