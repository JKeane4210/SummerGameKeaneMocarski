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

    public float GetDamage() => damage;
    public float GetAverageSpeed() => averageSpeed;
}
