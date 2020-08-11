using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain
{
    private string name;
    private GameObject normalRoad;
    private GameObject gasRoad;
    private Animal[] animals;
    private Material normal_road_mat;

    public WorldTerrain(string n, GameObject road, GameObject gas, Animal[] anims, Material m)
    {
        name = n;
        normalRoad = road;
        gasRoad = gas;
        animals = anims;
        normal_road_mat = m;
    }

    public string GetName() => name;
    public GameObject GetNormalRoad() => normalRoad;
    public GameObject GetGasRoad() => gasRoad;
    public Animal[] GetAnimals() => animals;
    public Material GetNormalRoadMat() => normal_road_mat;
}
