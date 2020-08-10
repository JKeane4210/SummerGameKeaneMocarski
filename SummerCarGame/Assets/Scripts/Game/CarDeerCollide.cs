﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarDeerCollide : MonoBehaviour
{
    public bool goldAnimal = false;
    static bool explosionsEnabled = false;
    public GameObject health_bar;
    public GameObject explosionEffect;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        UpdateExplosionStatus();
    }

    void Update()
    {
        if (canvas.GetComponent<powerUpBoard>().powerUpCounts[1] == 0)
            goldAnimal = false;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (!goldAnimal)
        {
            HealthBar health = health_bar.GetComponent<HealthBar>();
            if (otherCollider.gameObject.tag == "Animal")
            {
                health.DecreaseHealth(otherCollider.GetComponent<DeerRunning>().GetDamage());
                Destroy(otherCollider);
                Explode();
            }
        }
        else
        {
            if (otherCollider.gameObject.tag == "Animal")
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
                otherCollider.gameObject.GetComponentInChildren<ParticleSystem>().gameObject.transform.SetParent(null);
                Destroy(otherCollider.gameObject);
            }
        }
    }

    void Explode()
    {
        if (explosionsEnabled)
            Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    public void ChangeExplosionsStatus()
    {
        explosionsEnabled = !explosionsEnabled;
        UpdateExplosionStatus();
    }

    public void UpdateExplosionStatus()
    {
        Text explosionsEnabledText = gameObject.GetComponent<Text>();
        if (explosionsEnabledText != null)
        {
            if (explosionsEnabled)
                explosionsEnabledText.text = "Explosions Enabled: Yes";
            else
                explosionsEnabledText.text = "Explosions Enabled: No";
        }
    }

    public bool GetExplosionsStatus() => explosionsEnabled;
}
