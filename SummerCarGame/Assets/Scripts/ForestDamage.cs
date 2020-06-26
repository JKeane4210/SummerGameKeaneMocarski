using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDamage : MonoBehaviour
{
    public GameObject car;
    public float limit;
    public GameObject health;
    private HealthBar healthBar;
    public float normalSpeed;
    public float deltaV;

    private void Start()
    {
        healthBar = health.GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(car.transform.position.x) > limit)
        {
            float damage = Mathf.Abs(car.transform.position.x) - limit + 1;
            healthBar.DecreaseHealth(damage*damage);
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
}
