using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain
{
    readonly private string name;
    readonly private string normalRoad;
    readonly private string gasRoad;
    readonly private Animal[] animals;
    readonly private string normalRoadMat;

    public WorldTerrain(string name, string normalRoad, string gasRoad, Animal[] animals, string normalRoadMat)
    {
        this.name          = name;
        this.normalRoad    = normalRoad;
        this.gasRoad       = gasRoad;
        this.animals       = animals;
        this.normalRoadMat = normalRoadMat;
    }

    public string GetName()            => name;
    public GameObject GetNormalRoad()  => (GameObject)Resources.Load(normalRoad);
    public GameObject GetGasRoad()     => (GameObject)Resources.Load(gasRoad);
    public Animal[] GetAnimals()       => animals;
    public Material GetNormalRoadMat() => (Material)Resources.Load(normalRoadMat);
}
