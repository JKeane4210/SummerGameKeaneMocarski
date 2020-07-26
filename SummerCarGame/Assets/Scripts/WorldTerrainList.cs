using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainList : MonoBehaviour
{
    static WorldTerrain selectedTerrain;
    private WorldTerrain[] worldTerrains = new WorldTerrain[]
        {
            new WorldTerrain("North Woods",
                             (GameObject)Resources.Load("Models/Roads/forestRoadNormal"),
                             (GameObject)Resources.Load("Models/Roads/forestRoadGasStopPainted"),
                             new GameObject[]{
                                 (GameObject)Resources.Load("Models/Animals/deer3")
                             }),
            new WorldTerrain("Savannah",
                            (GameObject)Resources.Load("Models/Roads/Savannah/savannahRoadNormal.prefab"),
                            (GameObject)Resources.Load("Models/Roads/Savannah/savannahRoadGasStop.prefab"),
                            new GameObject[]{
                                            }
                            )
        };

    void Start()
    {
        if (selectedTerrain == null)
            selectedTerrain = worldTerrains[0];
    }

    public WorldTerrain GetSelectedTerrain()
    {
        return selectedTerrain;
    }

    public GameObject GetStaticNormalRoad()
    {
        return selectedTerrain.GetNormalRoad();
    }

    public GameObject GetActiveRoad()
    {
        return selectedTerrain.GetNormalRoad();
    }

    public GameObject GetGasRoad()
    {
        return selectedTerrain.GetGasRoad();
    }
}
