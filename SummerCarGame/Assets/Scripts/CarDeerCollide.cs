﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeerCollide : MonoBehaviour
{
    public HealthBar health;
    private float health_lost = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.ToString() == "deer3(Clone) (UnityEngine.BoxCollider)")
        {
            Debug.Log(other);
            health.DecreaseHealth(health_lost);
        }
    }
}

//'deer3(Clone) (UnityEngine.BoxCollider)'
//UnityEngine.Debug:Log(Object)
//CarDeerCollide:OnTriggerEnter(Collider) (at Assets/Scripts/CarDeerCollide.cs:12)