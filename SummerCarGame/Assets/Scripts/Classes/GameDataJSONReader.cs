using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataJSONReader
{
    /// <summary>
    /// The defaults for optional values
    /// </summary>
    public readonly static Dictionary<string, string> OPTIONAL_VALUE_DEFAULTS = new Dictionary<string, string>()
    {
        {"price"               , "0"},
        {"illuminationHeight"  , "10"},
        {"mmScale"             , "12"},
        {"mmPosX"              , "-4"},
        {"mmPosY"              , "19"},
        {"mmPosZ"              , "150"},
        {"rotX"                , "5"},
        {"rotY"                , "145"},
        {"forceFieldRadius"    , "9"},
        {"unlockedAddOn"       , "0"},
        {"headlightOffsetAddOn", "0"},
        {"hasCustomHeadlights" , "false"},
        {"prizeDistance"       , "-1"}
    };

    /// <summary>
    /// Reads the vehicle list from the main JSON
    /// </summary>
    /// <returns>List of all the vehicle objects</returns>
    public static Vehicle[] CreateVehicleList()
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/GameData/GameData.json");
        string json = reader.ReadToEnd();
        Root root = JsonUtility.FromJson<Root>(json);
        Vehicle[] vehicles = new Vehicle[root.vehicles.Length];
        for (int i = 0; i < root.vehicles.Length; i++)
        {
            VehicleJSON vehicle = root.vehicles[i];
            vehicles[i] = new Vehicle
                (
                    vehicle.name,
                    vehicle.description,
                    vehicle.maxHealth,
                    vehicle.maxFuel,
                    (float)vehicle.velocity,
                    vehicle.car,
                    new Vector3((float)vehicle.dimensions.x,
                                (float)vehicle.dimensions.y,
                                (float)vehicle.dimensions.z),
                    new Vector3((float)vehicle.gameLocation.x,
                                (float)vehicle.gameLocation.y,
                                (float)vehicle.gameLocation.z),
                    new Vector3((float)vehicle.viewingLocation.x,
                                (float)vehicle.viewingLocation.y,
                                (float)vehicle.viewingLocation.z),
                    new Vector3((float)vehicle.gameScale.x,
                                (float)vehicle.gameScale.y,
                                (float)vehicle.gameScale.z),
                    new Vector3(vehicle.viewingScale.x,
                                vehicle.viewingScale.y,
                                vehicle.viewingScale.z),
                    vehicle.price,
                    vehicle.illuminationHeight, //?? float.Parse(OPTIONAL_VALUE_DEFAULTS["illuminationHeight"])
                    vehicle.mmScale != 0 ? vehicle.mmScale : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmScale"]),
                    float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosX"]),
                    vehicle.mmPosY != 0 ? vehicle.mmPosY : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosY"]),
                    float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosZ"]),
                    vehicle.rotX != 0 ? vehicle.rotX : float.Parse(OPTIONAL_VALUE_DEFAULTS["rotX"]),
                    float.Parse(OPTIONAL_VALUE_DEFAULTS["rotY"]),
                    vehicle.forceFieldRadius != 0 ? vehicle.forceFieldRadius : float.Parse(OPTIONAL_VALUE_DEFAULTS["forceFieldRadius"]),
                    vehicle.unlockedAddOn, //?? float.Parse(OPTIONAL_VALUE_DEFAULTS["unlockedAddOn"])
                    (float)vehicle.headlightOffsetAddOn, //?? float.Parse(OPTIONAL_VALUE_DEFAULTS["headlightOffsetAddOn"])
                    vehicle.hasCustomHeadlights, //?? bool.Parse(OPTIONAL_VALUE_DEFAULTS["hasCustomHeadlights"])
                    vehicle.prizeDistance // ?? float.Parse(OPTIONAL_VALUE_DEFAULTS["prizeDistance"])
                );
        }
        return vehicles;
    }

    /// <summary>
    /// Reads the terrain list from the main JSON
    /// </summary>
    /// <returns>List of all the terrain objects</returns>
    public static WorldTerrain[] CreateWorldTerrainList()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/GameData/GameData.json");
        Root root = JsonUtility.FromJson<Root>(json);
        WorldTerrain[] worldTerrains = new WorldTerrain[root.roads.Length];
        for (int i = 0; i < root.roads.Length; i++)
        {
            RoadJSON road = root.roads[i];
            Animal[] animals = new Animal[road.animals.Length];
            for (int j = 0; j < road.animals.Length; j++)
            {
                AnimalJSON animal = road.animals[j];
                animals[j] = new Animal
                    (
                        animal.name,
                        animal.animal,
                        animal.damage,
                        (float)animal.velocity
                    );
            }
            worldTerrains[i] = new WorldTerrain
                (
                    road.name,
                    road.normalRoad,
                    road.gasRoad,
                    animals,
                    road.material
                );
        }
        return worldTerrains;
    }
}

[System.Serializable]
public class Dimensions
{
    public double x;
    public double y;
    public double z;
}

[System.Serializable]
public class GameLocation
{
    public double x;
    public double y;
    public int z;
};

[System.Serializable]
public class ViewingLocation
{
    public int x;
    public double y;
    public int z;
}

[System.Serializable]
public class GameScale
{
    public double x;
    public double y;
    public double z;
}

[System.Serializable]
public class ViewingScale
{
    public int x;
    public int y;
    public int z;
}

[System.Serializable]
public class VehicleJSON
{
    public string name;
    public string description;
    public int maxHealth;
    public int maxFuel;
    public double velocity;
    public string car;
    public Dimensions dimensions;
    public GameLocation gameLocation;
    public ViewingLocation viewingLocation;
    public GameScale gameScale;
    public ViewingScale viewingScale;
    public int mmScale;
    public int mmPosY;
    public int rotX;
    public int forceFieldRadius;
    public int price = int.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["price"]);
    public int illuminationHeight = int.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["illuminationHeight"]);
    public int unlockedAddOn = int.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["unlockedAddOn"]);
    public double headlightOffsetAddOn = double.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["headlightOffsetAddOn"]);
    public bool hasCustomHeadlights = bool.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["hasCustomHeadlights"]);
    public int prizeDistance = int.Parse(GameDataJSONReader.OPTIONAL_VALUE_DEFAULTS["prizeDistance"]);
}

[System.Serializable]
public class AnimalJSON
{
    public string name;
    public string animal;
    public int damage;
    public double velocity; 
}

[System.Serializable]
public class RoadJSON
{
    public string name;
    public string normalRoad;
    public string gasRoad;
    public AnimalJSON[] animals;
    public string material;
}

[System.Serializable]
public class Root
{
    public VehicleJSON[] vehicles;
    public RoadJSON[] roads;
}




