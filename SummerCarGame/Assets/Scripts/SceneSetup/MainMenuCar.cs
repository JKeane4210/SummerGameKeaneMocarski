using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCar : MonoBehaviour
{
    private GameObject sceneController;
    private Vehicle vehicle;

    /// <summary>
    /// Sets up car in the main menu
    /// </summary>
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
