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
   public Transform car_transform;
   private float distance_traveled;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    void Update()
    {
        if (currentFuel > 0.05)
            currentFuel -= 0.05f;
        else
            currentFuel = 0;
        fuelBar.SetFuel(currentFuel);
        distance_traveled = 4 * car_transform.localPosition.z; // would need to change if turning
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
