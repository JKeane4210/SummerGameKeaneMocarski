using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGarbage : MonoBehaviour
{
    private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < car.transform.position.z - 30)
        {
            Destroy(gameObject);
        }
    }
}
