using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player data holder
[System.Serializable] public class PlayerData
{
    public int coins = 0;
}
public static class GameDataManager
{
    static PlayerData playerData = new PlayerData();

    //Player Data Methods
    public static int GetCoins()
    {
        return playerData.coins;
    }

    public static void AddCoins(int amount)
    {
        playerData.coins += amount;
    }
    public static void SpendCoins(int amount)
    {
        playerData.coins -= amount;
    }
    public static bool CanSpendCoins(int amount)
    {
        return (playerData.coins >= amount);
    }
}
