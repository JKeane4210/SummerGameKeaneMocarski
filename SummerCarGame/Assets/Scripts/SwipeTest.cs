using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;
    public float motion_multiplier; 
    public Rigidbody car_rb;
    private Vector3 trajectory = Vector3.forward + Vector3.up * 1.5f;
    void Start()
    {
        trajectory = motion_multiplier * new Vector3(Mathf.Cos(player.localRotation.y), 0f, -Mathf.Sin(player.localRotation.y));
    }
    private void Update()
    {
        if(swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;
        if(swipeControls.SwipeRight)
            desiredPosition += Vector3.right;

        car_rb.velocity = trajectory; 
           
        if(swipeControls.Tap)
            Debug.Log("Tap");
    }
}
