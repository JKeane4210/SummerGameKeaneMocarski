using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightFollow : MonoBehaviour
{
    private float offset;
    public float latOffset;
    private GameObject car;
    private GameObject sceneController;

    /// <summary>
    /// Called within another Start method
    ///     - put car headlights in front of car
    /// </summary>
    public void SimulateStart()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        car = GameObject.FindGameObjectWithTag("Player");
        offset = 1.5f + car.GetComponent<Car>().headlightOffsetAddOn;
        if (gameObject.name == "IlluminateCar")
            gameObject.GetComponent<Light>().intensity = sceneController.GetComponent<SceneDrawing>().GetVehicle().GetIlluminationHeight();
        //print("start simulated");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(car.transform.position.x + latOffset, transform.position.y, car.transform.position.z + offset);
    }
}
