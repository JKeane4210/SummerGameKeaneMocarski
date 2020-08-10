using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class powerUpBoard : MonoBehaviour
{
    private const float NORMAL_TIMER_LENGTH = 8;
    private const float GOLD_ANIMAL_POWERUP_TIMER_LENGTH = 4;

    private GameObject canvas;
    private GameObject radialElement;

    public string addNew;
    public int[] powerUpCounts = new int[2]; //NUMBER OF RADIAL POWERUPS
    public List<string> isTrue = new List<string>();
    
    private List<GameObject> powerups = new List<GameObject>();
    private List<float> timers = new List<float>();
    private List<int> removals = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        radialElement = (GameObject)Resources.Load("Models/UI_Stuff/RadialTimer");
        canvas = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (addNew != null && addNew != "")
        {
            AddNewRadialTimer(addNew);
            if (addNew == "Animal")
                timers.Add(GOLD_ANIMAL_POWERUP_TIMER_LENGTH);
            else
                timers.Add(NORMAL_TIMER_LENGTH);
            addNew = null;
        }
        for (int i = 0; i < timers.Count; i++)
            timers[i] -= Time.deltaTime;
        foreach (GameObject powerup in powerups)
        {
            Image powerupTimerImage = powerup.GetComponent<Image>();
            if (isTrue[powerups.IndexOf(powerup)] == "Animal")
                powerupTimerImage.fillAmount = timers[powerups.IndexOf(powerup)] / GOLD_ANIMAL_POWERUP_TIMER_LENGTH;
            else
                powerupTimerImage.fillAmount = timers[powerups.IndexOf(powerup)] / NORMAL_TIMER_LENGTH;
            if (timers[powerups.IndexOf(powerup)] <= 0)
                removals.Add(powerups.IndexOf(powerup));
        }
        foreach (int i in removals)
            RemoveElementInAllArrays(i);
        if(removals.Count > 0)
        {
            for(int i = removals[0]; i < powerups.Count; i++)
            {
                RectTransform powerupRadialTimerRectTransform = powerups[i].GetComponent<RectTransform>();
                powerupRadialTimerRectTransform.anchoredPosition = new Vector2(powerupRadialTimerRectTransform.anchoredPosition.x - 110 * removals.Count, powerupRadialTimerRectTransform.anchoredPosition.y);
            }
        }
        removals.Clear();
        if (Time.timeScale == 0)
            while (powerups.Count > 0)
                RemoveElementInAllArrays(0);
        UpdatePowerUpCounts();
    }

    private void RemoveElementInAllArrays(int arrayIndex)
    {
        Destroy(powerups[arrayIndex]);
        powerups.RemoveAt(arrayIndex);
        timers.RemoveAt(arrayIndex);
        isTrue.RemoveAt(arrayIndex);
    }

    private void AddNewRadialTimer(string radialTimerName)
    {
        GameObject newRadial = Instantiate(radialElement, canvas.transform, false);
        newRadial.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newRadial.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40 + GameObject.FindGameObjectsWithTag("RadialElement").Length * 110, 60, 0);
        newRadial.GetComponentInChildren<TextMeshProUGUI>().text = radialTimerName;
        powerups.Add(newRadial);
    }

    private int CountPowerUp(string powerup)
    {
        int count = 0;
        foreach (string s in isTrue)
            if (s == powerup) count++;
        return count;
    }

    private void UpdatePowerUpCounts()
    {
        powerUpCounts[0] = CountPowerUp("2X");
        powerUpCounts[1] = CountPowerUp("Animal");
    }
}
