using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrain
{
    private string name;
    private GameObject normalRoad;
    private GameObject gasRoad;
    private Animal[] animals;

    public WorldTerrain(string n, GameObject road, GameObject gas, Animal[] anims)
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

    public Animal[] GetAnimals()
    {
        return animals;
    }
}
