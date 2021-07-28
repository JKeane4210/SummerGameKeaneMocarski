using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGarbage : MonoBehaviour
{
    private GameObject car;
    private const float DISTANCE_BEHIND_TO_DELETE = 60;

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

    /// <summary>
    /// Deletes objects that are behind the car (won't be seen again)
    /// </summary>
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
            if (transform.position.z < car.transform.position.z - DISTANCE_BEHIND_TO_DELETE)
            {
                Destroy(gameObject);
            }
        }
    }
}
