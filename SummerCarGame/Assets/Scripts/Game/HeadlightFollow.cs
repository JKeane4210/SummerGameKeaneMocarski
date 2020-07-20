using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightFollow : MonoBehaviour
{
    public float offset;
    public float latOffset;
    private GameObject car;
    private GameObject sceneController;

    // Start is called before the first frame update
    public void SimulateStart()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        car = GameObject.FindGameObjectWithTag("Player");
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
