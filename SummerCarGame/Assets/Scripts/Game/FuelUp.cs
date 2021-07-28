using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUp : MonoBehaviour
{
     public FuelBar fuelBar;

    /// <summary>
    /// Fuels up the car if it goes into fuel up region
    /// </summary>
    /// <param name="other">The collider (only does something if the player)</param>
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    /// <summary>
    /// Picks up the fuel
    /// </summary>
    /// <param name="player">The player</param>
    void PickUp(Collider player)
    {
        Car stats = player.GetComponent<Car>();
        FuelBar slide = player.GetComponent<FuelBar>();
        stats.currentFuel = stats.maxFuel;
        fuelBar.SetFuel(100);
        
        Destroy(gameObject);
    }
}
