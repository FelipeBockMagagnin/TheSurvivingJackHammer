using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	public static int points = 0;
	public static int HighScore = 0;
	public static int index = 0;	
	
	public static HighScoreManager instance;
    static CoinManager coinManager;
	
	public static void CheckScore(){
        coinManager.ChangeCoins(points / 2);
        if (points > HighScore && HighScore > 0){
			HighScore = points;
		}
		if (HighScore <= 0) {
			
			HighScore = 1;
			if(HighScore > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore", HighScore);
			}
		}
	}	

	void Start(){
		HighScore = PlayerPrefs.GetInt("highscore");
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
	}

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
	}	
}
