﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;
    public float swipeVelocity;
    public float speed = 10f;

   
    private void Start()
    {
        desiredPosition = player.transform.position;  

    }
    private void Update()
    {
        if(swipeControls.SwipeLeft)
            desiredPosition += Vector3.left * swipeVelocity * speed * Time.deltaTime;
        if(swipeControls.SwipeRight)
            desiredPosition += Vector3.right * swipeVelocity * speed * Time.deltaTime;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 10f * Time.deltaTime);

        if(swipeControls.Tap)
            Debug.Log("Tap");
        
    }
    
}
