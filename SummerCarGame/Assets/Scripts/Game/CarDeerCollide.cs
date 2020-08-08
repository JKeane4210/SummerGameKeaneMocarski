using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarDeerCollide : MonoBehaviour
{
    public bool goldAnimal = false;
    static bool explosionsEnabled = false;
    public GameObject health_bar;
    //private float health_lost = 10f;
    public GameObject explosionEffect;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        if(gameObject.GetComponent<Text>() != null)
        {
            if (explosionsEnabled)
            {
                gameObject.GetComponent<Text>().text = "Explosions Enabled: Yes";
            }
            else if (!explosionsEnabled)
            {
                gameObject.GetComponent<Text>().text = "Explosions Enabled: No";
            }
        }
    }

    void Update()
    {
        if (!canvas.GetComponent<powerUpBoard>().AllTrue("Animal"))
            goldAnimal = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!goldAnimal)
        {
            //Debug.Log(other);
            HealthBar health = health_bar.GetComponent<HealthBar>();
            if (other.gameObject.tag == "Animal")
            {
                //Debug.Log(other);
                health.DecreaseHealth(other.GetComponent<DeerRunning>().GetDamage());
                Destroy(other);
                Explode(other);
            }
        }
        else
        {
            if (other.gameObject.tag == "Animal")
            {
                GameDataManager.AddCoins((int)other.GetComponent<DeerRunning>().GetDamage() * 2);
                GameSharedUI.Instance.UpdateCoinsUIText();
                GameObject addedAnim = (GameObject)Resources.Load("Models/UI_Stuff/CoinsAdded");
                GameObject addToScreen = Instantiate(addedAnim, addedAnim.transform.position, addedAnim.transform.rotation);
                addToScreen.GetComponent<TextAddAnimation>().coinAdd = (int)other.GetComponent<DeerRunning>().GetDamage() * 2;
                addToScreen.transform.SetParent(canvas.transform, false);
            }
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
            gameObject.GetComponent<Text>().text = "Explosions Enabled: No";
        }
        else if(!explosionsEnabled)
        {
            explosionsEnabled = true;
            gameObject.GetComponent<Text>().text = "Explosions Enabled: Yes";
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