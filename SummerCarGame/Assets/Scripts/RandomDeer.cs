using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeer : MonoBehaviour
{
    public GameObject deer;

    // Start is called before the first frame update
    void Start()
    {
        deer.AddComponent<Rigidbody>();
        deer.GetComponent<Rigidbody>().useGravity = false;
        deer.AddComponent<DeerRunning>();
        deer.GetComponent<DeerRunning>();
    }

}
