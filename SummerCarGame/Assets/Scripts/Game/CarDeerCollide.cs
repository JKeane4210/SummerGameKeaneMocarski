using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeerCollide : MonoBehaviour
{
    static bool explosionsEnabled = false;
    public GameObject health_bar;
    private float health_lost = 10f;
    public GameObject explosionEffect;
    //public DeerRunning deer;

    private void Start()
    {
        if(gameObject.GetComponent<UnityEngine.UI.Text>() != null)
        {
            if (explosionsEnabled)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = "Explosions Enabled: Yes";
            }
            else if (!explosionsEnabled)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = "Explosions Enabled: No";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        HealthBar health = health_bar.GetComponent<HealthBar>();
        if (other.gameObject.tag == "Animal")
        {
            //Debug.Log(other);
            health.DecreaseHealth(health_lost);
            Destroy(other);
            Explode(other);
        }
    }

    void Explode(Collider col)
    {
        if (explosionsEnabled)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            //Destroy(col.gameObject); //kills the deer :( --> I won't include this now
        }
    }

    public void ChangeExplosionsStatus()
    {
        if(explosionsEnabled)
        {
            explosionsEnabled = false;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Explosions Enabled: No";
        }
        else if(!explosionsEnabled)
        {
            explosionsEnabled = true;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "Explosions Enabled: Yes";
        }
    }

    public bool GetExplosionsStatus()
    {
        return explosionsEnabled;
    }
}

//'deer3(Clone) (UnityEngine.BoxCollider)'
//UnityEngine.Debug:Log(Object)
//CarDeerCollide:OnTriggerEnter(Collider) (at Assets/Scripts/CarDeerCollide.cs:12)