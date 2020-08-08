using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private HealthBar healthBar;
    public string powerupType;
    private FuelBar fuelBar;
    float speed = 2f;
    float delta = 0.25f;
    Vector3 pos;
    private GameObject car;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
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
            stats.currentHealth = stats.maxHealth;
            healthBar.IncreaseHealth(20);
        }
        else if(powerupType == "TwoTimes")
        {
            car.GetComponent<CoinCounter>().isTwoTimers.Add(true);
            car.GetComponent<CoinCounter>().addNew = true;
            canvas.GetComponent<powerUpBoard>().addNew = "2X";
            canvas.GetComponent<powerUpBoard>().isTrue.Add("2X");
        }
        else if(powerupType == "GoldAnimal")
        {
            car.GetComponent<CarDeerCollide>().goldAnimal = true;
            canvas.GetComponent<powerUpBoard>().addNew = "Animal";
            canvas.GetComponent<powerUpBoard>().isTrue.Add("Animal");
        }
        Destroy(gameObject);
    }
}
