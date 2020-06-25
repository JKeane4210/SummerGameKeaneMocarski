using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    //public HealthBar healthBar;
    //public FuelBar fuelBar;
    private HealthBar healthBar;
    private FuelBar fuelBar;
    float speed = 2f;
    float delta = 0.25f;
    Vector3 pos;
    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        fuelBar = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelBar>();
        pos = transform.position;
        //print(healthBar.GetValue());
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 150f) * Time.deltaTime);
        
        float nY = Mathf.Sin(speed * Time.time) * delta + pos.y;
        transform.position = new Vector3(transform.position.x, nY, transform.position.z);
        
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
        HealthBar slide = player.GetComponent<HealthBar>();
        stats.currentHealth = stats.maxHealth;
        healthBar.SetHealth(100);
        //slide.slider.value = 100;
        //slide.fill.color = slide.gradient.Evaluate(1f);
        
        Destroy(gameObject);
    }
}
