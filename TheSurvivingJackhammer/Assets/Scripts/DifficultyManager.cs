using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {


	SpawnManager spawnManager;

	public float initialEnemy1Speed;
	public float initialWaitTime;

	float Enemy1Speed;
	float WaitTime;

	public int difficultyLevel = 1;
	private float time;	

	public Animator camAnim;

	void Start(){
        spawnManager = GameObject.Find("Spawn").GetComponent<SpawnManager>();
		camAnim = GameObject.Find("MainCamera").GetComponent<Animator>();
		camAnim.SetTrigger("reload");
		PlayerPrefs.SetInt("highscore", HighScoreManager.HighScore);
		PlayerPrefs.Save();
	}

	public void StartGame(){
		Enemy1Speed = initialEnemy1Speed;
		WaitTime = initialWaitTime;
		StartCoroutine(increaseDifficulty());
		time = 1; //a cada 1 segundo aumenta dificuldade;	
	}

	void Update () {
		spawnManager.waitTime = WaitTime;
	}		
	
	IEnumerator increaseDifficulty(){
		if(Enemy1Speed <= 6){
			Enemy1Speed += 0.1f;
		} else {
			Enemy1Speed += 0.03f;
		}
		if(WaitTime >= 0.7){
			WaitTime -= 0.03f;	
		} else {
			WaitTime -= 0.003f;
		}
		difficultyLevel++;
		yield return new WaitForSeconds(time);
		StartCoroutine(increaseDifficulty());
	}
}
