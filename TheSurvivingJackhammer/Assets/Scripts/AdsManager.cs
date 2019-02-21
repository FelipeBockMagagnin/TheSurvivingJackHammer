using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    AdsManager instance;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
        string appid = "ca-app-pub-8861904667614686~2526420754";
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

    private void Awake()
    {

            GameObject[] objs = GameObject.FindGameObjectsWithTag("Ads");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        
    }

    /// <summary>
    /// Pede um anuncio para carregar e ficar em espera
    /// </summary>
    private void RequestRewardBasedVideo()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8861904667614686/5478679273";
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

    /// <summary>
    /// Usuario optou por assistir um anuncio, o anuncio é chamado
    /// </summary>
    public void UserOptWatchAdMultipliCoins()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            Debug.Log("ad foi carregao e vai ser mostrado");
        } else
        {
            RequestRewardBasedVideo();
        }
    }

    /// <summary>
    /// Da a recompensa ao usuario, chama o metodo localizado no UImanager
    /// </summary>
    public void GivePlayerCoinMultiply()
    {
        GameObject.FindGameObjectWithTag("UiManager").GetComponent<ManagerUi>().GivePlayerMultiplyCoin();
    }

    /// <summary>
    /// Metodo não mais utilizado, dava uma chance de jogar novamente
    /// </summary>
    public void GivePlayerReward()
    {
        //GameObject.Find("StyleManager").GetComponent<StyleManager>().ContinuePlaying();
    }

    /// <summary>
    /// Caso o video foi carregado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
    }

    /// <summary>
    /// Video teve um problema ao carregar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //this.RequestRewardBasedVideo();
    }

    /// <summary>
    /// Video foi aberto
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    { 
    }

    /// <summary>
    /// Video começou
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    /// <summary>
    /// Video fechou
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    /// <summary>
    /// Video de recompensa terminou
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {    
        GivePlayerCoinMultiply();          
    }

    /// <summary>
    /// app foi fechado no meio do video
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
}
