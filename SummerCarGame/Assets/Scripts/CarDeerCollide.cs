using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeerCollide : MonoBehaviour
{
    public GameObject health_bar;
    private float health_lost = 10f;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        HealthBar health = health_bar.GetComponent<HealthBar>();
        if (other.ToString().Contains("deer3"))
        {
            //Debug.Log(other);
            health.DecreaseHealth(health_lost);
        }
    }
}

//'deer3(Clone) (UnityEngine.BoxCollider)'
//UnityEngine.Debug:Log(Object)
//CarDeerCollide:OnTriggerEnter(Collider) (at Assets/Scripts/CarDeerCollide.cs:12)