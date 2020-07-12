using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;
   public float maxFuel = 100;
   public float currentFuel;
   public HealthBar healthBar;
   public FuelBar fuelBar;
   private Transform car_transform;
   private float distance_traveled;

    public void SimulateStart()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
        car_transform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (currentFuel > 0.03)
            currentFuel -= 0.03f;
        else
            currentFuel = 0;
        fuelBar.SetFuel(currentFuel);
        distance_traveled = 4 * car_transform.position.z; // would need to change if turning
        //print("Distance>>>" + distance_traveled.ToString());
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public float getDistanceMiles()
    {
        float distance_miles = distance_traveled / 5280f;
        int distance_int = (int)(distance_miles * 100); 
        return (float)(distance_int / 100f);
    }

}
