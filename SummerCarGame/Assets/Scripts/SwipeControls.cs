using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeControls : MonoBehaviour
{
    public Rigidbody car;
    public float latVelMultiplier;
    public float velocity;
    private Vector2 pointA;
    private Vector2 pointB;
    private float latVel = 0f;

    // Update is called once per frame
    void Update()
    {
        car.velocity = new Vector3(latVelMultiplier * latVel, 0f, velocity);
        //>>>For iPhone touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    pointA = Input.GetTouch(0).position;
                    break;
                case TouchPhase.Moved:
                    pointB = Input.GetTouch(0).position;
                    //print("Point A:" + pointA.ToString() + "\nPointB: " + pointB.ToString());
                    latVel = pointB.x - pointA.x;
                    break;
                case TouchPhase.Ended:
                    latVel = 0;
                    break;

            }
        }
        else
            latVel = 0;
        // >>> For Mouse Clicking So You Can Test On The Screen
        if(Input.GetMouseButtonDown(0))
        {
            pointA = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if(Input.GetMouseButton(0))
        {
            pointB = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            latVel = pointB.x - pointA.x;
        }
        else
        {
            latVel = 0;
        }
    }
}
