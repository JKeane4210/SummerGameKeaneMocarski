using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;

    public void AddCoin()
    {
        totalCoins += 10;
        GameDataManager.AddCoins(10);

        GameSharedUI.Instance.UpdateCoinsUIText();
    }

    public int GetCoins()
    {
        return totalCoins;
    }
}
