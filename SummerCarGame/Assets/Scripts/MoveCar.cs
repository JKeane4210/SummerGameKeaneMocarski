using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float velocity;
    public float angular_velocity;
    public CharacterController car;
    public Transform car_transform;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move = transform.forward * z + transform.right* x;
            car.Move(move * velocity * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                car_transform.Rotate(Vector3.up * -angular_velocity);
            if (Input.GetKey(KeyCode.D))
                car_transform.Rotate(Vector3.up * angular_velocity);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Vector3 move = -1 * transform.forward * z - transform.right * x;
            car.Move(move * -velocity * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                car_transform.Rotate(Vector3.up * -angular_velocity);
            if (Input.GetKey(KeyCode.D))
                car_transform.Rotate(Vector3.up * angular_velocity);
        }
        
    }
}
