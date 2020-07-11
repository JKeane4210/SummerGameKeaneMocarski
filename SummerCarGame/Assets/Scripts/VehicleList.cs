using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour
{
    private static Vehicle selectedVehicle;
    /*CONSTRUCTOR_PARAMS
     *     Name
     *     Description
     *     MaxHealth
     *     MaxFuel
     *     Velocity
     *     Dimensions
     *     Car (Game Object)
     *     GameLocation
     *     ViewingLocation
     *     GameScale
     *     ViewingScale
    */
    private Vehicle[] vehicles = new Vehicle[]{
        new Vehicle("Default Car",
            "Can't beat a classic",
            100,
            100f,
            23f,
            (GameObject)Resources.Load("Assets/Models/Cars/MovingCar2"),
            new Vector3(1,1,1),
            new Vector3(1.5f, 1.25f, 0f),
            new Vector3(0, -25, -65),
            new Vector3(3, 3, 3),
            new Vector3(30, 30, 30)
            ),
        new Vehicle("Sandvan",
            "Fun in the sun. Pretty buff, but could use some pace.",
            150,
            70f,
            18f,
            (GameObject)Resources.Load("Assets/Models/Cars/sandVan"),
            new Vector3(1,1,1),
            new Vector3(1.5f, 1.25f, 0f),
            new Vector3(0, -20, -65),
            new Vector3(1, 1, 1),
            new Vector3(10,10,10)
            ),
    };

    public Vehicle GetSelectedVehicle()
    {
        return selectedVehicle;
    }

    public void ChangeSelectedVehicleByName(string name)
    {
        foreach(Vehicle v in vehicles)
        {
            if (v.GetName() == name)
            {
                selectedVehicle = v;
                break;
            }
        }
        print("**WARNING** No Car By That Name Found!");
    }

    public Vehicle GetVehicleByName(string name)
    {
        foreach (Vehicle v in vehicles)
        {
            if (v.GetName() == name)
                return v;
        }
        print("**WARNING** No Car By That Name Found!");
        return null;
    }
}
