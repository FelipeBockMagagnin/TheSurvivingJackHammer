using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

	public static int points = 0;
	public static int HighScore = 0;
	public static int index = 0;	
	
	public static HighScoreManager instance;
	
	public static void CheckScore(){
        if (points > HighScore && HighScore > 0){
			HighScore = points;
		}
		if (HighScore <= 0) {
			HighScore = 1;
			if(HighScore > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore", HighScore);
			}
		}
        points = 0;
	}	

	void Start(){
		HighScore = PlayerPrefs.GetInt("highscore");        
	}

	void Awake(){
        if (instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

    
}
