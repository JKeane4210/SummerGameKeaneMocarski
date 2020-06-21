using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{

    private Rigidbody rigid;
    public float speed;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0f, 0f);
        rigid.velocity = movement * speed;
    }

    private void Update()
    {
       
    }
 
}
