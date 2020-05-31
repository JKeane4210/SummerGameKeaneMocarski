using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableWithSpace : MonoBehaviour
{
    [SerializeField]
    public Camera c;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            c.enabled = false;
        }
        else
        {
            c.enabled = true;
        }
    }
}
