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
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
