using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    private string name;
    private GameObject animal;
    private float damage;
    private float average_speed;

    public Animal(string n, GameObject anim, float d, float v)
    {
        name = n;
        animal = anim;
        damage = d;
        average_speed = v;
    }

    public GameObject GetAnimal()
    {
        return animal;
    }

    public GameObject PlaceAnimal(Vector3 loc, Quaternion rot)
    {
        return GameObject.Instantiate(animal, loc, rot);
    }

    public string GetName()
    {
        return name;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetAverageSpeed()
    {
        return average_speed;
    }
}
