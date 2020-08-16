using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour
{
    static Vehicle selectedVehicle;
    static ArrayList purchasedCars = new ArrayList() { "Default Car" };
    static Vehicle infoVehicle;

    private Vehicle[] vehicles;

    /* CONSTRUCTOR_PARAMS
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
     *     Price
     *     Illumination Height (for night mode)
     *     UnlockedCarAddOn* optional (default to zero)
    */

    private void Start()
    {
        vehicles = new Vehicle[]{
        new Vehicle("Default Car",
            "Can't beat a classic",
            100,
            100f,
            23f,
            (GameObject)Resources.Load("Models/Cars/MovingCar2"),
            new Vector3(1,3,1),
            new Vector3(1.5f, 1.25f, 0f),
            new Vector3(0, -25, -65),
            new Vector3(3, 3, 3),
            new Vector3(30, 30, 30),
            0,
            10,
            7, //mmScale
            -4, 24, 150, //mmViewingAdjust
            6, 145, //mmRotation
            3
            ),
        new Vehicle("Sandvan",
            "Fun in the sun. Pretty buff, but could use some pace.",
            150,
            70f,
            19f,
            (GameObject)Resources.Load("Models/Cars/sandVan"),
            new Vector3(3.4f,5.75f,7.4f),
            new Vector3(1.5f, 1.75f, 0f),
            new Vector3(0, -20, -65),
            new Vector3(0.8f, 0.8f, 0.6f),
            new Vector3(10,10,10),
            50,
            5,
            12, //mmScale
            -4, 18, 150, //mmViewingAdjust
            9,145, //mmRotation
            13
            ),
        new Vehicle("Mr. Conroy",
            "Tough and reliable. Always can count on your chcocolate milk.",
            120,
            90f,
            21f,
            (GameObject)Resources.Load("Models/Cars/pickupTruck"),
            new Vector3(1.5f,5.75f,3.2f),
            new Vector3(1.5f, 1.75f, 0f),
            new Vector3(0, -16, -65),
            new Vector3(1.6f, 1.6f, 1.6f),
            new Vector3(25,25,25),
            100,
            8,
            12, //mmScale
            -4, 15, 150, //mmViewingAdjust
            5, 145, //mmRotation
            6
            ),
        new Vehicle("Night Cruiser",
            "Sleek and fast. Cruise the roads in style.",
            105,
            105f,
            24f,
            (GameObject)Resources.Load("Models/Cars/SportsCar2"),
            new Vector3(2.5f,5.75f,5.5f),
            new Vector3(1.5f, 2.3f, 0f),
            new Vector3(0, -7, -65),
            new Vector3(1f, 1f, 0.8f),
            new Vector3(15,15,15),
            200,
            10,
            10,
            12, //mmScale
            -4, 7, 150, //mmViewingAdjust
            5, 145, //mmRotation
            9
            ),
        new Vehicle("Taxi",
            "Black and yellow never looked better.",
            100,
            80f,
            22.5f,
            (GameObject)Resources.Load("Models/Cars/taxi2"),
            new Vector3(2.5f, 5, 5.75f),
            new Vector3(1.5f, 1.6f, 0f),
            new Vector3(0, -19.5f, -65),
            new Vector3(1.1f, 1.2f, 1.2f),
            new Vector3(15,15,15),
            100,
            10,
            12, //mmScale
            -4, 19, 150, //mmViewingAdjust
            5, 145, //mmRotation
            9
            ),
        new Vehicle("Police Car",
            "Keep the streets safe. Stay on the lookout for criminals.",
            110,
            100f,
            23f,
            (GameObject)Resources.Load("Models/Cars/policeCar2"),
            new Vector3(2.5f, 5, 5.75f),
            new Vector3(1.5f, 1.6f, 0f),
            new Vector3(0, -19.5f, -65),
            new Vector3(1.1f, 1.2f, 1.2f),
            new Vector3(15,15,15),
            100,
            10,
            12, //mmScale
            -4, 19, 150, //mmViewingAdjust
            5, 145, //mmRotation
            9
            )
        };
        // if need a small adjustment to headlights, use this function
        vehicles[4].SetHeadlightOffsetAddon(1.25f);
        vehicles[5].SetHeadlightOffsetAddon(1.25f);
        if (selectedVehicle == null)
            selectedVehicle = vehicles[0];
        if (infoVehicle == null)
            infoVehicle = selectedVehicle;
    }

    public void SimulateStart() => Start();

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
    }

    public void ChangeInfoVehicleByName(string name)
    {
        foreach (Vehicle v in vehicles)
        {
            if (v.GetName() == name)
            {
                infoVehicle = v;
                break;
            }
        }
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

    public void PurchaseCar(string name) => purchasedCars.Add(name);
    public int VehicleCount() => vehicles.Length;
    public ArrayList GetPurchasedCars() => purchasedCars;
    public Vehicle[] GetVehicles() => vehicles;
    public Vehicle GetSelectedVehicle() => selectedVehicle;
    public Vehicle GetInfoVehicle() => infoVehicle;
}
