using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAwardRoad : MonoBehaviour
{
    public GameObject coinGameObject;
    public GameObject mainCamera;

    private float pointA;
    private float pointB;
    private const float SCALE_FACTOR = 2;
    private const float PRIZE_Y = -2;
    private const float COIN_OFFSET_Y = 1;

    Prize[] prizes = new Prize[]
    {
        new Prize(1, coinReward: 500),
        new Prize(5, coinReward: 1000),
        new Prize(10, coinReward: 1000),
        new Prize(15, carName: "Police Car")
    };

    // Start is called before the first frame update
    void Start()
    {
        VehicleList vehicleList = new VehicleList();
        vehicleList.SimulateStart();
        foreach (Prize prize in prizes)
        {
            if (prize.coinReward != 0)
                Instantiate(coinGameObject, new Vector3(prize.distanceToEarn * 2, COIN_OFFSET_Y + PRIZE_Y, 0), Quaternion.identity);
            else
                Instantiate(vehicleList.GetVehicleByName(prize.carName).car, new Vector3(prize.distanceToEarn * 2, PRIZE_Y, 0), Quaternion.Euler(new Vector3(0, -150, 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    pointA = Input.GetTouch(0).position.x;
                    break;
                case TouchPhase.Moved:
                    pointB = Input.GetTouch(0).position.x;
                    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + (pointB - pointA) * -0.1f, mainCamera.transform.position.y, mainCamera.transform.position.z);
                    pointA = pointB;
                    if (mainCamera.transform.position.x > prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR)
                        mainCamera.transform.position = new Vector3(prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
                    else if (mainCamera.transform.position.x < 0)
                        mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
                    break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            pointB = Input.mousePosition.x;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + (pointB - pointA) * -0.1f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            if (mainCamera.transform.position.x > prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR)
                mainCamera.transform.position = new Vector3(prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            else if (mainCamera.transform.position.x < 0)
                mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
            pointA = pointB;
        }
    }
}
