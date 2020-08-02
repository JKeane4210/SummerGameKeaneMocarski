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

    public string GetName()
    {
        return name;
    }

    public GameObject GetNormalRoad()
    {
        return normalRoad;
    }

    public GameObject GetGasRoad()
    {
        return gasRoad;
    }

    public Animal[] GetAnimals()
    {
        return animals;
    }

    public Material GetNormalRoadMat()
    {
        return normal_road_mat;
    }
}
