using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    readonly private string name;
    readonly private string animal;
    readonly private float damage;
    readonly private float averageSpeed;

    public Animal(string name, string animal, float damage, float averageSpeed)
    {
        this.name         = name;
        this.animal       = animal;
        this.damage       = damage;
        this.averageSpeed = averageSpeed;
    }

    public GameObject GetAnimal()                              => (GameObject)Resources.Load(animal);
    public GameObject PlaceAnimal(Vector3 loc, Quaternion rot) => GameObject.Instantiate(GetAnimal(), loc, rot);
    public string GetName()                                    => name;
    public float GetDamage()                                   => damage;
    public float GetAverageSpeed()                             => averageSpeed;
}
