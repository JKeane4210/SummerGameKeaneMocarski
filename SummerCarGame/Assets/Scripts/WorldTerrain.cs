using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain
{
    private string name;
    private GameObject normalRoad;
    private GameObject gasRoad;
    private GameObject[] animals;

    public WorldTerrain(string n, GameObject road, GameObject gas, GameObject[] anims)
    {
        name = n;
        normalRoad = road;
        gasRoad = gas;
        animals = anims;
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

    public GameObject[] GetAnimals()
    {
        return animals;
    }
}
