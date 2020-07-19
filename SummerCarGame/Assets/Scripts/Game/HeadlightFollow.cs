using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightFollow : MonoBehaviour
{
    public float offset;
    public float latOffset;
    private GameObject car;

    // Start is called before the first frame update
    public void SimulateStart()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.name == "IlluminateCar")
            gameObject.GetComponent<Light>().intensity = gameObject.transform.position.y;
        //print("start simulated");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(car.transform.position.x + latOffset, transform.position.y, car.transform.position.z + offset);
    }
}
