using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	public static int points;

	public static int HighScore = 0;

	
	public static HighScoreManager instance;

	public static void CheckScore(){
		if(points >= HighScore && HighScore > 0){
			HighScore = points;
		} else if(HighScore <= 0) {
			HighScore = 1;
		}
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
