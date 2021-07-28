using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;

    private const float TWO_TIMES_TIMER_LENGTH = 8;

    private GameObject canvas;
    private GameObject sceneController;
    private List<float> timers = new List<float>();
    private List<int> removals = new List<int>();

    public int coinAddition = 10;
    public List<bool> isTwoTimers = new List<bool>();
    public bool addNew = true;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
    }

    /// <summary>
    /// Keeps a group of powerups in the bottom left corner of the screen
    /// </summary>
    void Update()
    {
        if (canvas.GetComponent<powerUpBoard>().powerUpCounts[0] > 0)
        {   if (addNew)
            {
                coinAddition *= 2;
                timers.Add(TWO_TIMES_TIMER_LENGTH);
                addNew = false;
            }
            sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
        for (int i = 0; i < timers.Count; i++) timers[i] -= Time.deltaTime;
        foreach (float timer in timers)
        {
            if (timers[timers.IndexOf(timer)] <= 0)
            {
                removals.Add(timers.IndexOf(timer));
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

    /// <summary>
    /// Adds a coin and displays this all through the game
    /// </summary>
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

    public int GetCoins() => totalCoins;
}
