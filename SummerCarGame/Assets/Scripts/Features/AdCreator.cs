using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class AdCreator : MonoBehaviour
{
    // This goes into the build file
    //   <key>GADApplicationIdentifier</key>
	//<string>ca-app-pub-3940256099942544~1712485313</string>
	//<key>SKAdNetworkItems</key>
	//<array>
	//	<dict>
	//		<key>SKAdNetworkIdentifier</key>
	//		<string>cstr6suwn9.skadnetwork</string>
	//	</dict>
	//</array>
    private RewardedAd rewardBasedVideoAd;

    public GameObject mainPanel;
    public GameObject rewardClaimed;
    public GameObject gameSharedUI;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        //ca-app-pub-3940256099942544/1712485313
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        rewardBasedVideoAd = new RewardedAd(adUnitId);
        // Called when an ad request has successfully loaded.
        rewardBasedVideoAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideoAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideoAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardBasedVideoAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardBasedVideoAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardBasedVideoAd.OnAdClosed += HandleRewardedAdClosed;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardBasedVideoAd.LoadAd(request);
    }

    public void ShowRewardedAd()
    {
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
        } else {
            Debug.Log("Wrong-O");
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
        mainPanel.SetActive(false);
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    /// <summary>
    /// What to do when the ad reward earned event is triggered
    /// </summary>
    /// <param name="sender">Event sender</param>
    /// <param name="args">The reward that represents the event trigger</param>
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        rewardClaimed.SetActive(true);
        GameDataManager.AddCoins(1000);
        SavePlayerData.SavePlayer();
        gameSharedUI.GetComponent<GameSharedUI>().UpdateCoinsUIText();
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardBasedVideoAd.LoadAd(request);
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}
