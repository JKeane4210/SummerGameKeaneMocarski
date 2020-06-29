using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public char direction;
    // Update is called once per frame
    void Update()
    {
        if(direction == 'x')
            transform.Rotate(new Vector3(30f, 0f, 0f) * Time.deltaTime);
        if(direction == 'y')
            transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        if(direction == 'z')
            transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
    }
}
