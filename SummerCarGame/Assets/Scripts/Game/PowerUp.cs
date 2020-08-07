using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    //public HealthBar healthBar;
    //public FuelBar fuelBar;
    private HealthBar healthBar;
    public string powerupType;
    private FuelBar fuelBar;
    float speed = 2f;
    float delta = 0.25f;
    Vector3 pos;
    private GameObject car;

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
            car = other.gameObject;
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        if(powerupType == "Health")
        {
            Car stats = player.GetComponent<Car>();
            HealthBar slide = player.GetComponent<HealthBar>();
            stats.currentHealth = stats.maxHealth;
            healthBar.IncreaseHealth(20);
            //healthBar.SetHealth(100);
            //slide.slider.value = 100;
            //slide.fill.color = slide.gradient.Evaluate(1f);
        }
        if(powerupType == "TwoTimes")
        {
            car.GetComponent<CoinCounter>().isTwoTimers.Add(true);
            car.GetComponent<CoinCounter>().addNew = true;
        }

        Destroy(gameObject);
    }
}
