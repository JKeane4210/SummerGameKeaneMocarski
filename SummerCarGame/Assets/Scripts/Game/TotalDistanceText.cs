using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDistanceText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float milesTwoDecimals = (float)((int)(GameDataManager.GetTotalDistance() * 100));
        GetComponent<TextMeshProUGUI>().text = $"Total Distance: {(float)(milesTwoDecimals / 100)} mi.";
    }
}
