using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain : GamePiece
{
    readonly private string gasRoad;
    readonly private Animal[] animals;
    readonly private string normalRoadMat;

    public WorldTerrain(string name, string normalRoad, string gasRoad, Animal[] animals, string normalRoadMat) : base(name, normalRoad)
    {
        this.gasRoad = gasRoad;
        this.animals = animals;
        this.normalRoadMat = normalRoadMat;
    }

    public GameObject GetNormalRoad() => GetGameObject();
    public GameObject GetGasRoad() => (GameObject)Resources.Load(gasRoad);
    public Animal[] GetAnimals() => animals;
    public Material GetNormalRoadMat() => (Material)Resources.Load(normalRoadMat);
}
