 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeWheel : MonoBehaviour
{
    public GameObject wheel;
    public GameObject sliceImage;

    private const float SPACING = 0.01f;
    private const float DAMPENING_FACTOR = 0.0001f;

    private float wheelSpeed;

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
        int i = 0;
        foreach (WheelPrize wheelPrize in wheelPrizes)
        {
            GameObject newSlice = Instantiate(sliceImage, new Vector3(0, 0, 0), Quaternion.identity, wheel.transform);
            newSlice.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, ((float)i / wheelPrizes.Length - 1) * 360));
            newSlice.transform.localPosition = new Vector3(0, 0, 0);
            newSlice.GetComponent<Image>().fillAmount = 1f / wheelPrizes.Length - SPACING;
            newSlice.GetComponent<WheelSlice>().prizeText.text = $"{wheelPrize.prize}";
            i++;
        }
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            wheelSpeed = Random.Range(2000, 3000);
        if (wheelSpeed > 0)
        {
            wheel.transform.rotation = Quaternion.Euler(new Vector3(0, 0, wheelSpeed * Time.deltaTime + wheel.transform.rotation.z));
            //wheelSpeed -= wheelSpeed > DAMPENING_FACTOR ? DAMPENING_FACTOR : wheelSpeed;
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