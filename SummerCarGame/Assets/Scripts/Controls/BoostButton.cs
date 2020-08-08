using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostButton : MonoBehaviour
{
    public GameObject button;
    public GameObject mainCamera;
    private GameObject car;
    private bool isBoosting = false;
    private float timeSinceBoost = 0.5f;
    private float normalBostLength = 0.5f;
    private float carVelIncreaseFactor = 20;
    private float followingDistanceIncreaseFactor = 1;
    private float carSlowingDivider = 4;

    // Start is called before the first frame update
    public void SimulateStart()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Image>().fillAmount = 0;
        button.GetComponent<Button>().onClick.AddListener(delegate { Boost(); });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Image>().fillAmount += 0.002f;
        if (GetComponent<Image>().fillAmount == 1)
            button.GetComponent<Button>().interactable = true;
        else
            button.GetComponent<Button>().interactable = false;
        if (isBoosting)
        {
            timeSinceBoost -= Time.deltaTime;
            car.GetComponent<SwipeControls>().velocity += Time.deltaTime * ((normalBostLength - timeSinceBoost)/ normalBostLength) * carVelIncreaseFactor;
            car.GetComponent<MoveCar>().forward_vel += Time.deltaTime * ((normalBostLength - timeSinceBoost) / normalBostLength) * carVelIncreaseFactor;
            car.GetComponent<Accelerometer>().forward_vel += Time.deltaTime * ((normalBostLength - timeSinceBoost) / normalBostLength) * carVelIncreaseFactor;
            mainCamera.GetComponent<CameraFollow>().followingDistance += Time.deltaTime * followingDistanceIncreaseFactor;
        }
        if (timeSinceBoost <= 0)
        {
            isBoosting = false;
            //timeSinceBoost = normalBostLength;
        }            
        //print(mainCamera.GetComponent<CameraFollow>().followingDistance > 5);
        if(!isBoosting && mainCamera.GetComponent<CameraFollow>().followingDistance > 5)
        {
            timeSinceBoost += Time.deltaTime / carSlowingDivider;
            car.GetComponent<SwipeControls>().velocity -= Time.deltaTime * ((normalBostLength - timeSinceBoost) / normalBostLength) * carVelIncreaseFactor / carSlowingDivider;
            car.GetComponent<MoveCar>().forward_vel -= Time.deltaTime * ((normalBostLength - timeSinceBoost) / normalBostLength) * carVelIncreaseFactor / carSlowingDivider;
            car.GetComponent<Accelerometer>().forward_vel -= Time.deltaTime * ((normalBostLength - timeSinceBoost) / normalBostLength) * carVelIncreaseFactor / carSlowingDivider;
            mainCamera.GetComponent<CameraFollow>().followingDistance -= Time.deltaTime * followingDistanceIncreaseFactor / carSlowingDivider;
        }
            
    }

    public void Boost()
    {
        GetComponent<Image>().fillAmount = 0;
        isBoosting = true;
    }
}
