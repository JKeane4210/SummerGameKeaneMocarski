using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCar : MonoBehaviour
{
    private GameObject sceneController;
    private Vehicle vehicle;
    void Start()
    {
        GetComponent<VehicleList>().SimulateStart();
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
        vehicle = GetComponent<VehicleList>().GetSelectedVehicle();
        GameObject car = vehicle.GetGameObjectNoComponents(new Vector3(vehicle.mainMenuPositionX, vehicle.mainMenuPositionY, vehicle.mainMenuPositionZ));
        car.transform.localScale = new Vector3(vehicle.mainMenuScaleX, vehicle.mainMenuScaleY, vehicle.mainMenuScaleZ);
        car.transform.rotation = vehicle.mainMenuRotation;
        
    }


}
