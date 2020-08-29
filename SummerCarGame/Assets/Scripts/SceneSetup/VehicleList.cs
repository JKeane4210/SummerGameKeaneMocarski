using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour
{
    static Vehicle selectedVehicle;
    static Vehicle infoVehicle;

    private Vehicle[] vehicles;

    private void Start()
    {
        vehicles = VehicleJSONReader.CreateVehicleList();
        if (selectedVehicle == null) selectedVehicle = vehicles[0];
        if (infoVehicle == null) infoVehicle = selectedVehicle;
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
