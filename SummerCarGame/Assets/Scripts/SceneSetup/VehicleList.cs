using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour
{
    static Vehicle selectedVehicle;
    static Vehicle infoVehicle;

    private Vehicle[] vehicles;
    readonly private Dictionary<string, Vehicle> vehiclesDictionary = new Dictionary<string, Vehicle>();

    void Start()
    {
        vehicles = GameDataJSONReader.CreateVehicleList();
        vehiclesDictionary.Clear();
        foreach (Vehicle vehicle in vehicles)
            vehiclesDictionary.Add(vehicle.GetName(), vehicle);
        selectedVehicle = GameDataManager.GetSelectedVehicle() ?? vehicles[0];
        infoVehicle = infoVehicle ?? selectedVehicle;
    }

    public void SimulateStart()                          => Start();
    public void ChangeSelectedVehicleByName(string name) => GameDataManager.SetSelectedVehicle(vehiclesDictionary[name]);
    public void ChangeInfoVehicleByName(string name)     => infoVehicle = vehiclesDictionary[name];
    public Vehicle GetVehicleByName(string name)         => vehiclesDictionary[name];
    public int VehicleCount()                            => vehicles.Length;
    public Vehicle[] GetVehicles()                       => vehicles;
    public Vehicle GetSelectedVehicle()                  => selectedVehicle;
    public Vehicle GetInfoVehicle()                      => infoVehicle;
}
