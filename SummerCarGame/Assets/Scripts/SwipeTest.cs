using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;
    public float swipeVelocity;

    private void Start()
    {
        desiredPosition = player.transform.position;  
    }
    private void Update()
    {
        if(swipeControls.SwipeLeft)
            desiredPosition += Vector3.left * swipeVelocity;
        if(swipeControls.SwipeRight)
            desiredPosition += Vector3.right * swipeVelocity;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
        
        if(swipeControls.Tap)
            Debug.Log("Tap");
    }
}
