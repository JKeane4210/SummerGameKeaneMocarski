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

    public GameObject GetAnimal() => animal;
    public GameObject PlaceAnimal(Vector3 loc, Quaternion rot) => GameObject.Instantiate(animal, loc, rot);
    public string GetName() => name;
    public float GetDamage() => damage;
    public float GetAverageSpeed() => average_speed;
}
