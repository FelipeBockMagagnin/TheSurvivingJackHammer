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

    public Button playAds;
    public Button playAdsMultiplyCoins;


    public Text[] EndGameTexts; //1 - dinheiro ganho    2 - dinheiro total  3- score    4 - ScoreTotal      5 - coin multiply       6 - point multiply

    public GameObject EndGamePanel;
    CoinManager coinManager;
    AdsManager adsManager;
    int earnedcoins;

	void Start(){
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        adsManager = GameObject.Find("AdsManager").GetComponent<AdsManager>();
        HighScoreManager.points = 0;
    }
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + HighScoreManager.points.ToString();
        if (HighScoreManager.HighScore < 0)
        {
            HighScoreTxt.text = "Best Score: 0";
        }
        else
        {
            HighScoreTxt.text = "Best Score: " + (HighScoreManager.HighScore - 1).ToString();
        }
        coinMultiplicator.text = "x" + CoinManager.coinMultiplicator.ToString();
        coinText.text = "Coins: " + (coinManager.GetCoins()+ coinManager.earnedcoins).ToString();
    }

    public void EnableEndGamePanel()
    {        
        EndGamePanel.SetActive(true);               
        EndGameTexts[1].text = "Coins: " + (coinManager.GetCoins()+coinManager.earnedcoins).ToString();
        EndGameTexts[2].text = "Score: " + (HighScoreManager.points).ToString();
        EndGameTexts[3].text = "High Score: " + ((HighScoreManager.HighScore) - 1).ToString();
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "+ " + coinManager.earnedcoins;
        print("earnedCoins: " + coinManager.earnedcoins);
        this.earnedcoins = coinManager.earnedcoins;
        coinManager.ChangeCoins();
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

    public void EnableShowAdsMultiply()
    {
        playAdsMultiplyCoins.interactable = true;
    }

    public void GivePlayerMultiplyCoin()
    {
        coinManager.earnedcoins = this.earnedcoins * 2;
        coinManager.ChangeCoins();
        EndGameTexts[1].text = "Coins: " + (coinManager.GetCoins()).ToString();
        EndGameTexts[2].text = "Score: " + (HighScoreManager.points).ToString();
        EndGameTexts[3].text = "High Score: " + ((HighScoreManager.HighScore) - 1).ToString();
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "+ " + this.earnedcoins * 2;    
    }

    public void disableShowAds()
    {
        playAds.interactable = false;
    }

    public void enableShowAds()
    {
        playAds.interactable = true;
    }

    public void reloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //DESTROY BUTTONS ON START
    public Button[] DestroyButton;
    public Text[] texts;

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
    }


    
}

