using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {


	SpawnManager spawnManager;

	public float initialEnemy1Speed;
	public float initialWaitTime;

	public float Enemy1Speed;
	public float WaitTime;

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
		time = 0.8f; //a cada 1 segundo aumenta dificuldade;	
	}

	void Update () {
		spawnManager.waitTime = WaitTime;
	}		
	
	public IEnumerator increaseDifficulty(){
		if(Enemy1Speed <= 6.5f){
			Enemy1Speed += 0.2f;
		} else {
			Enemy1Speed += 0.06f;
		}
		if(WaitTime >= 0.8){
			WaitTime -= 0.06f;	
		} else {
			WaitTime -= 0.006f;
		}
		difficultyLevel++;
		yield return new WaitForSeconds(time);
		StartCoroutine(increaseDifficulty());
	}

   

   
}
