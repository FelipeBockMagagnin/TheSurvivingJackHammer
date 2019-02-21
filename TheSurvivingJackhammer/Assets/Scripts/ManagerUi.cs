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

    /// <summary>
    /// Mostra o ad ao final do nivel
    /// </summary>
    public void ShowInterstitialAd()
    {
        interstitialAds.ShowInterstitalAd();
    }

    /// <summary>
    /// Ativa o painel final do jogo
    /// </summary>
    public void EnableEndGamePanel()
    {
        ShowInterstitialAd();
        EndGamePanel.SetActive(true);               
        EndGameTexts[1].text = (coinManager.GetCoins()+coinManager.earnedcoins).ToString();
        EndGameTexts[2].text = (HighScoreManager.points).ToString();        
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "+ " + coinManager.earnedcoins;
        print("earnedCoins: " + coinManager.earnedcoins);
        this.earnedcoins = coinManager.earnedcoins;
        coinManager.ChangeCoins();
        EndGameTexts[3].text = ((HighScoreManager.HighScore) - 1).ToString();
        EnableShowAdsMultiply();
    }

    /// <summary>
    /// Chama a propaganda de multiplicar coins
    /// </summary>
    public void CallPropagandaMultiply()
    {
        adsManager.GivePlayerCoinMultiply();
    }

    /// <summary>
    /// Desativa o painel final
    /// </summary>
    public void DisableEngGamePanel()
    {
        EndGamePanel.SetActive(false);
    }

    /// <summary>
    /// Desativa o botão de mostrar ads multiplicador
    /// </summary>
    public void disableSHowAdsMultiply()
    {
        playAdsMultiplyCoins.interactable = false;
    }

    /// <summary>
    /// Usuario optou por assistir ad
    /// </summary>
    public void userOptToWatchAd()
    {
        adsManager.UserOptWatchAdMultipliCoins();
    }

    /// <summary>
    /// Ativa botão de assistir Ad e multiplicar
    /// </summary>
    public void EnableShowAdsMultiply()
    {
        playAdsMultiplyCoins.interactable = true;
    }

    /// <summary>
    /// Da ao player o multiplicador de coins
    /// </summary>
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

    /// <summary>
    /// Recarrega o nivel
    /// </summary>
    public void reloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    /// <summary>
    /// Reseta os atributos do coin manager
    /// </summary>
    public void resetAtributes()
    {
        coinManager.ResetCoinMultiplicator();
    }

    //DESTROY BUTTONS ON START
    public Button[] DestroyButton;
    public Text[] texts;
    public Image[] images;

    /// <summary>
    /// Destroy os botões ao começar o jogo
    /// </summary>
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

