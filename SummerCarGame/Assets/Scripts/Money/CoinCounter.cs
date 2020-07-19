using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;
    private GameObject sceneController;

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("SceneController");
    }

    public void AddCoin()
    {
        if (sceneController.GetComponent<ButtonManager>().GetIsNightMode())
        {
            totalCoins += 15;
            GameDataManager.AddCoins(15);
        }
        else
        {
            totalCoins += 10;
            GameDataManager.AddCoins(10);
        }

        GameSharedUI.Instance.UpdateCoinsUIText();
    }

    public int GetCoins()
    {
        return totalCoins;
    }
}
