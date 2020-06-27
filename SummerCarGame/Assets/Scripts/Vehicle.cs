using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle
{
    private float maxHealth;
    private float deltaFuel;
    private float velocity;
    private float latVelocity; //basically agility
    private GameObject car;

    public Vehicle(float health, float dFuel, float vel, float latVel, GameObject g)
    {
        maxHealth = health;
        deltaFuel = dFuel;
        velocity = vel;
        latVelocity = latVel;
        car = g;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetDeltaFue()
    {
        return deltaFuel;
    }

    public float GetVelocity()
    {
        return velocity;
    }

    public float GetLatVelocity()
    {
        return latVelocity;
    }

    public void MakeCarStatic()
    {
        DeactivateCarControl(0);
        DeactivateCarControl(1);
        DeactivateCarControl(2);
    }

    public void ActivateCarControl(int i)
    {
        if (i == 0)
            car.GetComponent<MoveCar>().enabled = true;
        if (i == 1)
            car.GetComponent<Accelerometer>().enabled = true;
        if (i == 2)
            car.GetComponent<SwipeControls>().enabled = true;
    }

    public void DeactivateCarControl(int i)
    {
        if (i == 0)
            car.GetComponent<MoveCar>().enabled = false;
        if (i == 1)
            car.GetComponent<Accelerometer>().enabled = false;
        if (i == 2)
            car.GetComponent<SwipeControls>().enabled = false;
    }
}
