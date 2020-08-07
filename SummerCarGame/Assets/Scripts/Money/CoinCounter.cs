using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;
    public int coinAddition = 10;
    public bool isTwoTimes = false;
    private int normalCoinAddition;
    private GameObject sceneController;
    private float twoTimesTimer = 8;
    private float twoTimesTimerLength = 8;

    void Start()
    {
        normalCoinAddition = coinAddition;
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
    }

    void Update()
    {
        if (coinAddition >= 2 * normalCoinAddition)
        {
            twoTimesTimer -= Time.deltaTime;
            isTwoTimes = true;
            sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
        if (twoTimesTimer <= 0)
        {
            twoTimesTimer = twoTimesTimerLength;
            coinAddition /= 2;
            isTwoTimes = false;
            sceneController.GetComponent<SceneDrawing>().coinsTextAndImgs.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
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
