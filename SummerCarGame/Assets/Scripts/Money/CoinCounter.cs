using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    static int totalCoins = 0;

    public void AddCoin()
    {
        totalCoins++;
    }

    public int GetCoins()
    {
        return totalCoins;
    }
}
