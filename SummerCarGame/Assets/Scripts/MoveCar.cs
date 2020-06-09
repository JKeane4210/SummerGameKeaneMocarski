using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float velocity;
    public float angular_velocity;
    public CharacterController car;
    public Transform car_transform;
    public Transform front_wheels;


    private void Start()
    {
        front_wheels.Rotate(Vector3.up * (-0.1f)); // for whatever reason, the little offset allowed it to work
    }

    // Update is called once per frame
    void Update()
    {
        //
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move = transform.forward * z + transform.right* x;
            car.Move(move * velocity * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                wheelShift(true);
            if (Input.GetKey(KeyCode.D))
                wheelShift(false);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Vector3 move = -1 * transform.forward * z - transform.right * x;
            car.Move(move * -velocity * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                wheelShift(true);
            if (Input.GetKey(KeyCode.D))
                wheelShift(false);
        }
        if (Input.GetKey(KeyCode.A))
            wheelShift(true);
        if (Input.GetKey(KeyCode.D))
            wheelShift(false);
        if ((front_wheels.rotation.eulerAngles.y < 360 && front_wheels.rotation.eulerAngles.y > 329) && !Input.GetKey(KeyCode.A))
            front_wheels.Rotate(Vector3.up * (angular_velocity));
        if ((front_wheels.rotation.eulerAngles.y > 0 && front_wheels.rotation.eulerAngles.y < 31) && !Input.GetKey(KeyCode.D))
            front_wheels.Rotate(Vector3.up * (-angular_velocity));
    }

    void wheelShift(bool isRight)
    {
        if (isRight)
        {
            float maxAngle = 330;
            if (front_wheels.rotation.eulerAngles.y > maxAngle)
                front_wheels.Rotate(Vector3.up * -angular_velocity);
        }
        if (!isRight)
        {
            float maxAngle = 30;
            if (front_wheels.rotation.eulerAngles.y < maxAngle)
                front_wheels.Rotate(Vector3.up * angular_velocity);
        }
    }
}
