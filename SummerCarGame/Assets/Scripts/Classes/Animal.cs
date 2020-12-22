using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : GamePiece
{
    readonly private float damage;
    readonly private float averageSpeed;

    public Animal(string name, string animal, float damage, float averageSpeed) : base(name, animal)
    {
        this.damage = damage;
        this.averageSpeed = averageSpeed;
    }

    //public GameObject GetAnimal() => (GameObject)Resources.Load(GetAssetPath());
    //public GameObject PlaceAnimal(Vector3 loc, Quaternion rot) => GameObject.Instantiate(GetAnimal(), loc, rot);
    public float GetDamage() => damage;
    public float GetAverageSpeed() => averageSpeed;
}
