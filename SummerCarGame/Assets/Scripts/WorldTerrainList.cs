using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainList : MonoBehaviour
{
    static WorldTerrain selectedTerrain;
    /* WorldTerrain Constructor Order:
     * name (string)
     * normalRoad (GameObject)
     * gasRoad (GameObject)
     * animals (Animal[])
     */

    /* Animal Constructor Order:
     *   name (string)
     *   animal (GameObject)
     *   damage (float)
     *   average_speed (float)
     */
    private WorldTerrain[] worldTerrains; 

    void Start()
    {
        worldTerrains = new WorldTerrain[]
        {
            new WorldTerrain("North Woods",
                             (GameObject)Resources.Load("Models/Roads/forestRoadNormal"),
                             (GameObject)Resources.Load("Models/Roads/forestRoadGasStopPainted"),
                             new Animal[]{
                                 new Animal("Deer", (GameObject)Resources.Load("Models/Animals/deer3"), 10f, 10.5f)

                             }),
            new WorldTerrain("Savannah",
                            (GameObject)Resources.Load("Models/Roads/Savannah/savannahRoadCompress"),
                            (GameObject)Resources.Load("Models/Roads/Savannah/savannahRoadGasStopCompress"),
                            new Animal[]{
                                new Animal("Giraffe", (GameObject)Resources.Load("Models/Animals/SavannahAnimals/giraffe"), 15f, 10f)
                            })
        };
        if (selectedTerrain == null)
            selectedTerrain = worldTerrains[0];
    }

    public WorldTerrain GetSelectedTerrain()
    {
        return selectedTerrain;
    }

    public WorldTerrain[] GetWorldTerrains()
    {
        return worldTerrains;
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

    public void SetSelectedTerrain(int i)
    {
        selectedTerrain = worldTerrains[i];
    }
}
