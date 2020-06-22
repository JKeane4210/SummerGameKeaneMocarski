using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{

    public Rigidbody rigid;
    public float lat_multiplier;
    public float forward_vel;

    void Update()
    {
        rigid.velocity = new Vector3(Input.acceleration.x * lat_multiplier, 0f, forward_vel);
    }
}
