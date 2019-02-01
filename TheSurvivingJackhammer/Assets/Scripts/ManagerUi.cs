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


    public Text[] EndGameTexts; //1 - dinheiro ganho    2 - dinheiro total  3- score    4 - ScoreTotal      5 - coin multiply       6 - point multiply

    public GameObject EndGamePanel;
    CoinManager coinManager;

	void Start(){
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();        
        HighScoreManager.points = 0;
        coinText.text = "Coins: " + coinManager.GetCoins().ToString();
    }
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + HighScoreManager.points.ToString();
		HighScoreTxt.text = "Best Score: " + (HighScoreManager.HighScore - 1).ToString();
        coinMultiplicator.text = "x" + CoinManager.coinMultiplicator.ToString();
        earnedCoins.text = "Earned Coins: " + CoinManager.earnedcoins.ToString();
    }

    public void EnableEndGamePanel()
    {        
        EndGamePanel.SetActive(true);       
        coinManager.ChangeCoins();
        EndGameTexts[0].text = "Earned Coins: " + (CoinManager.earnedcoins).ToString();
        EndGameTexts[1].text = "Total Coins: " + coinManager.GetCoins().ToString();
        EndGameTexts[2].text = "Score: " + (HighScoreManager.points).ToString();
        EndGameTexts[3].text = "High Score: " + ((HighScoreManager.HighScore) - 1).ToString();
        EndGameTexts[4].text = "x" + CoinManager.coinMultiplicator.ToString();
        CoinManager.earnedcoins -= CoinManager.coinMultiplicator;
        HighScoreManager.points -= 1;   //diminui para nao contar a ultima morte;
    }

    public void DisableEngGamePanel()
    {
        EndGamePanel.SetActive(false);
        HighScoreManager.CheckScore();
        CoinManager.ResetEarnedCoins();
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

