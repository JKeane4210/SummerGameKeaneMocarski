using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle
{
    private string name;
    private string dscr;
    private int maxHealth;
    private float maxFuel;
    private float velocity;
    private Vector3 dimensions;
    //private float latVelocity; //basically agility (IDK if we should do this?)
    private GameObject car;

    public Vehicle(string n, string d, int health, float fuel, float vel, GameObject g, Vector3 dimen)
    {
        name = n;
        dscr = d;
        maxHealth = health;
        maxFuel = fuel;
        velocity = vel;
        //latVelocity = latVel;
        car = g;
        dimensions = dimen;
        // >>> could set up components with this >>>
        //SetUpComponents(health, fuel, vel, g, dimen); //maybe do when on the car scene
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

    //may be unecessary if we set components manually
    //could set up more, these are just more variable and key than the others
    public void SetUpComponents(int health, float fuel, float vel, GameObject g, Vector3 dimen)
    {
        //CAR
        if(g.GetComponent<Car>() == null)
            g.AddComponent<Car>();
        Car carBehaviour = g.GetComponent<Car>();
        carBehaviour.maxHealth = health;
        carBehaviour.maxFuel = fuel;
        carBehaviour.currentHealth = health;
        carBehaviour.currentFuel = fuel;
        //CHARACTER_CONTROLLER
        if (g.GetComponent<CharacterController>() == null)
            g.AddComponent<CharacterController>();
        //RIGIDBODY
        if (g.GetComponent<Rigidbody>() == null)
            g.AddComponent<Rigidbody>();
        Rigidbody rig = g.GetComponent<Rigidbody>();
        rig.useGravity = false;
        //BOX_COLLIDER
        if (g.GetComponent<BoxCollider>() == null)
            g.AddComponent<BoxCollider>();
        BoxCollider box = g.GetComponent<BoxCollider>();
        box.size = dimen;
        box.isTrigger = true;
        //RENDER_ROAD
        if (g.GetComponent<RenderRoad>() == null)
            g.AddComponent<RenderRoad>();
        RenderRoad road = g.GetComponent<RenderRoad>();
        road.car = g.transform;
        //FOREST_DAMAGE
        if (g.GetComponent<ForestDamage>() == null)
            g.AddComponent<ForestDamage>();
        ForestDamage for_damage = g.GetComponent<ForestDamage>();
        for_damage.car = g;
        for_damage.normalSpeed = vel;
        //MOVE_CAR
        if (g.GetComponent<MoveCar>() == null)
            g.AddComponent<MoveCar>();
        MoveCar move = g.GetComponent<MoveCar>();
        move.forward_vel = vel;
        move.car = g.GetComponent<CharacterController>();
        move.car_rb = rig;
        move.carBlue = carBehaviour;
        move.velLimit = 8f;
            //might need to add latVel to this to be consistant (if using latVel)
        //ACCELEROMETER
        if (g.GetComponent<Accelerometer>() == null)
            g.AddComponent<Accelerometer>();
        Accelerometer acc = g.GetComponent<Accelerometer>();
        acc.lat_multiplier = 23f;
        acc.forward_vel = vel;
        acc.forward_vel = vel;
        //SWIPE_CONTROLS
        if (g.GetComponent<SwipeControls>() == null)
            g.AddComponent<SwipeControls>();
        SwipeControls swipe = g.GetComponent<SwipeControls>();
        swipe.velocity = vel;
        swipe.latVelMultiplier = 0.08f;
    }

    //good for loading screen
    public GameObject GetGameObjectNoComponents()
    {
        GameObject carCopy = Object.Instantiate(car);
        foreach (var comp in carCopy.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Rigidbody))
            {
                Object.Destroy(comp);
            }
        }
        return carCopy;
    }

    public string GetName()
    {
        return name;
    }
    public string GetDescription()
    {
        return dscr;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetMaxFuel()
    {
        return maxFuel;
    }
    public float GetVelocity()
    {
        return velocity;
    }
    public Vector3 GetDimensions()
    {
        return dimensions;
    }
    //public float GetLatVelocity()
    //{
    //    return latVelocity;
    //}
}
