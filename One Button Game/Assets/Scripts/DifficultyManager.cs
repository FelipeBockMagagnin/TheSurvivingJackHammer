﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {

	public Enemy1 enemy1;
	public SpawnManager spawnManager;

	public float initialEnemy1Speed;
	public float initialWaitTime;

	float Enemy1Speed;
	float WaitTime;

	int difficultyLevel = 1;
	float time;

	public Text spawnRate;
	public Text difficulty;
	public Text enemy1Speed;
	public Text HighScoreTxt;


	public bool showUI;

	void Start(){
		Enemy1Speed = initialEnemy1Speed;
		WaitTime = initialWaitTime;
		StartCoroutine(increaseDifficulty());
		time = 1;
		HighScoreManager.CheckScore();
		HighScoreTxt.text = "Best Score: " + (HighScoreManager.HighScore - 1).ToString();
		HighScoreManager.points = 0;
	}

	void Update () {
		enemy1.Speed = Enemy1Speed;
		spawnManager.waitTime = WaitTime;
		ShowInUI();
	}		
	
	IEnumerator increaseDifficulty(){
		if(Enemy1Speed <= 6){
			Enemy1Speed += 0.1f;
		} else {
			Enemy1Speed += 0.01f;
		}
		if(WaitTime >= 0.7){
			WaitTime -= 0.03f;	
		} else {
			WaitTime -= 0.001f;
		}
		difficultyLevel++;
		yield return new WaitForSeconds(time);
		StartCoroutine(increaseDifficulty());
	}

	void ShowInUI(){		
		if(showUI){			
			spawnRate.text = "Spawn Rate: " + WaitTime.ToString("F");
			difficulty.text = "Difficulty: " + difficultyLevel.ToString();
			enemy1Speed.text = "Enemy1 Speed: " + Enemy1Speed.ToString("F");
		}
	}

}