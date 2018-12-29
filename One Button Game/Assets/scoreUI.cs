﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	public Text score;
	public Text HighScoreTxt;

	void Awake(){
		
		HighScoreManager.CheckScore();
		HighScoreManager.points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + HighScoreManager.points.ToString();
		HighScoreTxt.text = "Best Score: " + (HighScoreManager.HighScore - 1).ToString();
	}
}
