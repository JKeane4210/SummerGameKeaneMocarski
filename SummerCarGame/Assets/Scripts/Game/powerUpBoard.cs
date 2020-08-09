using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class powerUpBoard : MonoBehaviour
{
    private GameObject canvas;
    private GameObject radialElement;

    public int[] powerUpCounts = new int[2]; //NUMBER OF RADIAL POWERUPS
    public List<string> isTrue = new List<string>();
    public string addNew;

    //private GameObject sceneController;
    private float timerLength = 8;
    private float goldAnimalTimerLength = 4;
    private List<GameObject> powerups = new List<GameObject>();
    private List<float> timers = new List<float>();
    private List<int> removals = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        //sceneController = GameObject.FindGameObjectWithTag("SceneController");
        radialElement = (GameObject)Resources.Load("Models/UI_Stuff/RadialTimer");
        canvas = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if((timers.Count != powerups.Count || powerups.Count != isTrue.Count) || timers.Count != isTrue.Count)
        //    print(timers.Count.ToString() + ", " + powerups.Count.ToString() + ", " + isTrue.Count.ToString());
        if (addNew != null && addNew != "")
        {
            //print("'" + addNew + "'");
            GameObject newRadial = Instantiate(radialElement, canvas.transform, false);
            newRadial.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            newRadial.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40 + GameObject.FindGameObjectsWithTag("RadialElement").Length * 110, 60, 0);
            newRadial.GetComponentInChildren<TextMeshProUGUI>().text = addNew;
            powerups.Add(newRadial);
            if (addNew == "Animal")
                timers.Add(goldAnimalTimerLength);
            else
                timers.Add(timerLength);
            addNew = null;
        }
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i] -= Time.deltaTime;
        }
        //sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        foreach (GameObject g in powerups)
        {
            if (isTrue[powerups.IndexOf(g)] == "Animal")
                g.GetComponentInChildren<Image>().fillAmount = timers[powerups.IndexOf(g)] / goldAnimalTimerLength;
            else
                g.GetComponentInChildren<Image>().fillAmount = timers[powerups.IndexOf(g)] / timerLength;
        }
        foreach (GameObject g in powerups)
        {
            if (timers[powerups.IndexOf(g)] <= 0)
            {
                int removeInd = powerups.IndexOf(g);
                removals.Add(removeInd);
                //sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
        foreach (int i in removals)
        {
            Destroy(powerups[i]);
            powerups.RemoveAt(i);
            timers.RemoveAt(i);
            isTrue.RemoveAt(i);
        }
        if(removals.Count > 0)
        {
            for(int i = removals[0]; i < powerups.Count; i++)
            {
                GameObject g2 = powerups[i];
                g2.GetComponent<RectTransform>().anchoredPosition = new Vector2(g2.GetComponent<RectTransform>().anchoredPosition.x - 110 * removals.Count, g2.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
        removals.Clear();
        if (Time.timeScale == 0)
        {
            while (powerups.Count > 0)
            {
                Destroy(powerups[0]);
                powerups.RemoveAt(0);
                timers.RemoveAt(0);
                isTrue.RemoveAt(0);
            }
        }
        UpdatePowerUpCounts();
    }

    private int CountPowerUp(string powerup)
    {
        int count = 0;
        foreach (string s in isTrue)
        {
            if (s == powerup)
                count++;
        }
        return count;
    }

    private void UpdatePowerUpCounts()
    {
        powerUpCounts[0] = CountPowerUp("2X");
        powerUpCounts[1] = CountPowerUp("Animal");
    }
}
