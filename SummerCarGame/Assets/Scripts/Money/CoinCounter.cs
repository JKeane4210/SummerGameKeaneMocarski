using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;
    public int coinAddition = 10;
    public bool isTwoTimes = false;
    private GameObject canvas;
    private GameObject twoTimesRadial;
    private int normalCoinAddition;
    private GameObject sceneController;
    private float twoTimesTimer = 8;
    private float twoTimesTimerLength = 8;
    private List<GameObject> powerups = new List<GameObject>();
    private List<float> timers = new List<float>();
    public List<bool> isTwoTimers = new List<bool>();
    public bool addNew = true;
    private List<int> removals = new List<int>();

    void Start()
    {
        normalCoinAddition = coinAddition;
        twoTimesRadial = (GameObject)Resources.Load("Models/UI_Stuff/RadialTimer");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
    }

    void Update()
    {
        if (AllTrue())
        {   if (addNew)
            {
                coinAddition *= 2;
                GameObject new2xRadial = Instantiate(twoTimesRadial, canvas.transform, false);
                new2xRadial.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                new2xRadial.GetComponent<RectTransform>().anchoredPosition = new Vector3(10 + GameObject.FindGameObjectsWithTag("RadialElement").Length * 80, 60, 0);
                powerups.Add(new2xRadial);
                timers.Add(twoTimesTimerLength);
                //isTwoTimers.Add(true);
                addNew = false;
            }
            for(int i = 0; i < timers.Count; i++)
            {
                timers[i] -= Time.deltaTime;
            }
            isTwoTimes = true;
            sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
            foreach(GameObject g in powerups)
            {
                g.GetComponentInChildren<Image>().fillAmount = timers[powerups.IndexOf(g)] / twoTimesTimerLength;
            }
        }
        foreach(GameObject g in powerups)
        {
            if (timers[powerups.IndexOf(g)] <= 0)
            {
                Destroy(powerups[powerups.IndexOf(g)]);
                removals.Add(powerups.IndexOf(g));
                coinAddition /= 2;
                sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
        foreach(int i in removals)
        {
            powerups.Remove(powerups[i]);
            timers.Remove(timers[i]);
            isTwoTimers.Remove(isTwoTimers[i]);
        }
        removals.Clear();
        if (Time.timeScale == 0)
        {
            while (powerups.Count > 0)
            {
                Destroy(powerups[0]);
                powerups.RemoveAt(0);
                timers.RemoveAt(0);
                isTwoTimers.RemoveAt(0);
            }
        }
    }

    public bool AllTrue()
    {
        if (isTwoTimers.Count == 0)
            return false;
        foreach(bool b in isTwoTimers)
        {
            if (!b)
                return false;
        }
        return true;
    }

    public void AddCoin()
    {
        if (sceneController.GetComponent<ButtonManager>().GetIsNightMode())
        {
            totalCoins += (int)((float)(coinAddition * 1.5f));
            GameDataManager.AddCoins((int)((float)(coinAddition * 1.5f)));
        }
        else
        {
            totalCoins += coinAddition;
            GameDataManager.AddCoins(coinAddition);
        }

        GameSharedUI.Instance.UpdateCoinsUIText();
    }

    public int GetCoins()
    {
        return totalCoins;
    }
}
