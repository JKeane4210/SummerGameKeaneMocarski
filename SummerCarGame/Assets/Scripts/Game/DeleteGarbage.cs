using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGarbage : MonoBehaviour
{
    private GameObject car;

    // Start is called before the first frame update
    //void Start()
    //{
    //    try
    //    {
    //        car = GameObject.FindGameObjectWithTag("Player");
    //        print("Car>>>" + car.ToString());
    //    }
    //    catch
    //    {
    //        print(":(");
    //        //Start();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (car == null)
        {
            try
            {
                car = GameObject.FindGameObjectWithTag("Player");
                //print("Car>>>" + car.ToString());
            }
            catch
            {
                print("Error Delete Garbage");
            }
        }
        else
        {
            if (transform.position.z < car.transform.position.z - 30)
            {
                Destroy(gameObject);
            }
        }
    }
}
