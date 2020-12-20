using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player data holder
//[System.Serializable]
public class PlayerData
{
    public int coins = 0;
    public float totalDistance = 0;
    public List<string> ownedCars = new List<string>() { "Default Car" };
    public List<float> earnedPrizes = new List<float>() { };
    public Vehicle selectedVehicle;
    // Settings page
    public int selectedControl = 2;
    public bool explosionsEnabled = false;
    public float musicLevel = 1;
    public bool soundEffectsEnabled = true;
    public float sunPoint = 60;
    public bool isNightMode = false;

    public PlayerData()
    {
        //selectedVehicle = "Default Car";
    }

    public PlayerData(StoredPlayerData storedPlayerData)
    {
        coins = storedPlayerData.coins;
        totalDistance = storedPlayerData.totalDistance;
        ownedCars = storedPlayerData.ownedCars;
        earnedPrizes = storedPlayerData.earnedPrizes;
        //selectedVehicle = storedPlayerData.selectedVehicle;
        selectedControl = storedPlayerData.selectedControl;
        explosionsEnabled = storedPlayerData.explosionsEnabled;
        musicLevel = storedPlayerData.musicLevel;
        soundEffectsEnabled = storedPlayerData.soundEffectsEnabled;
        sunPoint = storedPlayerData.sunPoint;
        isNightMode = storedPlayerData.isNightMode;
    }
}

[System.Serializable]
public class StoredPlayerData
{
    public int coins = 0;
    public float totalDistance = 0;
    public List<string> ownedCars;
    public List<float> earnedPrizes;
    public string selectedVehicle;
    public int selectedControl = 2;
    public bool explosionsEnabled = false;
    public float musicLevel = 1;
    public bool soundEffectsEnabled = true;
    public float sunPoint = 60;
    public bool isNightMode;

    public StoredPlayerData(PlayerData playerData)
    {
        coins = playerData.coins;
        totalDistance = playerData.totalDistance;
        ownedCars = playerData.ownedCars;
        earnedPrizes = playerData.earnedPrizes;
        selectedVehicle = playerData.selectedVehicle.GetName();
        selectedControl = playerData.selectedControl;
        explosionsEnabled = playerData.explosionsEnabled;
        musicLevel = playerData.musicLevel;
        soundEffectsEnabled = playerData.soundEffectsEnabled;
        sunPoint = playerData.sunPoint;
        isNightMode = playerData.isNightMode;
    }
}

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
    public static Vehicle GetSelectedVehicle() => playerData.selectedVehicle;
    public static void SetSelectedVehicle(Vehicle vehicle) => playerData.selectedVehicle = vehicle;
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

    public static void SavePlayer() => SavePlayerData.SavePlayer();
}
