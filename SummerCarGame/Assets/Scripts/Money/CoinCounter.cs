using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;

    public int coinAddition = 10;
    public int normalCoinAddition;
    public List<bool> isTwoTimers = new List<bool>();
    public bool addNew = true;

    private GameObject canvas;
    private GameObject sceneController;
    private float twoTimesTimerLength = 8;
    private List<float> timers = new List<float>();
    private List<int> removals = new List<int>();

    void Start()
    {
        normalCoinAddition = coinAddition;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
    }

    void Update()
    {
        if (canvas.GetComponent<powerUpBoard>().AllTrue("2X"))
        {   if (addNew)
            {
                coinAddition *= 2;
                timers.Add(twoTimesTimerLength);
                addNew = false;
            }
            sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;

        }
        for (int i = 0; i < timers.Count; i++)
        {
            //print(timers[i]);
            timers[i] -= Time.deltaTime;
        }
        foreach (float fl in timers)
        {
            if (timers[timers.IndexOf(fl)] <= 0)
            {
                removals.Add(timers.IndexOf(fl));
                coinAddition /= 2;
                sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
        }
        foreach(int i in removals)
        {
            timers.Remove(timers[i]);
            isTwoTimers.Remove(isTwoTimers[i]);
        }
        removals.Clear();
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
