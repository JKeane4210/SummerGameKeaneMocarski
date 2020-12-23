using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrizeWheel : MonoBehaviour
{
    public GameObject wheel;
    public GameObject sliceImage;
    public GameObject claimButton;
    public GameObject prizeText;
    public GameObject timeUntilAvailableText;
    public GameObject mainCamera;

    public AudioClip purchaseSound;

    public Color color1;
    public Color color2;

    private const float SPACING = 0;
    private const float DAMPENING_FACTOR = 1;

    private float wheelSpeed;

    private static bool spinAllowed = false;
    private static DateTime nextSpinTime;

    readonly private WheelPrize[] wheelPrizes = new WheelPrize[]
    {
        new WheelPrize(200),
        new WheelPrize(500),
        new WheelPrize(200),
        new WheelPrize(500),
        new WheelPrize(200),
        new WheelPrize(100),
        new WheelPrize(1000),
        new WheelPrize(500)
    };

    void Start()
    {
        nextSpinTime = GameDataManager.GetNextSpinDate();
        Time.timeScale = 1;
        int i = 0;
        foreach (WheelPrize wheelPrize in wheelPrizes)
        {
            GameObject newSlice = Instantiate(sliceImage, new Vector3(0, 0, 0), Quaternion.identity, wheel.transform);
            newSlice.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, ((float)i / wheelPrizes.Length - 1) * 360);
            newSlice.transform.localPosition = new Vector3(0, 0, 0);
            newSlice.GetComponent<WheelSlice>().sliceImage.color = i % 2 == 0 ? color1 : color2;
            newSlice.GetComponent<Image>().fillAmount = 1f / wheelPrizes.Length - SPACING;
            newSlice.GetComponent<WheelSlice>().prizeText.text = $"{wheelPrize.prize}";
            i++;
        }
        claimButton.SetActive(false);
        prizeText.SetActive(false);
        timeUntilAvailableText.SetActive(true);
        GameSharedUI.Instance.UpdateCoinsUIText();
    }

    void FixedUpdate()
    {
        if (spinAllowed)
        {
            timeUntilAvailableText.GetComponent<Text>().text = "NOW!\nClick to spin";
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                wheelSpeed = UnityEngine.Random.Range(500, 600);
                DateTime tomorrow = DateTime.Now + new TimeSpan(1, 0, 0, 0); // spin time
                nextSpinTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 0, 0, 0);
                GameDataManager.SetNextSpinDate(new int[] { tomorrow.Year, tomorrow.Month, tomorrow.Day });
                SavePlayerData.SavePlayer();
                spinAllowed = false;
            }
        }
        else
        {
            TimeSpan timeDifference = nextSpinTime - DateTime.Now;
            timeUntilAvailableText.GetComponent<Text>().text = $"Time Until Next Spin:\n{timeDifference.Hours} hrs, {timeDifference.Minutes} min, {timeDifference.Seconds} sec";
            if (timeDifference.Seconds < 0)
                spinAllowed = true;
        }
        if (wheelSpeed > 0) // in the process of spinning
        {
            wheel.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, wheel.GetComponent<RectTransform>().localEulerAngles.z + wheelSpeed * Time.deltaTime);
            if (wheelSpeed > DAMPENING_FACTOR)
                wheelSpeed -= DAMPENING_FACTOR;
            else
            {
                wheelSpeed = 0;
                float wheelLocation = wheel.GetComponent<RectTransform>().localEulerAngles.z;
                int wheelPrizeIndex = wheelPrizes.Length - 1 - (int)(wheelLocation / 360f * (float)wheelPrizes.Length);
                int prize = wheelPrizes[wheelPrizeIndex].prize;
                prizeText.GetComponent<Text>().text = $"Your Prize:\n{prize}";
                prizeText.SetActive(true);
                claimButton.SetActive(true);
                spinAllowed = false;
                timeUntilAvailableText.SetActive(false);
                claimButton.GetComponent<Button>().onClick.RemoveAllListeners();
                claimButton.GetComponent<Button>().onClick.AddListener(delegate
                {
                    GameDataManager.AddCoins(prize);
                    if (GameDataManager.SoundEffectsEnabled())
                        AudioSource.PlayClipAtPoint(purchaseSound, mainCamera.transform.position, 10);
                    prizeText.SetActive(false);
                    claimButton.SetActive(false);
                    timeUntilAvailableText.SetActive(true);
                    GameSharedUI.Instance.UpdateCoinsUIText();
                    print(nextSpinTime);
                });
            }
        }
    }
}

public class WheelPrize // basically a glorified int right now, but this class can be built up to hold alternate prizes
{
    public int prize;

    public WheelPrize(int prize)
    {
        this.prize = prize;
    }
}