using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDamage : MonoBehaviour
{
    private GameObject car;
    public float leftLimit;
    public float rightLimit;
    public GameObject health;
    private HealthBar healthBar;
    public float normalSpeed;
    public float deltaV;

    public void SimulateStart()
    {
        //normalSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveCar>().forward_vel;
        healthBar = health.GetComponent<HealthBar>();
        car = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (car.transform.position.x < leftLimit)
        {
            float damage = Mathf.Abs(car.transform.position.x - leftLimit) + 1;
            healthBar.DecreaseHealth(damage * damage);
            if (car.GetComponent<SwipeControls>().velocity > 10)
            {
                car.GetComponent<SwipeControls>().velocity -= deltaV;
                car.GetComponent<MoveCar>().forward_vel -= deltaV;
                car.GetComponent<Accelerometer>().forward_vel -= deltaV;
            }
        }
        else if (car.transform.position.x > rightLimit)
        {
            float damage = Mathf.Abs(car.transform.position.x - rightLimit) + 1;
            healthBar.DecreaseHealth(damage * damage);
            if (car.GetComponent<SwipeControls>().velocity > 10)
            {
                car.GetComponent<SwipeControls>().velocity -= deltaV;
                car.GetComponent<MoveCar>().forward_vel -= deltaV;
                car.GetComponent<Accelerometer>().forward_vel -= deltaV;
            }
        }
        else
        {
             car.GetComponent<SwipeControls>().velocity = normalSpeed;
             car.GetComponent<MoveCar>().forward_vel = normalSpeed;
             car.GetComponent<Accelerometer>().forward_vel = normalSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.ToString().Contains("forestRoad"))
        {
            if((int)(other.transform.eulerAngles.y / 180) % 2 == 1)
            {
                print("exception triggered!");
                leftLimit = -other.GetComponent<RoadSides>().rightSide;
                rightLimit = -other.GetComponent<RoadSides>().leftSide;
            }
            else
            {
                leftLimit = other.GetComponent<RoadSides>().leftSide;
                rightLimit = other.GetComponent<RoadSides>().rightSide;
            }
            
        }
    }
}
