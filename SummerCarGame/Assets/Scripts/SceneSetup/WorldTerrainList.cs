using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainList : MonoBehaviour
{
    static WorldTerrain selectedTerrain;
    static int selectedTerrainInd;

    private WorldTerrain[] worldTerrains;

    void Start() => SimulateStart();

    public void SimulateStart()
    {
        worldTerrains = GameDataJSONReader.CreateWorldTerrainList();
        selectedTerrain = selectedTerrain ?? worldTerrains[0];
    }

    public void SetSelectedTerrain(int i)
    {
        selectedTerrain = worldTerrains[i];
        selectedTerrainInd = i;
    }

    public WorldTerrain GetSelectedTerrain() => selectedTerrain;
    public WorldTerrain[] GetWorldTerrains() => worldTerrains;
    public GameObject GetStaticNormalRoad() => selectedTerrain.GetNormalRoad();
    public GameObject GetActiveRoad() => selectedTerrain.GetNormalRoad();
    public GameObject GetGasRoad() => selectedTerrain.GetGasRoad();
    public int GetSelectedTerrainInd() => selectedTerrainInd;
}
