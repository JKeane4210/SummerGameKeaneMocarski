﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
   private bool tap, swipeLeft, swipeRight;
   private bool isDragging = false;
   private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion
    
        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion
    
        // calculate the distance
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //did we cross deadzone
        if(swipeDelta.magnitude > 125)
        {
            //which direction is swipe
            float x = swipeDelta.x;
            
            if (x > 0)
                swipeRight = true;
            if (x < 0) 
                swipeLeft = true;
            Reset();
        }
    }

    private void Reset()
    {
        // startTouch = swipeDelta = Vector2.zero;
        // isDragging = false;
    }
   public bool Tap { get { return tap; }}
   public Vector2 SwipeDelta { get { return swipeDelta;}}
   public bool SwipeLeft { get { return swipeLeft; } }
   public bool SwipeRight { get { return swipeRight; } }
   

}
