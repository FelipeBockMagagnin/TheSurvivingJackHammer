﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{

    private RewardBasedVideoAd rewardBasedVideo;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
        string appid = "ca-app-pub-3940256099942544/5224354917";
        #else
        string appid = "not"
        #endif
        print("appid: " + appid);
        MobileAds.Initialize(appid);


        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        RequestRewardBasedVideo();
    }

  

    private void RequestRewardBasedVideo()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void UserOptToWatchAd()
    {
        
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            
        }
    }

    public void GivePlayerReward()
    {
        GameObject.Find("StyleManager").GetComponent<StyleManager>().ContinuePlaying();
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    { 
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        GivePlayerReward();        
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }



}