using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float lateral_vel;
    public float forward_vel;
    public CharacterController car;
    public Transform car_transform;

    // Update is called once per frame
    void Update()
    {
        car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
        //
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            Vector3 move = transform.forward * z + transform.right * x;
            car.Move(move * forward_vel * Time.deltaTime);
            car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                Vector3 move2 = transform.right * x + transform.forward * z;
                car.Move(move2 * lateral_vel * Time.deltaTime);
                car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                Vector3 move2 = -1 * transform.right * x - transform.forward * z;
                car.Move(move2 * -lateral_vel * Time.deltaTime);
                car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            }
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            Vector3 move = -1 * transform.forward * z - transform.right * x;
            car.Move(move * -forward_vel * Time.deltaTime);
            car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                Vector3 move2 = transform.right * x + transform.forward * z;
                car.Move(move2 * lateral_vel * Time.deltaTime);
                car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                Vector3 move2 = -1 * transform.right * x - transform.forward * z;
                car.Move(move2 * -lateral_vel * Time.deltaTime);
                car_transform.localPosition = new Vector3(car_transform.localPosition.x, -1, car_transform.localPosition.z);
            }
        }
        
    }
}
