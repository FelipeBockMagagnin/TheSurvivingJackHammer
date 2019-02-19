using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

	public static int points = 0;
	public static int HighScore = 0;
	public static int index = 0;
    public static int musicIndex;	
	public static HighScoreManager instance;	

    /// <summary>
    /// Checa o score maximo e o substitui se maior
    /// </summary>
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
	}	

	void Start(){
		HighScore = PlayerPrefs.GetInt("highscore");   
        if(HighScore <= 0)
        {
            HighScore = 1;
        }
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
