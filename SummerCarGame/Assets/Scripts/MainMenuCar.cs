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
        
        //Default Car
        // car.transform.localScale = new Vector3(vehicle.GetViewingScale().x/7, vehicle.GetViewingScale().y/7, vehicle.GetViewingScale().z /7);
        // car.transform.position = new Vector3(vehicle.GetViewingLocation().x - 4, vehicle.GetViewingLocation().y + 24, vehicle.GetViewingLocation().z + 150);
        // car.transform.rotation = Quaternion.Euler(6, 145, 0);

        //SandVan
        // car.transform.localScale = new Vector3(vehicle.GetViewingScale().x/12, vehicle.GetViewingScale().y/12, vehicle.GetViewingScale().z /12);
        // car.transform.position = new Vector3(vehicle.GetViewingLocation().x - 4, vehicle.GetViewingLocation().y + 18, vehicle.GetViewingLocation().z + 150);
        // car.transform.rotation = Quaternion.Euler(5, 145, 0);

        //Mr Conroy
        // car.transform.localScale = new Vector3(vehicle.GetViewingScale().x/12, vehicle.GetViewingScale().y/12, vehicle.GetViewingScale().z /12);
        // car.transform.position = new Vector3(vehicle.GetViewingLocation().x - 4, vehicle.GetViewingLocation().y + 15, vehicle.GetViewingLocation().z + 150);
        // car.transform.rotation = Quaternion.Euler(5, 145, 0);

        //Night Cruiser
        // car.transform.localScale = new Vector3(vehicle.GetViewingScale().x/12, vehicle.GetViewingScale().y/12, vehicle.GetViewingScale().z /12);
        // car.transform.position = new Vector3(vehicle.GetViewingLocation().x - 4, vehicle.GetViewingLocation().y + 7, vehicle.GetViewingLocation().z + 150);
        // car.transform.rotation = Quaternion.Euler(5, 145, 0);

    }


}
