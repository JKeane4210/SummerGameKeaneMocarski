﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMover : MonoBehaviour
{
    public AudioClip coinPickup;

    private const float BOBBING_SPEED = 2f;
    private const float BOBBING_AMPLITUDE = 1f;
    private GameObject canvas;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    /// <summary>
    /// Rotates and bobs the coin a update frame's worth
    /// </summary>
    void Update()
    {
        transform.Rotate(new Vector3(0f, 150f, 0f) * Time.deltaTime);
        float newY = Mathf.Sin(BOBBING_SPEED * Time.time) * BOBBING_AMPLITUDE + initialPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    /// <summary>
    /// What to do when the coin is collided with
    /// </summary>
    /// <param name="other">The other object that was collided with (the car)</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RemoveAndAddCount(other);
            if (GameDataManager.SoundEffectsEnabled())
                AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1f);
            GameObject addedAnim = (GameObject)Resources.Load("Models/UI_Stuff/CoinsAdded");
            GameObject addToScreen = Instantiate(addedAnim, addedAnim.transform.position, addedAnim.transform.rotation);
            addToScreen.GetComponent<TextAddAnimation>().coinAdd = other.gameObject.GetComponent<CoinCounter>().coinAddition;
            if (canvas.GetComponent<powerUpBoard>().powerUpCounts[0] > 0)
                addToScreen.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            addToScreen.transform.SetParent(canvas.transform, false);
        }
    }

    /// <summary>
    /// Removes teh coin from the scene and adds a coin to your total
    /// </summary>
    /// <param name="player">The player collider</param>
    void RemoveAndAddCount(Collider player)
    {
        CoinCounter c = player.GetComponent<CoinCounter>();
        c.AddCoin();
        Destroy(gameObject);
    }
}
