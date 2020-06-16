using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public HealthBar healthBar;
    public FuelBar fuelBar;
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
        HealthBar slide = player.GetComponent<HealthBar>();
        stats.currentHealth = stats.maxHealth;
        healthBar.SetHealth(100);
        slide.slider.value = 100;
        slide.fill.color = slide.gradient.Evaluate(1f);
        
        Destroy(gameObject);
    }
}
