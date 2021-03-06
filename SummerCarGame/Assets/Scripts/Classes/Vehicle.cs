﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : GamePiece
{
    public string description;
    public int maxHealth;
    public float maxFuel;
    public float velocity;
    public Vector3 dimensions;
    //public float latVelocity; //basically agility (IDK if we should do this?)
    public int price;
    public float mainMenuScaleX;
    public float mainMenuScaleY;
    public float mainMenuScaleZ;
    public float mainMenuPositionX;
    public float mainMenuPositionY;
    public float mainMenuPositionZ;
    public Quaternion mainMenuRotation;

    public Vector3 gameLocation;
    public Vector3 viewingLocation;
    public Vector3 gameScale;
    public Vector3 viewingScale;

    public float unlockedAddOn;

    public float illuminationHeight; //the intensity that allows illuminateCar gameobject to look good in night mode
    public float headlightOffsetAddOn;
    public float forceFieldRadius; //what the scale will be of the sphere
    public bool hasCustomHeadlights;
    public float prizeDistance;

    // normal
    public Vehicle(string name, string description,
                   int maxHealth, float maxFuel,
                   float velocity, string car,
                   Vector3 dimensions,
                   Vector3 gameLoc, Vector3 viewingLoc,
                   Vector3 gameScl, Vector3 viewingScl,
                   int price                  = 0,
                   float illuminationHeight   = 10,
                   float mmScale              = 12,
                   float mmPosX               = -4,
                   float mmPosY               = 19,
                   float mmPosZ               = 150,
                   float rotX                 = 5,
                   float rotY                 = 145,
                   float forceFieldRadius     = 9,
                   float unlockedAddOn        = 0,
                   float headlightOffsetAddOn = 0,
                   bool hasCustomHeadlights   = false,
                   float prizeDistance        = -1) : base(name, car)
    {
        this.description = description;
        this.maxHealth = maxHealth;
        this.maxFuel = maxFuel;
        this.velocity = velocity;
        this.dimensions = dimensions;
        this.price = price;
        this.illuminationHeight = illuminationHeight;

        SetLocations(gameLoc, viewingLoc);
        SetScales(gameScl, viewingScl);
        
        mainMenuScaleX = GetViewingScale().x / mmScale;
        mainMenuScaleY = GetViewingScale().y / mmScale;
        mainMenuScaleZ = GetViewingScale().z / mmScale;
        mainMenuPositionX = GetViewingLocation().x + mmPosX;
        mainMenuPositionY = GetViewingLocation().y + mmPosY;
        mainMenuPositionZ = GetViewingLocation().z + mmPosZ;
        mainMenuRotation = Quaternion.Euler(rotX, rotY, 0);

        this.forceFieldRadius = forceFieldRadius;
        this.headlightOffsetAddOn = headlightOffsetAddOn;
        this.hasCustomHeadlights = hasCustomHeadlights;
        this.unlockedAddOn = unlockedAddOn;
        this.prizeDistance = prizeDistance;
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
        GameObject carObj = (GameObject)Resources.Load(GetAssetPath());
        if (i == 0)
            carObj.GetComponent<MoveCar>().enabled = true;
        if (i == 1)
            carObj.GetComponent<Accelerometer>().enabled = true;
        if (i == 2)
            carObj.GetComponent<SwipeControls>().enabled = true;
    }

    public void DeactivateCarControl(int i)
    {
        GameObject carObj = (GameObject)Resources.Load(GetAssetPath());
        if (i == 0)
            carObj.GetComponent<MoveCar>().enabled = false;
        if (i == 1)
            carObj.GetComponent<Accelerometer>().enabled = false;
        if (i == 2)
            carObj.GetComponent<SwipeControls>().enabled = false;
    }

    //may be unecessary if we set components manually
    //could set up more, these are just more variable and key than the others
    public GameObject SetUpComponents(int health, float fuel, float vel, GameObject g, Vector3 dimen)
    {
        GameObject g_ = PlaceGameObject(gameLocation, Quaternion.identity);
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
        carBehaviour.forceFieldRad = forceFieldRadius;
        carBehaviour.headlightOffsetAddOn = headlightOffsetAddOn;
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
        coins.spawnInterval = 0.5f;
        coins.roadWidth = 9;
        CoinMaker powerups = g_.AddComponent<CoinMaker>();
        //healthPacks.coin = (GameObject)Resources.Load("Models/Powerups/twoTimes");
        powerups.coin = null;
        powerups.spawnInterval = 8f;
        powerups.roadWidth = 9;

        //COIN COUNTER
        if (g_.GetComponent<CoinCounter>() == null)
            g_.AddComponent<CoinCounter>();

        //CAR DEER COLLIDE
        if (g_.GetComponent<CarDeerCollide>() == null)
            g_.AddComponent<CarDeerCollide>();
        CarDeerCollide cdColl = g_.GetComponent<CarDeerCollide>();
        cdColl.healthBar = GameObject.FindGameObjectWithTag("Health");
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
        GameObject carCopy = PlaceGameObject(location, Quaternion.identity);
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
        GameObject carCopy = PlaceGameObject(location, Quaternion.identity);
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

    public GameObject GetCarGameObject() => SetUpComponents(maxHealth, maxFuel, velocity, (GameObject)Resources.Load(GetAssetPath()), dimensions);
    public string GetDescription() => description;
    public int GetMaxHealth() => maxHealth;
    public float GetMaxFuel() => maxFuel;
    public float GetVelocity() => velocity;
    public Vector3 GetDimensions() => dimensions;
    public Vector3 GetGameScale() => gameScale;
    public Vector3 GetGameLocation() => gameLocation;
    public Vector3 GetViewingLocation() => viewingLocation;
    public Vector3 GetViewingScale() => viewingScale;
    public int GetPrice() => price;
    public float GetIlluminationHeight() => illuminationHeight;
    public float GetUnlockedAddOn() => unlockedAddOn;
    public float GetForceFieldRad() => forceFieldRadius;
    public float GetHeadlightOffsetAddOn() => headlightOffsetAddOn;
    public bool HasCustomHeadlights() => hasCustomHeadlights;
    public float GetPrizeDistance() => prizeDistance;
}
