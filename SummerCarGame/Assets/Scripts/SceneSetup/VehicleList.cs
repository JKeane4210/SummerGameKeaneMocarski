using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour
{
    static Vehicle selectedVehicle;
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
     *     hasCustomHeadlights
     *     headlightOffsetAddOn
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
            new Vector3(1, 3, 1),
            new Vector3(1.5f, 1.25f, 0f),
            new Vector3(0, -25, -65),
            new Vector3(3, 3, 3),
            new Vector3(30, 30, 30),
            mmScale: 7,
            mmPosY: 24,
            rotX: 6,
            forceFieldRadius: 3
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
            price: 50,
            illuminationHeight: 5,
            mmPosY: 18,
            rotX: 9,
            forceFieldRadius: 13
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
            price: 100,
            illuminationHeight: 8,
            mmPosY: 15,
            forceFieldRadius: 6
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
            price: 200,
            illuminationHeight: 10,
            mmPosY: 7,
            unlockedAddOn: 10
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
            price: 100,
            headlightOffsetAddOn: 1.25f
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
            hasCustomHeadlights: true,
            headlightOffsetAddOn: 1.25f,
            prizeDistance: 15
            )
        ,
        new Vehicle("Sporty",
            "Fast and sleek. Made to show off.",
            110,
            100f,
            24f,
            (GameObject)Resources.Load("Models/Cars/stripeSportsCar2"),
            new Vector3(2.5f, 5, 6.5f),
            new Vector3(1.5f, 1.6f, 0f),
            new Vector3(0, -19.5f, -65),
            new Vector3(1.1f, 1.2f, 1.2f),
            new Vector3(15,15,15),
            price: 125,
            headlightOffsetAddOn: 2
            )
        };
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

    public int VehicleCount() => vehicles.Length;
    public Vehicle[] GetVehicles() => vehicles;
    public Vehicle GetSelectedVehicle() => selectedVehicle;
    public Vehicle GetInfoVehicle() => infoVehicle;
}
