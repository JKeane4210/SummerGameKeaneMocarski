using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player data holder
[System.Serializable] public class PlayerData
{
    public int coins = 0;
    public float totalDistance = 0;
    public ArrayList ownedCars = new ArrayList() { "Default Car" };
}
public static class GameDataManager
{
    static PlayerData playerData = new PlayerData();

    //Player Data Methods
    public static int GetCoins() => playerData.coins;
    public static void AddCoins(int amount) => playerData.coins += amount;
    public static void SpendCoins(int amount) => playerData.coins -= amount;
    public static bool CanSpendCoins(int amount) => playerData.coins >= amount;
    public static void AddDistance(float amount) => playerData.totalDistance += amount;
    public static float GetTotalDistance() => playerData.totalDistance;
    public static ArrayList GetOwnedCars() => playerData.ownedCars;
    public static void AddCar(string newCar) => playerData.ownedCars.Add(newCar);
}
