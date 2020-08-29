using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize
{
    public float distanceToEarn;
    public int coinReward;
    public string carName;

    public Prize(float distanceToEarn,
                 int coinReward = 0,
                 string carName = "")
    {
        this.distanceToEarn = distanceToEarn;
        this.coinReward = coinReward;
        this.carName = carName;
    }

    public void ClaimPrize()
    {
        if (coinReward != 0) GameDataManager.AddCoins(coinReward);
        if (carName != "") GameDataManager.AddCar(carName);
    }
}
