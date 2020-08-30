using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class GameDataJSONReader
{
    readonly static Dictionary<string, string> OPTIONAL_VALUE_DEFAULTS = new Dictionary<string, string>()
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

    public static Vehicle[] CreateVehicleList()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameData/GameData.json");
        JSONNode N = JSON.Parse(json);
        Vehicle[] vehicles = new Vehicle[N["vehicles"].Count];
        for (int i = 0; i < vehicles.Length; i++)
        {
            JSONNode vehicleData = N["vehicles"][i];
            vehicles[i] = new Vehicle
                (
                    vehicleData["name"].Value,
                    vehicleData["description"].Value,
                    int.Parse(vehicleData["maxHealth"].Value),
                    float.Parse(vehicleData["maxFuel"].Value),
                    float.Parse(vehicleData["velocity"].Value),
                    vehicleData["car"].Value,
                    new Vector3(float.Parse(vehicleData["dimensions"]["x"].Value),
                                float.Parse(vehicleData["dimensions"]["y"].Value),
                                float.Parse(vehicleData["dimensions"]["z"].Value)),
                    new Vector3(float.Parse(vehicleData["gameLocation"]["x"].Value),
                                float.Parse(vehicleData["gameLocation"]["y"].Value),
                                float.Parse(vehicleData["gameLocation"]["z"].Value)),
                    new Vector3(float.Parse(vehicleData["viewingLocation"]["x"].Value),
                                float.Parse(vehicleData["viewingLocation"]["y"].Value),
                                float.Parse(vehicleData["viewingLocation"]["z"].Value)),
                    new Vector3(float.Parse(vehicleData["gameScale"]["x"].Value),
                                float.Parse(vehicleData["gameScale"]["y"].Value),
                                float.Parse(vehicleData["gameScale"]["z"].Value)),
                    new Vector3(float.Parse(vehicleData["viewingScale"]["x"].Value),
                                float.Parse(vehicleData["viewingScale"]["y"].Value),
                                float.Parse(vehicleData["viewingScale"]["z"].Value)),
                    price:                vehicleData["price"].Value                != "" ? int.Parse(vehicleData["price"].Value)                  : int.Parse(OPTIONAL_VALUE_DEFAULTS["price"]),
                    illuminationHeight:   vehicleData["illuminationHeight"].Value   != "" ? float.Parse(vehicleData["illuminationHeight"].Value)   : float.Parse(OPTIONAL_VALUE_DEFAULTS["illuminationHeight"]),
                    mmScale:              vehicleData["mmScale"].Value              != "" ? float.Parse(vehicleData["mmScale"].Value)              : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmScale"]),
                    mmPosX:               vehicleData["mmPosX"].Value               != "" ? float.Parse(vehicleData["mmPosX"].Value)               : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosX"]),
                    mmPosY:               vehicleData["mmPosY"].Value               != "" ? float.Parse(vehicleData["mmPosY"].Value)               : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosY"]),
                    mmPosZ:               vehicleData["mmPosZ"].Value               != "" ? float.Parse(vehicleData["mmPosZ"].Value)               : float.Parse(OPTIONAL_VALUE_DEFAULTS["mmPosZ"]),
                    rotX:                 vehicleData["rotX"].Value                 != "" ? float.Parse(vehicleData["rotX"].Value)                 : float.Parse(OPTIONAL_VALUE_DEFAULTS["rotX"]),
                    rotY:                 vehicleData["rotY"].Value                 != "" ? float.Parse(vehicleData["rotY"].Value)                 : float.Parse(OPTIONAL_VALUE_DEFAULTS["rotY"]),
                    forceFieldRadius:     vehicleData["forceFieldRadius"].Value     != "" ? float.Parse(vehicleData["forceFieldRadius"].Value)     : float.Parse(OPTIONAL_VALUE_DEFAULTS["forceFieldRadius"]),
                    headlightOffsetAddOn: vehicleData["headlightOffsetAddOn"].Value != "" ? float.Parse(vehicleData["headlightOffsetAddOn"].Value) : float.Parse(OPTIONAL_VALUE_DEFAULTS["headlightOffsetAddOn"]),
                    hasCustomHeadlights:  vehicleData["hasCustomHeadlights"].Value  != "" ? bool.Parse(vehicleData["hasCustomHeadlights"].Value)   : bool.Parse(OPTIONAL_VALUE_DEFAULTS["hasCustomHeadlights"]),
                    prizeDistance:        vehicleData["prizeDistance"].Value        != "" ? float.Parse(vehicleData["prizeDistance"].Value)        : float.Parse(OPTIONAL_VALUE_DEFAULTS["prizeDistance"])
                );
        }
        return vehicles;
    }

    public static WorldTerrain[] CreateWorldTerrainList()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameData/GameData.json");
        JSONNode N = JSON.Parse(json);
        WorldTerrain[] worldTerrains = new WorldTerrain[N["roads"].Count];
        for (int i = 0; i < worldTerrains.Length; i++)
        {
            JSONNode worldTerainData = N["roads"][i];
            Animal[] worldAnimals = new Animal[worldTerainData["animals"].Count];
            for (int j = 0; j < worldAnimals.Length; j++)
            {
                JSONNode animalData = worldTerainData["animals"][i];
                worldAnimals[j] = new Animal
                    (
                        animalData["name"].Value,
                        animalData["animal"].Value,
                        float.Parse(animalData["damage"].Value),
                        float.Parse(animalData["velocity"].Value)
                    );
            }
            worldTerrains[i] = new WorldTerrain
                (
                    worldTerainData["name"].Value,
                    worldTerainData["normalRoad"].Value,
                    worldTerainData["gasRoad"].Value,
                    worldAnimals,
                    worldTerainData["material"].Value
                );
        }
        return worldTerrains;
    }
}

