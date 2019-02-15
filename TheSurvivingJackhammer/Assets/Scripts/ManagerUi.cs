using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerUi : MonoBehaviour {

	public Text score;
	public Text HighScoreTxt;
    public Text coinText;
    public Text coinMultiplicator;
    public Text earnedCoins;

    public Button playAdsMultiplyCoins;


    public Text[] EndGameTexts; //1 - dinheiro ganho    2 - dinheiro total  3- score    4 - ScoreTotal      5 - coin multiply       6 - point multiply

    public GameObject EndGamePanel;


    CoinManager coinManager;
    AdsManager adsManager;
    InterstitialAds interstitialAds;
    StyleManager styleManager;
    int earnedcoins;

	void Start(){
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        adsManager = GameObject.Find("AdsManager").GetComponent<AdsManager>();
        interstitialAds = GameObject.Find("InterstitialAds").GetComponent<InterstitialAds>();
        styleManager = GameObject.Find("StyleManager").GetComponent<StyleManager>();
        HighScoreManager.points = 0;
    }
	
	// Update is called once per frame
	void Update () {
		score.text = HighScoreManager.points.ToString();
        if (HighScoreManager.HighScore < 0)
        {
            HighScoreTxt.text = "0";
        }
        else
        {
            HighScoreTxt.text = (HighScoreManager.HighScore - 1).ToString();
        }

        if(styleManager.gameStarted == false)
        {
            coinMultiplicator.text = " ";
        } 
        else
        {
            coinMultiplicator.text = "x" + CoinManager.coinMultiplicator.ToString();
        }
        
        coinText.text = (coinManager.GetCoins()+ coinManager.earnedcoins).ToString();
    }

    public void ShowInterstitialAd()
    {
        interstitialAds.ShowInterstitalAd();
    }

    public void EnableEndGamePanel()
    {
        ShowInterstitialAd();
        EndGamePanel.SetActive(true);               
        EndGameTexts[1].text = (coinManager.GetCoins()+coinManager.earnedcoins).ToString();
        EndGameTexts[2].text = (HighScoreManager.points).ToString();
        EndGameTexts[3].text = ((HighScoreManager.HighScore) - 1).ToString();
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "+ " + coinManager.earnedcoins;
        print("earnedCoins: " + coinManager.earnedcoins);
        this.earnedcoins = coinManager.earnedcoins;
        coinManager.ChangeCoins();
        EnableShowAdsMultiply();
    }

    public void CallPropagandaMultiply()
    {
        adsManager.GivePlayerCoinMultiply();
    }

    public void DisableEngGamePanel()
    {
        EndGamePanel.SetActive(false);
    }

    public void disableSHowAdsMultiply()
    {
        playAdsMultiplyCoins.interactable = false;
    }

    public void userOptToWatchAd()
    {
        adsManager.UserOptWatchAdMultipliCoins();
    }

    public void EnableShowAdsMultiply()
    {
        playAdsMultiplyCoins.interactable = true;
    }

    public void GivePlayerMultiplyCoin()
    {
        coinManager.earnedcoins = this.earnedcoins * 2;
        coinManager.ChangeCoins();
        EndGameTexts[1].text = (coinManager.GetCoins()).ToString();
        EndGameTexts[2].text = (HighScoreManager.points).ToString();
        EndGameTexts[3].text = ((HighScoreManager.HighScore) - 1).ToString();
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "+ " + this.earnedcoins * 2;    
    }

    public void reloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //DESTROY BUTTONS ON START
    public Button[] DestroyButton;
    public Text[] texts;
    public Image[] images;

    public void DestroyButtons()
    {

        foreach (Button b in DestroyButton)
        {
            Destroy(b.gameObject);
        }
        foreach (Text t in texts)
        {
            Destroy(t.gameObject);
        }
        foreach (Image i in images)
        {
            Destroy(i.gameObject);
        }
    }


    
}

