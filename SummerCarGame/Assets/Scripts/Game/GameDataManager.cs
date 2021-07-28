using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class that holds all of the player data that is needed to run the game
/// </summary>
[System.Serializable]
public class PlayerData
{
    public int coins = 0;
    public float totalDistance = 0;
    public List<string> ownedCars = new List<string>() { "Default Car" };
    public List<float> earnedPrizes = new List<float>() { };
    public string selectedVehicle = "Default Car";
    // Settings page
    public int selectedControl = 2;
    public bool explosionsEnabled = false;
    public float musicLevel = 1;
    public bool soundEffectsEnabled = true;
    public float sunPoint = 60;
    public bool isNightMode = false;
    // Daily reward page
    public int[] nextSpinDate = new int[3] { DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day };
}

/// <summary>
/// Class with getters and setters to all of the methods in the instance of the PlayerData
/// </summary>
public static class GameDataManager
{
    public static PlayerData playerData = new PlayerData();

    public static int GetCoins() => playerData.coins;
    public static void AddCoins(int amount) => playerData.coins += amount;
    public static void SpendCoins(int amount) => playerData.coins -= amount;
    public static bool CanSpendCoins(int amount) => playerData.coins >= amount;
    public static float GetTotalDistance() => playerData.totalDistance;
    public static void AddDistance(float amount) => playerData.totalDistance += amount;
    public static List<string> GetOwnedCars() => playerData.ownedCars;
    public static void AddCar(string newCar) => playerData.ownedCars.Add(newCar);
    public static List<float> GetEarnedPrizes() => playerData.earnedPrizes;
    public static void AddPrize(float prizeDistance) => playerData.earnedPrizes.Add(prizeDistance);
    public static string GetSelectedVehicle() => playerData.selectedVehicle;
    public static void SetSelectedVehicle(Vehicle vehicle) => playerData.selectedVehicle = vehicle.GetName();
    public static void SetSelectedVehicle(string name) => playerData.selectedVehicle = name;
    public static int GetSelectedControl() => playerData.selectedControl;
    public static void SetSelectedControl(int controlInd) => playerData.selectedControl = controlInd;
    public static bool ExplosionsEnabled() => playerData.explosionsEnabled;
    public static void SwitchExplosionsEnabled() => playerData.explosionsEnabled = !playerData.explosionsEnabled;
    public static float GetMusicLevel() => playerData.musicLevel;
    public static void SetMusicLevel(float musicLevel) => playerData.musicLevel = musicLevel;
    public static bool SoundEffectsEnabled() => playerData.soundEffectsEnabled;
    public static void SwitchSoundEffectsEnabled() => playerData.soundEffectsEnabled = !playerData.soundEffectsEnabled;
    public static float GetSunPoint() => playerData.sunPoint;
    public static void SetSunPoint(float sunPoint) => playerData.sunPoint = sunPoint;
    public static bool IsNightMode() => playerData.isNightMode;
    public static void SwitchNightMode() => playerData.isNightMode = !playerData.isNightMode;
    public static void SetNextSpinDate(int[] nextSpinDate) => playerData.nextSpinDate = nextSpinDate;
    public static DateTime GetNextSpinDate()
    {
        if (playerData.nextSpinDate != null)
            return new DateTime(playerData.nextSpinDate[0], playerData.nextSpinDate[1], playerData.nextSpinDate[2], 0, 0, 0);
        else
            return DateTime.Now;
    }
}
