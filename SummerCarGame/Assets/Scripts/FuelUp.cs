using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUp : MonoBehaviour
{
     public FuelBar fuelBar;
     
    void Start()
    {
        
    }

    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        Car stats = player.GetComponent<Car>();
        FuelBar slide = player.GetComponent<FuelBar>();
        stats.currentFuel = stats.maxFuel;
        fuelBar.SetFuel(100);
        
        Destroy(gameObject);
    }
}
