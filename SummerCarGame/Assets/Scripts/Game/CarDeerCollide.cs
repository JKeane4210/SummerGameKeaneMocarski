﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarDeerCollide : MonoBehaviour
{
    public bool goldAnimal = false;
    public bool forceFieldOn = false;
    public GameObject healthBar;
    public GameObject explosionEffect;

    private GameObject canvas;

    void Start() => canvas = GameObject.FindGameObjectWithTag("Canvas");

    void Update()
    {
        if (canvas.GetComponent<powerUpBoard>().powerUpCounts[1] == 0)
            goldAnimal = false;
        if (canvas.GetComponent<powerUpBoard>().powerUpCounts[2] == 0)
        {
            forceFieldOn = false;
            if (GetComponentInChildren<PowerUp>() != null)
                Destroy(GetComponentInChildren<PowerUp>().gameObject);
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (!goldAnimal)
        {
            if (otherCollider.tag == "Animal" && !forceFieldOn)
            {
                HealthBar health = healthBar.GetComponent<HealthBar>();
                health.DecreaseHealth(otherCollider.GetComponent<DeerRunning>().GetDamage());
                Destroy(otherCollider);
                Explode();
            }
        }
        else
        {
            if (otherCollider.tag == "Animal")
            {
                GameDataManager.AddCoins((int)otherCollider.GetComponent<DeerRunning>().GetDamage() * 2);
                GameSharedUI.Instance.UpdateCoinsUIText();
                GameObject addedAnim = (GameObject)Resources.Load("Models/UI_Stuff/CoinsAdded");
                GameObject addToScreen = Instantiate(addedAnim, addedAnim.transform.position, addedAnim.transform.rotation);
                int activeTwoTimes = canvas.GetComponent<powerUpBoard>().powerUpCounts[0];
                if (activeTwoTimes > 0)
                    addToScreen.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                addToScreen.GetComponent<TextAddAnimation>().coinAdd = (int)otherCollider.GetComponent<DeerRunning>().GetDamage() * 2 * (int)Mathf.Pow(2, activeTwoTimes);
                addToScreen.transform.SetParent(canvas.transform, false);
                if (otherCollider.gameObject.GetComponentInChildren<ParticleSystem>() != null)
                    otherCollider.gameObject.GetComponentInChildren<ParticleSystem>().gameObject.transform.SetParent(null);
                Destroy(otherCollider.gameObject);
            }
        }
    }

    void Explode()
    {
        if (GameDataManager.ExplosionsEnabled())
            Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
