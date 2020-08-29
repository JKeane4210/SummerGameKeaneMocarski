using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAwardRoad : MonoBehaviour
{
    public GameObject coinGameObject;
    public GameObject mainCamera;
    public GameObject sliderImage;
    public GameObject slider;
    public GameObject awardMarker;
    public AudioClip purchaseSound;

    private float pointA;
    private float pointB;

    private const float SCALE_FACTOR = 2;
    private const float PRIZE_Y = -3;
    private const float COIN_OFFSET_Y = 1;
    private const float SLIDER_SCALE_FACTOR = 110;
    private const float SCREEN_WIDTH = 1334;

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
        Time.timeScale = 1;
        slider.GetComponent<RectTransform>().sizeDelta = new Vector2(prizes[prizes.Length - 1].distanceToEarn * SLIDER_SCALE_FACTOR , 10);
        slider.GetComponent<RectTransform>().localPosition = new Vector3(slider.transform.localPosition.x + (prizes[prizes.Length - 1].distanceToEarn * SLIDER_SCALE_FACTOR - SCREEN_WIDTH) / 2, slider.transform.localPosition.y, slider.transform.localPosition.z);
        slider.GetComponent<Slider>().normalizedValue = GameDataManager.GetTotalDistance() / prizes[prizes.Length - 1].distanceToEarn;
        VehicleList vehicleList = new VehicleList();
        vehicleList.SimulateStart();
        foreach (Prize prize in prizes)
        {
            GameObject newAwardMarker = Instantiate(awardMarker, new Vector3(), Quaternion.identity, sliderImage.transform);
            newAwardMarker.GetComponent<RectTransform>().localPosition = new Vector3(prize.distanceToEarn * SLIDER_SCALE_FACTOR, 55, 0);
            AwardMarker_ awardMarker_ = newAwardMarker.GetComponent<AwardMarker_>();
            awardMarker_.prize = prize;
            awardMarker_.distanceToEarnText.text = $"{prize.distanceToEarn} mi.";
            awardMarker_.claimButton.onClick.AddListener(delegate { prize.ClaimPrize(); });
            awardMarker_.claimButton.onClick.AddListener(delegate { AudioSource.PlayClipAtPoint(purchaseSound, mainCamera.transform.position, 10); });
            awardMarker_.claimButton.onClick.AddListener(delegate { awardMarker_.claimButton.gameObject.SetActive(false); });
            awardMarker_.claimButton.onClick.AddListener(delegate { awardMarker_.claimedCheck.SetActive(true); });
            awardMarker_.claimButton.onClick.AddListener(delegate { GameDataManager.AddPrize(prize.distanceToEarn); });
            if (GameDataManager.GetEarnedPrizes().Contains(prize.distanceToEarn))
                awardMarker_.claimedCheck.SetActive(true);
            else
                awardMarker_.claimedCheck.SetActive(false);
            if (GameDataManager.GetTotalDistance() >= prize.distanceToEarn && !GameDataManager.GetEarnedPrizes().Contains(prize.distanceToEarn))
                awardMarker_.claimButton.gameObject.SetActive(true);
            else
                awardMarker_.claimButton.gameObject.SetActive(false);
            if (prize.coinReward != 0)
            {
                awardMarker_.prizeText.text = $"{prize.coinReward} coins";
                Instantiate(coinGameObject, new Vector3(prize.distanceToEarn * SCALE_FACTOR, COIN_OFFSET_Y + PRIZE_Y, 0), Quaternion.identity);
            }
            else
            {
                awardMarker_.prizeText.text = prize.carName;
                Instantiate((GameObject)Resources.Load(vehicleList.GetVehicleByName(prize.carName).car), new Vector3(prize.distanceToEarn * SCALE_FACTOR, PRIZE_Y, 0), Quaternion.Euler(new Vector3(0, -150, 0)));
            }
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
                    Vector3 sliderPos = sliderImage.GetComponent<RectTransform>().position;
                    sliderImage.GetComponent<RectTransform>().position = new Vector3(sliderPos.x + (pointB - pointA) * -0.1f, sliderPos.y, sliderPos.z);
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
            Vector3 sliderPos = sliderImage.GetComponent<RectTransform>().position;
            sliderImage.GetComponent<RectTransform>().position = new Vector3(prizes[prizes.Length - 1].distanceToEarn * mainCamera.transform.position.x / -SCALE_FACTOR, sliderPos.y, sliderPos.z);
            if (mainCamera.transform.position.x > prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR)
                mainCamera.transform.position = new Vector3(prizes[prizes.Length - 1].distanceToEarn * SCALE_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            else if (mainCamera.transform.position.x < 0)
                mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
            pointA = pointB;
        }
    }
}
