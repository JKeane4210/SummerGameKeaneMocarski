using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnCollide : MonoBehaviour
{
    /// <summary>
    /// UNUSED: What to do when an event triggers game over
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<HealthBar>().DecreaseHealth(other.gameObject.GetComponent<Car>().maxHealth);
    }
}
