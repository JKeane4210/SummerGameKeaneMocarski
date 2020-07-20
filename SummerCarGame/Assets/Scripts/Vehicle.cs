﻿ using System.Collections;
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
    private int price;
    private int coin;

    private Vector3 gameLocation;
    private Vector3 viewingLocation;
    private Vector3 gameScale;
    private Vector3 viewingScale;

    private float illuminationHeight; //the intensity that allows illuminateCar gameobject to look good in night mode

    public Vehicle(string n, string d, int health, float fuel, float vel, GameObject g, Vector3 dimen, int p)
    {
        name = n;
        dscr = d;
        maxHealth = health;
        maxFuel = fuel;
        velocity = vel;
        //latVelocity = latVel;
        car = g;
        dimensions = dimen;
        price = p;
        // >>> could set up components with this >>>
        //SetUpComponents(health, fuel, vel, g, dimen); //maybe do when on the car scene
    }

    public Vehicle(string n, string d, int health, float fuel, float vel, GameObject g, Vector3 dimen, Vector3 gameLoc, Vector3 viewingLoc, Vector3 gameScl, Vector3 viewingScl, int p, float illHeight)
    {
        name = n;
        dscr = d;
        maxHealth = health;
        maxFuel = fuel;
        velocity = vel;
        //latVelocity = latVel;
        car = g;
        dimensions = dimen;
        SetLocations(gameLoc, viewingLoc);
        SetScales(gameScl, viewingScl);
        price = p;
        illuminationHeight = illHeight;
        // >>> could set up components with this >>>
        //SetUpComponents(health, fuel, vel, g, dimen); //maybe do when on the car scene
    }

    public void SetLocations(Vector3 game, Vector3 viewing)
    {
        gameLocation = game;
        viewingLocation = viewing;
    }

    public void SetScales(Vector3 game, Vector3 viewing)
    {
        gameScale = game;
        viewingScale = viewing;
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
    public GameObject SetUpComponents(int health, float fuel, float vel, GameObject g, Vector3 dimen)
    {
        GameObject g_ = Object.Instantiate(g, gameLocation, Quaternion.identity);
        g_.transform.localScale = gameScale;

        //CAR
        if (g_.GetComponent<Car>() == null)
            g_.AddComponent<Car>();
        Car carBehaviour = g_.GetComponent<Car>();
        carBehaviour.maxHealth = health;
        carBehaviour.maxFuel = fuel;
        carBehaviour.currentHealth = health;
        carBehaviour.currentFuel = fuel;
        carBehaviour.healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        carBehaviour.fuelBar = GameObject.FindGameObjectWithTag("Fuel").GetComponent<FuelBar>();
        //carBehaviour.car_transform = g.transform;

        //CHARACTER_CONTROLLER
        if (g_.GetComponent<CharacterController>() == null)
            g_.AddComponent<CharacterController>();

        //RIGIDBODY
        if (g_.GetComponent<Rigidbody>() == null)
            g_.AddComponent<Rigidbody>();
        Rigidbody rig = g_.GetComponent<Rigidbody>();
        rig.useGravity = false;

        //BOX_COLLIDER
        if (g_.GetComponent<BoxCollider>() == null)
            g_.AddComponent<BoxCollider>();
        BoxCollider box = g_.GetComponent<BoxCollider>();
        box.size = dimen;
        box.isTrigger = true;

        //CHANGE CONTROLS
        if (g_.GetComponent<ChangeControls>() == null)
            g_.AddComponent<ChangeControls>();

        //UPDATE CONTROLS
        if (g_.GetComponent<UpdateControls>() == null)
            g_.AddComponent<UpdateControls>();
        UpdateControls updateControls = g_.GetComponent<UpdateControls>();
        //updateControls.movingCar = g;

        //RENDER_ROAD
        if (g_.GetComponent<RenderRoad>() == null)
            g_.AddComponent<RenderRoad>();
        RenderRoad road = g_.GetComponent<RenderRoad>();
        road.car = g_.transform;
        //road.road = GameObject.FindGameObjectWithTag("ActiveForestRoad");
        road.gasStationRoad = (GameObject)Resources.Load("Models/Roads/forestRoadGasStopPainted");
        road.block_width = 24.5f;
        road.gasStationInterval = 10;
        road.fuelObject = GameObject.FindGameObjectWithTag("Fuel");

        //COIN MAKERS >>> coins and health
        if(g_.GetComponents<CoinMaker>().Length > 0)
        {
            foreach (Component c in g_.GetComponents<CoinMaker>())
                Object.Destroy(c);
        }
        CoinMaker coins = g_.AddComponent<CoinMaker>();
        coins.coin = (GameObject)Resources.Load("Models/Powerups/coinMoving");
        coins.interval = 0.5f;
        coins.width = 9;
        CoinMaker healthPacks = g_.AddComponent<CoinMaker>();
        healthPacks.coin = (GameObject)Resources.Load("Models/Powerups/health");
        healthPacks.interval = 10f;
        healthPacks.width = 9;

        //COIN COUNTER
        if (g_.GetComponent<CoinCounter>() == null)
            g_.AddComponent<CoinCounter>();

        //CAR DEER COLLIDE
        if (g_.GetComponent<CarDeerCollide>() == null)
            g_.AddComponent<CarDeerCollide>();
        CarDeerCollide cdColl = g_.GetComponent<CarDeerCollide>();
        cdColl.health_bar = GameObject.FindGameObjectWithTag("Health");
        cdColl.explosionEffect = (GameObject)Resources.Load("EffectExamples/FireExplosionEffects/Prefabs/BigExplosionEffect");

        //FOREST_DAMAGE
        if (g_.GetComponent<ForestDamage>() == null)
            g_.AddComponent<ForestDamage>();
        ForestDamage for_damage = g_.GetComponent<ForestDamage>();
        //for_damage.car = g;
        for_damage.normalSpeed = vel;
        for_damage.leftLimit = -11.5f;
        for_damage.rightLimit = 11.5f;
        for_damage.health = GameObject.FindGameObjectWithTag("Health");
        for_damage.deltaV = 0.2f;

        //MOVE_CAR
        if (g_.GetComponent<MoveCar>() == null)
            g_.AddComponent<MoveCar>();
        MoveCar move = g_.GetComponent<MoveCar>();
        move.forward_vel = vel;
        move.car = g_.GetComponent<CharacterController>();
        move.car_rb = rig;
        move.carBlue = carBehaviour;
        move.velLimit = 8f;

        //ACCELEROMETER
        if (g_.GetComponent<Accelerometer>() == null)
            g_.AddComponent<Accelerometer>();
        Accelerometer acc = g_.GetComponent<Accelerometer>();
        acc.rigid = rig;
        acc.lat_multiplier = 23f;
        acc.forward_vel = vel;
        acc.forward_vel = vel;

        //SWIPE_CONTROLS
        if (g_.GetComponent<SwipeControls>() == null)
            g_.AddComponent<SwipeControls>();
        SwipeControls swipe = g_.GetComponent<SwipeControls>();
        swipe.car = rig;
        swipe.velocity = vel;
        swipe.latVelMultiplier = 0.08f;

        //////HEADLIGHTS
        //if (g_.GetComponent<Light>() == null)
        //    g_.AddComponent<Light>();
        //Light headlight = g_.GetComponent<Light>();
        //headlight.type = LightType.Spot;
        //headlight.range = 200;
        //headlight.spotAngle = 60;
        //headlight.color = Color.white;
        //headlight.intensity = 2;

        //Object.Instantiate(g, gameLocation, Quaternion.Euler(0, 180, 0));
        return g_;
    }

    //good for loading screen
    public GameObject GetGameObjectNoComponents(Vector3 location)
    {
        GameObject carCopy = Object.Instantiate(car, location, Quaternion.identity);
        foreach (var comp in carCopy.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Rigidbody))
            {
                Object.Destroy(comp);
            }
        }
        return carCopy;
    }

    public GameObject GetGameObjectNoComponents(Vector3 location, Vector3 scale)
    {
        GameObject carCopy = Object.Instantiate(car, location, Quaternion.identity);
        carCopy.transform.localScale = scale;
        foreach (var comp in carCopy.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Rigidbody))
            {
                Object.Destroy(comp);
            }
        }
        return carCopy;
    }

    public GameObject GetCarGameObject()
    {
        //Object.Instantiate(car, gameLocation, Quaternion.Euler(0, 180, 0));
        GameObject carCopy = SetUpComponents(maxHealth, maxFuel, velocity, car, dimensions);
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
    public Vector3 GetGameScale()
    {
        return gameScale;
    }
    public Vector3 GetGameLocation()
    {
        return gameLocation;
    }
    public Vector3 GetViewingLocation()
    {
        return viewingLocation;
    }
    public Vector3 GetViewingScale()
    {
        return viewingScale;
    }

    public int GetPrice()
    {
        return price;
    }

    public bool CanSpendCoins()
    {
        if(coin > price)
            return true;
        else
            return false;
    }

    public float GetIlluminationHeight()
    {
        return illuminationHeight;
    }


    //public float GetLatVelocity()
    //{
    //    return latVelocity;
    //}
}
