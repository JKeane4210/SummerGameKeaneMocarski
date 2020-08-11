using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private HealthBar healthBar;
    public string powerupType;
    const float BOBBING_SPEED = 2f;
    const float BOBBING_HEIGHT = 0.25f;
    Vector3 initialTransformPosition;
    private GameObject car;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        initialTransformPosition = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 150f) * Time.deltaTime);  
        float newY = Mathf.Sin(BOBBING_SPEED * Time.time) * BOBBING_HEIGHT + initialTransformPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.CompareTag("Player"))
        {
            car = otherCollider.gameObject;
            PickUp(otherCollider);
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
            foreach(GameObject animal in GameObject.FindGameObjectsWithTag("Animal"))
                animal.GetComponentInChildren<Renderer>().material = (Material)Resources.Load("Models/Powerups/shinierGold");
        }
        Destroy(gameObject);
    }
}
