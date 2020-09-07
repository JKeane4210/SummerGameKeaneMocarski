using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<HealthBar>().DecreaseHealth(other.gameObject.GetComponent<Car>().maxHealth);
    }
}
